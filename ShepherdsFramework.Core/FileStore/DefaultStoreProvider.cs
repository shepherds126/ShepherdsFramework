using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Core.FileStore
{
    /// <summary>
    /// 默认的文件存储提供者
    /// </summary>
    public class DefaultStoreProvider:IStoreProvider
    {

        private string directlyRootUrl;

        private string storeRootPath;

        /// <summary>
        /// 文件提供者的存储根路径（虚拟路径、应用程序根路径（~/）、UNC路径）
        /// </summary>
        public string StoreRootPath
        {
            get { return storeRootPath; }
        }

        /// <summary>
        /// Url路径
        /// </summary>
        public string DirectlyRootUrl
        {
            get { return directlyRootUrl; }
        }

        /// <summary>
        /// 根据文件相对路径和文件名获取文件
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public IStoreFile GetFile(string relativePath, string fileName)
        {
            string fulllocalpath = GetFullLocalPath(relativePath, fileName);
            if(File.Exists(fulllocalpath))
                return new DefaultStoreFile(fulllocalpath,new FileInfo(fulllocalpath));
            return null;
        }

        /// <summary>
        /// 利用相对文件名称获取文件
        /// </summary>
        /// <param name="relativeFileName"></param>
        /// <returns></returns>
        public IStoreFile GetFile(string relativeFileName)
        {
            string fullLocalPath = GetFullLocalPath(relativeFileName);
            string relativePath = GetRelativePath(fullLocalPath,true);
            if(File.Exists(fullLocalPath))
                return new DefaultStoreFile(relativePath,new FileInfo(fullLocalPath));
            return null;
        }

        /// <summary>
        /// 利用相对文件路径获取所有的文件
        /// </summary>
        /// <param name="relativePath"></param>
        /// <param name="isOnlyCurrentFolder">是否只获取当前层次的文件</param>
        /// <returns></returns>
        public IEnumerable<IStoreFile> GetFiles(string relativePath, bool isOnlyCurrentFolder)
        {
            //此处是否需要判断文件路径的有效性
            List<IStoreFile> list = new List<IStoreFile>();
            string fullLocalPath = GetFullLocalPath(relativePath,string.Empty);
            if (Directory.Exists(fullLocalPath))
            {
                SearchOption searchOption = SearchOption.TopDirectoryOnly;
                if(!isOnlyCurrentFolder) 
                    searchOption = SearchOption.AllDirectories;
                foreach (var fileInfo in new DirectoryInfo(fullLocalPath).GetFiles("*.*",searchOption))
                {
                    //不为隐藏文件
                    if ((fileInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        DefaultStoreFile defaultStoreFile = !isOnlyCurrentFolder
                            ? new DefaultStoreFile(GetRelativePath(fileInfo.Name, true), fileInfo)
                            : new DefaultStoreFile(relativePath, fileInfo);
                        list.Add(defaultStoreFile);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 利用相对路径和文件名获取完整的本地物理路径
        /// </summary>
        /// <param name="relativePath">相对文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public string GetFullLocalPath(string relativePath, string fileName)
        {
            string path1 = StoreRootPath;
            if (path1.EndsWith(":")) path1 += "\\";
            if (!string.IsNullOrEmpty(relativePath))
            {
                relativePath = relativePath.TrimStart(Path.DirectorySeparatorChar);
                path1 = Path.Combine(path1,relativePath);
            }
            if (!string.IsNullOrEmpty(fileName))
                path1 = Path.Combine(path1,fileName);
            return path1;
        }
        /// <summary>
        /// 利用相对文件路径及名称获取完整的本地物理路径
        /// </summary>
        /// <param name="relativeFileName"></param>
        /// <returns></returns>
        public string GetFullLocalPath(string relativeFileName)
        {
            string path1 = storeRootPath;
            if (!string.IsNullOrEmpty(relativeFileName))
                path1 = Path.Combine(path1,relativeFileName);
            return path1;
        }
        /// <summary>
        /// 利用获
        /// </summary>
        /// <param name="fullLocalPath"></param>
        /// <param name="pathIncludesFilename"></param>
        /// <returns></returns>
        public string GetRelativePath(string fullLocalPath,bool pathIncludesFilename)
        {
            return
                (pathIncludesFilename
                    ? fullLocalPath.Substring(0, fullLocalPath.LastIndexOf(Path.DirectorySeparatorChar))
                    : fullLocalPath).Replace(storeRootPath, string.Empty).TrimStart(Path.DirectorySeparatorChar);
        }
    }
}
