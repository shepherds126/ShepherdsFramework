using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.FileStore
{
    /// <summary>
    /// 文件存储提供者
    /// </summary>
    public interface IStoreProvider
    {
        /// <summary>
        /// 文件提供者的存储根路径
        /// </summary>
        string StoreRootPath { get; }
        /// <summary>
        /// 根据文件相对路径和文件名获取文件
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        IStoreFile GetFile(string relativePath, string fileName);
        /// <summary>
        /// 利用相对文件名称获取文件
        /// </summary>
        /// <param name="relativeFileName"></param>
        /// <returns></returns>
        IStoreFile GetFile(string relativeFileName);
        /// <summary>
        /// 利用相对文件路径获取所有的文件
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="isOnlyCurrentFolder">是否只获取当前层次的文件</param>
        /// <returns></returns>
        IEnumerable<IStoreFile> GetFiles(string relativePath, bool isOnlyCurrentFolder);
    }
}
