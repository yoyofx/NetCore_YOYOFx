using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using MaxZhang.EasyEntities.Persistence.Mapping;

namespace MaxZhang.EasyEntities.Persistence.Linq
{
    /// <summary>
    /// Linq数据读取器
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    internal class ObjectReader<TData> : IEnumerable<TData>, IEnumerable
    {

        Enumerator enumerator;
        internal ObjectReader(DbDataReader reader)
        {
            this.enumerator = new Enumerator(reader);
        }

        public IEnumerator<TData> GetEnumerator()
        {
            Enumerator e = this.enumerator;

            if (e == null)
            {
                throw new InvalidOperationException("Cannot enumerate more than once");
            }
            this.enumerator = null;
            return e;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        class Enumerator : IEnumerator<TData>, IEnumerator, IDisposable
        {
            DbDataReader reader;
            TData current;
            internal Enumerator(DbDataReader reader)
            {
                this.reader = reader;
            }

            public TData Current
            {
                get { return this.current; }
            }

            object IEnumerator.Current
            {
                get { return this.current; }
            }

            public bool MoveNext()
            {

                if (reader.Read())
                {
                    TData item;
                    if (typeof(TData).BaseType == typeof(DbObject))
                        item = reader.ToEntity<TData>();
                    else
                        item = reader.ToAEntity<TData>();
                    this.current = item;
                    return true;
                }
                return false;
            }


            public void Reset()
            {

            }


            public void Dispose()
            {

                this.reader.Dispose();

            }
        }

    }





}
