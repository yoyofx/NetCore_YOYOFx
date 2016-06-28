using ExtendPropertyLib;

namespace MaxZhang.EasyEntities.Persistence.Mapping
{
    /// <summary>
    /// 所有物理模型的基类
    /// </summary>
    public abstract class DbObject : ExtendObject
    {
        public static ExtendProperty TableNameProperty =
            ExtendProperty.RegisterProperty("TableName", typeof(string), typeof(DbObject));

        public static ExtendProperty KeysProperty =
            ExtendProperty.RegisterProperty("Keys", typeof(string[]), typeof(DbObject));

    }

   

}
