using DES_Implementation.DES.Consts;
using DES_Implementation.DES.Enums;

namespace DES_Implementation.DES.Helpers
{
    public class Cryptography : CryptoExtensions
    {
        public string Decrypt(string plainText, string key)
        {
            var IP = CryptoConsts.GetConsts(Permutation.IP);
            var IP1 = CryptoConsts.GetConsts(Permutation.IPInverse);
            
            string[] keys = GetAllKeys(key);

            plainText = ApplyPermutation(IP, plainText);

            for (int i = 15; i > -1; i--)
                plainText = ApplyFunction(plainText, keys[i]);

            plainText = plainText[8..16] + plainText[0..8];
            plainText = ApplyPermutation(IP1, plainText);
            return plainText;
        }
        public string Encrypt(string plainText, string key)
        {
            var IP = CryptoConsts.GetConsts(Permutation.IP);
            var IP1 = CryptoConsts.GetConsts(Permutation.IPInverse);

            string[] keys = GetAllKeys(key);
            plainText = ApplyPermutation(IP, plainText);

            for (int i = 0; i < 16; i++)
                plainText = ApplyFunction(plainText, keys[i]);

            plainText = plainText[8..16] + plainText[0..8];
            plainText = ApplyPermutation(IP1, plainText);
            return plainText;
        }
    }
}
