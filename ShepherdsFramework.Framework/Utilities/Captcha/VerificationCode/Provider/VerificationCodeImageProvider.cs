using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Drawing;

namespace ShepherdsFramework.Framework.Utilities.Captcha
{
    /// <summary>
    /// 验证码图像基类
    /// </summary>
    public abstract class VerificationCodeImageProvider : ProviderBase
    {
        protected VerificationCodeImageProvider()
        {
        }

        #region Methods
        /// <summary>
        /// 选取一个随机的name
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static string ChooseRandomName(IList<string> names)
        {
            if (names == null)
                throw new ArgumentNullException("names");

            return names[new Random().Next(0, names.Count)];
        }

        /// <summary>
        /// 重载
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static string ChooseRandomName(string[] names)
        {
            if (names == null)
                throw new ArgumentNullException("names");

            return names[new Random().Next(0, names.Length)];
        }

        /// <summary>
        /// 生成自动验证码图片
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="textProvider"></param>
        /// <param name="characterSet"></param>
        /// <param name="maximumCharacters"></param>
        /// <param name="minimumCharacters"></param>
        /// <returns></returns>
        public abstract VerificationCodeImage GenerateAutoInputProtectionImage(string name, Size size, VerificationCodeTextProvider textProvider, CaptchaCharacterSet characterSet, int? maximumCharacters, int? minimumCharacters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="textProvider"></param>
        /// <param name="characterSet"></param>
        /// <param name="maximumCharacters"></param>
        /// <param name="minimumCharacters"></param>
        /// <returns></returns>
        public abstract VerificationCodeImage GenerateRandomAutoInputProtectionImage(Size size, VerificationCodeTextProvider textProvider, CaptchaCharacterSet characterSet, int? maximumCharacters, int? minimumCharacters);
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public class AutoInputProtectionImageProviderCollection : ProviderCollection, ICollection<VerificationCodeImageProvider>
    {
        /// <summary>
        /// Gets the <see cref="AutoInputProtectionImageProvider"/> instance with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the <see cref="AutoInputProtectionImageProvider"/> instance to be retrieved.</param>
        /// <returns>The <see cref="AutoInputProtectionImageProvider"/> instance with the specified <paramref name="name"/>.</returns>
        public new VerificationCodeImageProvider this[string name]
        {
            get
            {
                return (VerificationCodeImageProvider)base[name];
            }
        }

        /// <summary>
        /// Gets the <see cref="AutoInputProtectionImageProvider"/> instance at the specified <paramref name="index"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The specified <paramref name="index"/> is less than zero or is 
        /// greater than or equal to the size of the collection.</exception>
        /// <param name="index">The zero-based index of the <see cref="AutoInputProtectionImageProvider"/> instance to be retrieved.</param>
        /// <returns>The <see cref="AutoInputProtectionImageProvider"/> instance at the specified <paramref name="index"/>.</returns>
        public VerificationCodeImageProvider this[int index]
        {
            get
            {
                int i = 0;
                foreach (VerificationCodeImageProvider provider in this)
                {
                    if (i++ == index)
                        return provider;
                }

                throw new ArgumentOutOfRangeException("index");
            }
        }

        /// <summary>
        /// Adds the specified <paramref name="provider"/> to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The specified <paramref name="provider"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The specified <paramref name="provider"/> does not derive from <see cref="AutoInputProtectionImageProvider"/>.</exception>
        /// <param name="provider">An instance of a type that derives from <see cref="AutoInputProtectionImageProvider"/> to be added to the collection.</param>
        public override void Add(ProviderBase provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            VerificationCodeImageProvider item = provider as VerificationCodeImageProvider;

            if (item == null)
                throw new ArgumentException("Errors.AIPImageProviderCollection_InvalidType", "provider");

            Add(item);
        }

        #region ICollection<AutoInputProtectionImageProvider> Members
        /// <summary>
        /// Adds the specified <paramref name="item"/> to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">The specified <paramref name="item"/> is <see langword="null"/>.</exception>
        /// <param name="item">The <see cref="AutoInputProtectionImageProvider"/> instance to be added to the collection.</param>
        public void Add(VerificationCodeImageProvider item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            base.Add(item);
        }

        /// <summary>
        /// Returns whether the specified <paramref name="item"/> is contained by the collection.
        /// </summary>
        /// <param name="item">The <see cref="AutoInputProtectionImageProvider"/> instance to check.</param>
        /// <returns><see langword="true">True</see> if the specified <paramref name="item"/> is contained by the collection; otherwise, 
        /// <see langword="false"/>.</returns>
        public bool Contains(VerificationCodeImageProvider item)
        {
            if (item == null)
                return false;

            foreach (VerificationCodeImageProvider provider in this)
                if (provider == item)
                    return true;

            return false;
        }

        /// <summary>
        /// Copies the entire collection to the specified <paramref name="array"/> starting at the specified <paramref name="arrayIndex"/>.
        /// </summary>
        /// <param name="array">An array of <see cref="AutoInputProtectionImageProvider"/> to which the collection will be copied.</param>
        /// <param name="arrayIndex">The index at which copying will begin.</param>
        public void CopyTo(VerificationCodeImageProvider[] array, int arrayIndex)
        {
            base.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets whether the collection is read-only.
        /// </summary>
        /// <value>Indicates whether the collection is read-only.  This property always returns <see langword="false"/>.</value>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the specified <paramref name="item"/> from the collection.
        /// </summary>
        /// <param name="item">The <see cref="AutoInputProtectionImageProvider"/> implementation to be removed.</param>
        /// <returns><see langword="true">True</see> if the specified <paramref name="item"/> is removed from the collection; otherwise, <see langword="false"/>.</returns>
        public bool Remove(VerificationCodeImageProvider item)
        {
            if (item == null)
                return false;

            bool contained = Contains(item);

            if (contained)
                base.Remove(item.Name);

            return contained;
        }
        #endregion

        #region IEnumerable<AutoInputProtectionImageProvider> Members
        /// <summary>
        /// Gets an object that can iterate over the entire collection of <see cref="AutoInputProtectionImageProvider"/> instances.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="AutoInputProtectionImageProvider"/> that can iterate over the entire collection.</returns>
        public new IEnumerator<VerificationCodeImageProvider> GetEnumerator()
        {
            foreach (VerificationCodeImageProvider provider in (System.Collections.IEnumerable)this)
                yield return provider;
        }
        #endregion
    }
}
