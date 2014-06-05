namespace ToBeImplemented.Service.Implementations
{
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using ToBeImplemented.Service.Interfaces;

    public class Md5UserPasswordHasher : IUserPasswordHasher
    {
        public string GetHash(string text, string salt)
        {
            var bytes = Encoding.Default.GetBytes(text + salt);
            var md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            string result;
            using (var memory = new MemoryStream(bytes))
            {
                byte[] hash = md5.ComputeHash(memory);
                StringBuilder sb = new StringBuilder();
                hash.ToList().ForEach(x => sb.AppendFormat("{0:X2}", x));
                result = sb.ToString();
            }

            return result;

        }
    }
}