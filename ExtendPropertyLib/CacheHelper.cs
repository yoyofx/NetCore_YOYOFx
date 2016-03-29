using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
namespace ExtendPropertyLib
{     

        public interface ICache<TData>
        {
            TData Get(object key);
            void Set(object key, TData data);
        }


        public class SimpleCache<TData> : ICache<TData>
        {
            private ConcurrentDictionary<object, TData> cache = new ConcurrentDictionary<object, TData>();



            #region ICacheManager<TData> 成员

            public TData Get(object key)
            {
                TData data;
                if(!cache.TryGetValue(key,out data))
                    data = default(TData);
                return data;
            }

            public void Set(object key, TData data)
            {
                cache[key] = data;
            }

            #endregion
        }


        public class TimeoutCache<TData> : ICache<TData>
        {
            public TimeSpan Expire { get; set; }
            private DateTime timeLastScan = DateTime.Now;
            private Dictionary<object, KeyValuePair<TData, DateTime>> cache = new Dictionary<object, KeyValuePair<TData, DateTime>>();

            public TimeoutCache()
            {
                Expire = TimeSpan.FromMinutes(15);
            }

            private void TryClearExpireObject()
            {
                TimeSpan ts = DateTime.Now - timeLastScan;
                if (ts.TotalSeconds > Expire.TotalSeconds / 2)
                {
                    timeLastScan = DateTime.Now;
                    cache.Where(kv => kv.Value.Value > DateTime.Now.Subtract(Expire)).ToList().ForEach(kv =>
                    {
                        cache.Remove(kv.Key);
                    });
                }
            }

            #region ICacheManager<TData> 成员

            public TData Get(object key)
            {
                TryClearExpireObject();

                if (!cache.ContainsKey(key))
                    return default(TData);


                KeyValuePair<TData, DateTime> kv = cache[key];
                if (kv.Value.Add(Expire) < DateTime.Now)
                {
                    cache.Remove(key);
                    return default(TData);
                }
                return kv.Key;
            }

            public void Set(object key, TData data)
            {
                cache[key] = new KeyValuePair<TData, DateTime>(data, DateTime.Now);
            }

            #endregion
        }

        public class CacheManager<TData>
        {
            private ICache<TData> cache = null;

            public TData SourceGetter { get; private set; }
            public CacheManager(ICache<TData> cache, TData sourceGetter)
            {
                this.cache = cache;
                this.SourceGetter = sourceGetter;
            }

            #region ICacheGetter<TData> 成员

            public TData Get(object key)
            {
                TData data = cache.Get(key);
                if (data != null)
                    return data;

                data = this.SourceGetter;

                cache.Set(key, data);

                return data;
            }



            public void Set(object key, TData data)
            {
                cache.Set(key, data);
            }

            #endregion
        }



    
}
