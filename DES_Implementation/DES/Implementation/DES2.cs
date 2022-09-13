﻿using DES_Implementation.DES.Helpers;
using DES_Implementation.DES.Interfaces;

namespace DES_Implementation.DES.Implementation
{
    public class DES2 : IDES
    {
        private readonly string key1;
        private readonly string key2;

        public DES2(string key1, string key2)
        {
            this.key1 = key1;
            this.key2 = key2;
        }
        public string Encrypt(string data) => new Cryptography().Encrypt(new Cryptography().Encrypt(data, key1), key2);
        public string Decrypt(string data) => new Cryptography().Decrypt(new Cryptography().Decrypt(data, key2), key1);
    }
}
