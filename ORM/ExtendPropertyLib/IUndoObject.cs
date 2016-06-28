using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendPropertyLib
{
    /// <summary>
    /// 可撤销对象接口
    /// </summary>
    interface IUndoObject
    {
        /// <summary>
        /// 撤销
        /// </summary>
        void Undo();
        /// <summary>
        /// 接受当前值
        /// </summary>
        void Accept();

        /// <summary>
        /// 清除所有可撤销状态
        /// </summary>
        void Clear();
        /// <summary>
        /// 撤销级别
        /// </summary>
        int UndoLevel { get;}

    }
}
