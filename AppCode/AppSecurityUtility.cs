using System.Security.Cryptography;
using System.Text;

namespace AppsecurityWithSaltAndHash.AppCode
{
    public class AppSecurityUtility
    {
        private static AppSecurityUtility? _instance;
        public static AppSecurityUtility Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSecurityUtility();
                return _instance;
            }
        }
        public byte[] GenerateSalt(int userDefinedSize)
        {
            byte[] saltBytes = new byte[userDefinedSize];
#pragma warning disable SYSLIB0023
            using (var rSACryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rSACryptoServiceProvider.GetBytes(saltBytes);
            }
#pragma warning restore SYSLIB0023
            return saltBytes;
        }
        public string HashAlgorithm(string password, int lengthOfSaltSize, HashAlgorithm hashAlgorithm)
        {
            byte[] RandomSaltByte = GenerateSalt(lengthOfSaltSize);
            byte[] saltBytes = Encoding.UTF8.GetBytes(password);
            List<byte> combileByte = new List<byte>();
            combileByte.AddRange(RandomSaltByte);
            combileByte.AddRange(saltBytes);
            byte[] result = hashAlgorithm.ComputeHash(combileByte.ToArray());
            return Convert.ToBase64String(result);
        }
    }
}
