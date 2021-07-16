using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSA
{
    public class RsaEncryption
    {
        private static int keyValue;

        public static int KeyValue
        {
            get { return keyValue; }
            set
            {
                if (value >= 512)
                {
                    keyValue = value;
                }
                else
                {
                    keyValue = 2048;
                }
            }
        }

        public static (string, string) GenerateKeyPair()
        {
            using (var csp = new RSACryptoServiceProvider(keyValue))
            {
                try
                {
                    string priv = Convert.ToBase64String(csp.ExportRSAPrivateKey());
                    string pub = Convert.ToBase64String(csp.ExportRSAPublicKey());

                    return (priv, pub);
                }
                finally
                {
                    csp.PersistKeyInCsp = false;
                }
            }
        }

        public static string Encrypt(string plainText, string publicKey)
        {
            using (var csp = new RSACryptoServiceProvider())
            {
                try
                {
                    csp.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out int bytesRead);

                    var data = Encoding.Unicode.GetBytes(plainText);
                    var cypher = csp.Encrypt(data, false);

                    return Convert.ToBase64String(cypher);
                }
                finally
                {
                    csp.PersistKeyInCsp = false;
                }
            }
        }

        public static string Decrypt(string cypherText, string privateKey)
        {
            using (var csp = new RSACryptoServiceProvider())
            {
                try
                {
                    csp.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out int bytesRead);

                    var dataBytes = Convert.FromBase64String(cypherText);
                    var plainText = csp.Decrypt(dataBytes, false);

                    return Encoding.Unicode.GetString(plainText);
                }
                finally
                {
                    csp.PersistKeyInCsp = false;
                }
            }
        }
    }
}
