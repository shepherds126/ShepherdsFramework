using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.FileStore
{
    /// <summary>
    /// 存储文件的默认实现
    /// </summary>
    public class DefaultStoreFile:IStoreFile
    {
        private readonly FileInfo fileInfo;
        private string relativedPath;
        private string fullPath;
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name
        {
            get { return this.fileInfo.Name; }
        }
        /// <summary>
        /// 文件的扩展名
        /// </summary>
        public string Extension
        {
            get { return this.fileInfo.Extension; }
        }
        /// <summary>
        /// 文件的长度
        /// </summary>
        public long Size
        {
            get { return this.fileInfo.Length; }
        }
        /// <summary>
        /// 文件的最后修改时间
        /// </summary>
        public DateTime LastModified
        {
            get { return this.fileInfo.LastWriteTime; }
        }
        /// <summary>
        /// 文件的相对路径
        /// </summary>
        public string RelativePath
        {
            get { return this.relativedPath; }
        }
        /// <summary>
        /// 文件的全路径
        /// </summary>
        public string FullPath
        {
            get { return this.fullPath; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="fileInfo"></param>
        public DefaultStoreFile(string relativePath, FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
            this.relativedPath = relativePath;
            this.fullPath = fileInfo.FullName;
        }

    }
}
