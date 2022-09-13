
using DES_Implementation.DES.Helpers;
using DES_Implementation.DES.Interfaces;

namespace DES_Implementation.DES.Implementation
{
    public class DES3 : IDES
    {
        private readonly string key1;
        private readonly string key2;
        private readonly string key3;

        public DES3(string key1, string key2, string key3)
        {
            this.key1 = key1;
            this.key2 = key2;
            this.key3 = key3;
        }
        public string Encrypt(string data) => new Cryptography().Encrypt(new Cryptography().Decrypt(new Cryptography().Encrypt(data, key1), key2), key3);
        public string Decrypt(string data) => new Cryptography().Decrypt(new Cryptography().Encrypt(new Cryptography().Decrypt(data, key3), key2), key1);
    }
}
