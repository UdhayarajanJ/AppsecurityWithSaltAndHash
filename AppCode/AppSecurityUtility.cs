using AppsecurityWithSaltAndHash.Entity;
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
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return saltBytes;
        }
        public HashAndSalt HashAlgorithm(string password, int lengthOfSaltSize, HashAlgorithm hashAlgorithm)
        {
            byte[] RandomSaltByte = GenerateSalt(lengthOfSaltSize);
            byte[] passwordByte = Encoding.UTF8.GetBytes(password);
            List<byte> combileByte = new List<byte>();
            combileByte.AddRange(RandomSaltByte);
            combileByte.AddRange(passwordByte);
            byte[] result = hashAlgorithm.ComputeHash(combileByte.ToArray());
            return new HashAndSalt(Convert.ToBase64String(RandomSaltByte), Convert.ToBase64String(result));
        }
    }
}
