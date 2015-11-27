using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.FileStore
{
    /// <summary>
    /// 存储的文件
    /// </summary>
    public interface IStoreFile
    {
        /// <summary>
        /// 文件名
        /// </summary>
        string Name { get;  }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        string Extension { get;  }
        /// <summary>
        /// 文件大小
        /// </summary>
        long Size { get;  }
        /// <summary>
        /// 文件的相对路径
        /// </summary>
        string RelativePath { get;  }
        /// <summary>
        /// 文件最后修改的时间
        /// </summary>
        DateTime LastModified { get; }
    }
}
