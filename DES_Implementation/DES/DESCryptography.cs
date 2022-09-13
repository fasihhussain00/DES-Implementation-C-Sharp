using DES_Implementation.DES.Implementation;
using DES_Implementation.DES.Interfaces;

namespace DES_Implementation.DES
{
    public class DESCryptography
    {
        public static IDES DES(string key) => new DES1(key);
        public static IDES DES2(string key1, string key2) => new DES2(key1, key2);
        public static IDES DES3(string key1, string key2, string key3) => new DES3(key1, key2, key3);
    }
}
