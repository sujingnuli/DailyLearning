using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Clz
{
    /// <summary>
    /// 对称算法，非对称算法生成密钥
    /// 一个简单的帮助类，因为后面的加密，解密算法要用到。
    /// </summary>
    public class KeyGenerator
    {
        /// <summary>
        /// 随机生成密钥
        /// </summary>
        /// <typeparam name="T">密钥(base64格式)</typeparam>
        /// <param name="key">iv向量(base64格式)</param>
        /// <param name="iv">要生成的KeySize,每8个byte是一个字节</param>
        /// <param name="keySize"></param>
        public static void CreateSymmetricAlgorithmKey<T>(out string key, out string iv, int keySize) where T : SymmetricAlgorithm, new()
        {
            using (T t = new T()) { 
#if DEBUG
                Console.WriteLine(string.Join("", t.LegalKeySizes.Select(k => string.Format("MinSize:{0} MaxSize:{1} SkipSize:{2}", k.MinSize, k.MaxSize, k.SkipSize))));

#endif
                t.KeySize = keySize;
                t.GenerateIV();
                t.GenerateKey();
                iv = Convert.ToBase64String(t.IV);
                key = Convert.ToBase64String(t.Key);
            }
        }
        /// <summary>
        /// 随机生成密钥(非对称算法)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="publicKey">公钥(Xml格式)</param>
        /// <param name="privateKey">私钥(Xml格式)</param>
        /// <param name="provider">用于生成密钥的非对称算法实现，因为非对称算法长度需要在构造函数中传入，这里只传入算法表</param>
        public static void CreateAsymmetricAlgorithmKey<T>(out string publicKey, out string privateKey, T provider = null) where T : AsymmetricAlgorithm, new() {
            if (provider == null) {
                provider = new T();
            }
            using (provider) { 
#if DEBUG
                Console.WriteLine(string.Join(" ", provider.LegalKeySizes.Select(k => string.Format("MinSize:{0} MaxSize:{1} SkipSize:{2}", k.MinSize, k.MaxSize, k.SkipSize))));

#endif
                publicKey = provider.ToXmlString(false);
                privateKey = provider.ToXmlString(true);
            }
        }

        private void test() {
            string key, iv;
            KeyGenerator.CreateSymmetricAlgorithmKey<TripleDESCryptoServiceProvider>(out key, out iv, 128);
            Console.WriteLine(key.Length);
            KeyGenerator.CreateSymmetricAlgorithmKey<TripleDESCryptoServiceProvider>(out key, out iv, 192);
            Console.WriteLine(key.Length);

            string privateKey, publicKey;
            for (var i = 800; i < 2000; i += 8)
            {
                using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider(i))
                {
                    KeyGenerator.CreateAsymmetricAlgorithmKey<RSACryptoServiceProvider>(out publicKey, out privateKey, provider);
                    Console.WriteLine(privateKey.Length);
                }
            }  
        }

    }
}
