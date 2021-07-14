using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        private RSAParameters _privateKey;
        private RSAParameters _publicKey;

        public string Encrypt(string plainText)
        {
            using (var csp = new RSACryptoServiceProvider(keyValue))
            {
                try
                {
                    _privateKey = csp.ExportParameters(true);
                    _publicKey = csp.ExportParameters(false);

                    csp.ImportParameters(_publicKey);

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

        public string Decrypt(string cypherText)
        {
            using (var csp = new RSACryptoServiceProvider(keyValue))
            {
                try
                {
                    _privateKey = csp.ExportParameters(true);
                    _publicKey = csp.ExportParameters(false);

                    var dataBytes = Convert.FromBase64String(cypherText);
                    csp.ImportParameters(_privateKey);
                    var plainText = csp.Decrypt(dataBytes, false);

                    return Encoding.Unicode.GetString(plainText);
                }
                finally
                {
                    csp.PersistKeyInCsp = false;
                }
            }
        }

        public static (string, string) GenerateKeyPair()
        {
            using (var csp = new RSACryptoServiceProvider(keyValue))
            {
                try
                {
                    string priv = Convert.ToBase64String(csp.ExportPkcs8PrivateKey());
                    string pub = Convert.ToBase64String(csp.ExportSubjectPublicKeyInfo());

                    //string hdr = "-----BEGIN RSA PRIVATE KEY-----";
                    //string ftr = "-----END RSA PRIVATE KEY-----";
                    //string PEM = $"{hdr}\n{priv}\n{ftr}";

                    //string hdr = "-----BEGIN RSA PUBLIC KEY-----";
                    //string ftr = "-----END RSA PUBLIC KEY-----";
                    //string PEM = $"{hdr}\n{priv}\n{ftr}";

                    return (priv, pub);
                }
                finally
                {
                    csp.PersistKeyInCsp = false;
                }
            }
        }
    }
}
