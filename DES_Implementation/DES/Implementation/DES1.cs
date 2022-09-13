using DES_Implementation.DES.Helpers;
using DES_Implementation.DES.Interfaces;

namespace DES_Implementation.DES.Implementation
{
    public class DES1 : IDES
    {
        private readonly string key;

        public DES1(string key)
        {
            this.key = key;
        }
        public string Encrypt(string data) => new Cryptography().Encrypt(data, key);
        public string Decrypt(string data) => new Cryptography().Decrypt(data, key);
    }
}
