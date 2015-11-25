using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using CacheManager.Core;
using ShepherdsFramework.Core.Caching;
using ShepherdsFramework.Core.DependencyManagement;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    /// <summary>
    /// 验证码管理类
    /// </summary>
    public static class VerificationCodeManager
    {

        private static ICacheManager<int> cacheService = ContainerManager.Resolve<ICacheManager<int>>();
        private static readonly AutoInputProtectionTextProviderCollection TextProviderCollection = new AutoInputProtectionTextProviderCollection();
        private static readonly AutoInputProtectionImageProviderCollection ImageProviderCollection = new AutoInputProtectionImageProviderCollection();
        private static readonly AutoInputProtectionFilterProviderCollection FilterProviderCollection = new AutoInputProtectionFilterProviderCollection();
        private static VerificationCodeImageProvider imageProvider;
        private static VerificationCodeTextProvider textProvider;
        private static VerificationCodePersistenceMode persistenceMode;

        private delegate object GetPersistedValueStrategy(HttpContextBase context, string key);

        private static GetPersistedValueStrategy getPersistedValue = GetCacheValue;

        /// <summary>
        /// 验证码存放的位置
        /// </summary>
        public static VerificationCodePersistenceMode PersistenceMode
        {
            get { return persistenceMode; }
            set
            {
                persistenceMode = value;
                switch (value)
                {
                        case VerificationCodePersistenceMode.Cache:
                        getPersistedValue = GetCacheValue;
                        break;
                        case VerificationCodePersistenceMode.Session:
                        getPersistedValue = GetSessionValue;
                        break;
                }
            }
        }
        /// <summary>
        /// 默认的文字提供者
        /// </summary>
        public static VerificationCodeTextProvider DefaultTextProvider
        {
            get
            {
                EnsureProviders();
                return textProvider;
            }
        }
        /// <summary>
        /// 文字提供生成者
        /// </summary>
        public static AutoInputProtectionTextProviderCollection TextProviders
        {
            get
            {
                EnsureProviders();
                return TextProviderCollection;
            }
        }
        /// <summary>
        /// 默认的图片提供者
        /// </summary>
        public static VerificationCodeImageProvider DefaultImageProvider
        {
            get
            {
                EnsureProviders();
                return imageProvider;
            }
        }
        /// <summary>
        /// 图片提供者
        /// </summary>
        public static AutoInputProtectionImageProviderCollection ImageProviders
        {
            get
            {
                EnsureProviders();
                return ImageProviderCollection;
            }
        }
        /// <summary>
        /// 干扰生成提供者
        /// </summary>
        public static AutoInputProtectionFilterProviderCollection FilterProviders
        {
            get
            {
                EnsureProviders();
                return FilterProviderCollection;
            }
        }

        /// <summary>
        /// 生成publickey
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GeneratePublishCacheKey(HttpContextBase context, string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(text + DateTime.Now.Ticks),
                    Base64FormattingOptions.None);
            }
        }
        /// <summary>
        /// 图像key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCacheKeyForImage(string key)
        {
            return key + "_image";
        }
        /// <summary>
        /// 文字key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCacheKeyForText(string key)
        {
            return key + "_text";
        }

        public static string GetCachedText()
        {
            return "";
        }


        private static void EnsureProviders()
        {
            VerificationCodeSection verificationCodeSection = (VerificationCodeSection)WebConfigurationManager.GetSection("");
            bool hasSection = verificationCodeSection != null;
            if (!hasSection) verificationCodeSection = new VerificationCodeSection();
            
            persistenceMode = verificationCodeSection.PersistenceMode;
            InitializeTextProviders(hasSection, verificationCodeSection);
            InitialImageProviders(hasSection, verificationCodeSection);

            ProviderSettingsCollection pc = new ProviderSettingsCollection();
            pc.Add(new ProviderSettings("filter", "ShepherdsFramework.Framework.Utilities.Captcha.CrosshatchVerificationCodeFilterProvider,ShepherdsFramework.Framework.Utilities.Captcha"));
            ProvidersHelper.InstantiateProviders(pc,FilterProviderCollection,typeof(VerificationCodeFilterProvider));
        }


        private static void InitializeTextProviders(bool isHasSection, VerificationCodeSection section)
        {
            if (isHasSection)
            {
                ProvidersHelper.InstantiateProviders(section.TextProviders, TextProviderCollection,
                    typeof (VerificationCodeTextProvider));


                if (
                    section.DefaultTextProvider.Equals(
                        section.ElementInformation.Properties["defaultTextProvider"].DefaultValue))
                {
                    if (TextProviderCollection.Count > 0)
                        textProvider = TextProviderCollection[0];
                    else
                    {
                        textProvider =
                            new BasicEnglishVerificationCodeTextProvider(new[] {Color.Black, Color.Red, Color.Brown},
                                new[]
                                {
                                    new Font("Times New Roman", 1), new Font("Arial", 1),
                                    new Font("Microsoft Sans Serif", 1)
                                });
                    }

                }
                else
                {
                    textProvider = TextProviderCollection[section.DefaultTextProvider];
                }

                if (textProvider == null) throw new InvalidOperationException("验证码字符配置出错");
            }
            else if (textProvider == null)
            {
                section.TextProviders.Add(CreateProviderSettings(section.DefaultTextProvider,
                    typeof (BasicEnglishVerificationCodeTextProvider),
                    new KeyValuePair<string, string>("colors", "Red,Green,Blue,Brown"),
                    new KeyValuePair<string, string>("fonts", "Times New Roman, Arial, Microsoft Sans Serif")));
                ProvidersHelper.InstantiateProviders(section.TextProviders, TextProviderCollection,
                    typeof (VerificationCodeTextProvider));
                textProvider = TextProviderCollection[section.DefaultTextProvider];
            }
        }


        private static void InitialImageProviders(bool hasSection, VerificationCodeSection section)
        {
            if (hasSection)
            {
                //根据给定的Provider类型和提供的节点配置初始化对应的ProviderCollection
                ProvidersHelper.InstantiateProviders(section.ImageProviders,ImageProviderCollection,typeof(VerificationCodeImageProvider));

                if (
                    section.DefaultImageProvider.Equals(
                        section.ElementInformation.Properties["defaultImageProvider"].DefaultValue))
                {
                    if (ImageProviderCollection.Count > 0) imageProvider = ImageProviderCollection[0];
                    else imageProvider = new LineNoiseVerificationCodeImageProvider();
                }
                else
                {
                    imageProvider = ImageProviderCollection[section.DefaultImageProvider];
                }

                if(imageProvider == null) throw new InvalidOperationException("验证码图片配置有误");
            }
            else if (imageProvider == null)
            {
                section.ImageProviders.Add(CreateProviderSettings(section.DefaultImageProvider,typeof(LineNoiseVerificationCodeImageProvider)));
                ProvidersHelper.InstantiateProviders(section.ImageProviders,ImageProviderCollection,typeof(VerificationCodeImageProvider));
                imageProvider = ImageProviderCollection[section.DefaultImageProvider];
            }
        }

        /// <summary>
        /// 加载提供者的设置
        /// </summary>
        /// <returns></returns>
        private static ProviderSettings CreateProviderSettings(string name,Type type,params KeyValuePair<string,string>[] parameters )
        {
            ProviderSettings settings = new ProviderSettings(name,type.AssemblyQualifiedName);
            foreach (KeyValuePair<string,string> parameter in parameters)
            {
                settings.Parameters.Add(parameter.Key,parameter.Value);
            }
            return settings;
        }

        /// <summary>
        /// 从session中获取值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static object GetSessionValue(HttpContextBase context,string key)
        {
            if(context.Session==null) throw new Exception("session出错");
            try
            {
                return context.Session[key];
            }
            finally
            {
                context.Session.Remove(key);
            }

        }
        /// <summary>
        /// 从缓存中获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCacheValue(HttpContextBase context,string key)
        {
            try
            {
                return cacheService.Get(key);
            }
            finally
            {
                cacheService.Remove(key);
            }
        }

        /// <summary>
        /// 利用key获取缓存的图像数据流
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static MemoryStream GetCachedImageStream(string key)
        {
            if(string.IsNullOrEmpty(key)) throw new ArgumentException("cachekeyidnull");
            string imagekey = GetCacheKeyForImage(key);
            try
            {
                //byte[] data = (byte[]) cacheService.Get(imagekey);
                byte[] data = null;
                if (data == null) return null;
                MemoryStream msStream = new MemoryStream(data);
                return msStream;
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// 获取验证码字符串
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCachedTextAndForceExpire(HttpContextBase context,string key)
        {
            if(context == null) throw new ArgumentNullException("context");
            string imagekey = GetCacheKeyForImage(key);
            string textkey = GetCacheKeyForText(key);
            try
            {
                string text = (string)getPersistedValue(context, textkey);
                return text;
            }
            finally
            {
                ExpireCachedImage(imagekey);
            }
        }

        /// <summary>
        /// 释放图像资源
        /// </summary>
        /// <param name="key"></param>
        private static void ExpireCachedImage(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                try
                {
                    cacheService.Remove(key);
                }
                finally
                {
                }
            }
        }

        public static VerificationCodeImage GenerateAndCacheImage(HttpContextBase context, Size size, int timeout,
          out string key, CaptchaCharacterSet captchaCharacterSet, bool enableLineNoise, int minmunCharacter,
          int maxmunCharacter)
        {
            MemoryStream stream;
            VerificationCodeImage apiImage;
            int attempt = 0;
            string text;
            do
            {
                apiImage = GenerateRandomAutoProtectionImage(size, captchaCharacterSet, maxmunCharacter, minmunCharacter);
                text = apiImage.Text;
            } while (CreateImageStream(ref attempt, context, apiImage, enableLineNoise, out stream));
            lock (VerificationCodeImageLockObj)
            {
                key = GeneratePublishCacheKey(context, text);
                string imagekey = GetCacheKeyForImage(key);
                //缓存5分钟
                //cacheService.Add(imagekey,stream.ToArray(),new TimeSpan(0,5,0));
            }

            return apiImage;
        }

        private static readonly object VerificationCodeImageLockObj = new object();
        /// <summary>
        /// 创建验证码实体对象
        /// </summary>
        /// <param name="size"></param>
        /// <param name="characterSet"></param>
        /// <param name="maxmunCharacter"></param>
        /// <param name="minmunCharacter"></param>
        /// <returns></returns>

        private static VerificationCodeImage GenerateRandomAutoProtectionImage(Size size,
            CaptchaCharacterSet characterSet, int maxmunCharacter, int minmunCharacter)
        {
            if (size.Width < 1 || size.Height < 1) throw new ArgumentOutOfRangeException("绘制验证码size的不正确");

            EnsureProviders();

            VerificationCodeImage image = null;
            lock (VerificationCodeImageLockObj)
            {
                image = imageProvider.GenerateRandomAutoInputProtectionImage(size,textProvider,characterSet,maxmunCharacter,minmunCharacter);
            }

            image.filters = FilterProviderCollection;

            return image;

        }

        /// <summary>
        /// 创建的验证码缓存图像流
        /// </summary>
        /// <param name="attempt"></param>
        /// <param name="context"></param>
        /// <param name="apiImage"></param>
        /// <param name="isUseLineNoise"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static bool CreateImageStream(ref int attempt,HttpContextBase context,VerificationCodeImage apiImage,bool isUseLineNoise,out MemoryStream stream)
        {
            stream = null;
            using (Image image = apiImage.CreateCompositeImage(isUseLineNoise))
            {
                try
                {
                    stream = new MemoryStream(image.Width*image.Height);
                    image.Save(stream, ImageFormat.Jpeg);
                }
                catch (ArgumentException)
                {
                    if(stream !=null) stream.Dispose();
                    attempt++;
                    if (attempt == 3) throw;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 将文字存入缓存
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="timeoutseconds"></param>
        public static void CacheText(HttpContextBase context,string text,string key,int timeoutseconds)
        {
            string textkey = GetCacheKeyForText(key);
            if (PersistenceMode == VerificationCodePersistenceMode.Cache)
            {
                //cacheService.Add(textkey,text,new TimeSpan(0,0,timeoutseconds));
            }
            else
            {
                context.Session[textkey] = text;
            }
        }


    }
}
