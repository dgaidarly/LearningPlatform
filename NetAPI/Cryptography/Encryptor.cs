using System.Security.Cryptography;

namespace VieJSLearning.Cryptography
{
    public class Encryptor
    {
        private static Encryptor instance;

        private Encryptor()
        {
            
        }

        public static Encryptor Instance => instance ?? (instance = new Encryptor());

        public string GetEncryptedPass(string pass)
        {
            var hardwareKey = HardwareKeyGenerator.GetValue();
            using (var md5Hash = MD5.Create())
            {
                return md5Hash.GetMd5Hash(hardwareKey, pass);
            }
        }
    }
}
