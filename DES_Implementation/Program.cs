using DES_Implementation.DES;

main();

int main()
{
    string text = "123456ABCD132536";
    string key = "AABB09182736CCDD";
    string key2 = "AABB09485737CCDD";
    string key3 = "AABB09485737CFDF";
    
    InitialHeadings(text, key, key2, key3);

    DES1(text, key);
    DES2(text, key, key2);
    DES3(text, key, key2, key3);

    Console.ReadLine();
    return 0;
}

void InitialHeadings(string text, string key, string key2, string key3)
{
    Console.WriteLine("Original Text : {0}", text);
    Console.WriteLine();
    Console.WriteLine("Key 1 : {0}", key);
    Console.WriteLine("Key 2 : {0}", key2);
    Console.WriteLine("Key 3 : {0}", key3);
    Console.WriteLine();
}

void DES1(string text, string key)
{
    var Des = DESCryptography.DES(key);
    Console.WriteLine("===============Encryption With DES===============");
    Console.WriteLine();
    var DESCypherText = Des.Encrypt(text);
    var DESPlainText = Des.Decrypt(DESCypherText);

    Console.WriteLine("Cypher Text with DES Encryption {0}", DESCypherText);
    Console.WriteLine("Cypher Text with DES Decryption {0}", DESPlainText);
    Console.WriteLine();

}

void DES2(string text, string key, string key2)
{
    var Des2 = DESCryptography.DES2(key, key2);

    Console.WriteLine("==============Encryption With DES 2================");
    Console.WriteLine();

    var DES2CypherText = Des2.Encrypt(text);
    var DES2PlainText = Des2.Decrypt(DES2CypherText);

    Console.WriteLine("Cypher Text with DES 2 Encryption {0}", DES2CypherText);
    Console.WriteLine("Cypher Text with DES 2 Decryption {0}", DES2PlainText);
    Console.WriteLine();
}

void DES3(string text, string key, string key2, string key3)
{
    var Des3 = DESCryptography.DES3(key, key2, key3);

    Console.WriteLine("==============Encryption With DES 3================");
    Console.WriteLine();

    var DES3CypherText = Des3.Encrypt(text);
    var DES3PlainText = Des3.Decrypt(DES3CypherText);

    Console.WriteLine("Cypher Text with DES 3 Encryption {0}", DES3CypherText);
    Console.WriteLine("Cypher Text with DES 3 Decryption {0}", DES3PlainText);
    Console.WriteLine();

}