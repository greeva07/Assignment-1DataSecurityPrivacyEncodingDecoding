using Assignment_1DataSecurityPrivacyEncodingDecoding.models;
using System;
using System.Linq;
using System.Text;

namespace Assignment_1DataSecurityPrivacyEncodingDecoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your full name:");
            string fullname = Console.ReadLine();
            Console.WriteLine("\n");

            BinaryConverter binaryObject = new BinaryConverter();
            string binaryData = binaryObject.ConvertTo(fullname);
            Console.WriteLine($"Binary of {fullname} = {binaryData}");
            string binaryData1 = binaryObject.ConvertBinaryToString(binaryData);
            Console.WriteLine($"Binary {binaryData} = original string {binaryData1}");
            Console.WriteLine("\n");

            HexadecimalConverter hexadecimalObject = new HexadecimalConverter();
            string hexadecimalData = hexadecimalObject.ConvertTo(fullname);
            Console.WriteLine($"Hexadecimal of {fullname} = {hexadecimalData}");
            string hexadecimalData1 = hexadecimalObject.ConveryFromHexToASCII(hexadecimalData);
            Console.WriteLine($"Hexadecimal of original string = {hexadecimalData1}");
            Console.WriteLine("\n");

            Base64Converter base64Object = new Base64Converter();
            string base64Data = base64Object.Base64Encode(fullname);
            Console.WriteLine($"Base64 of string {fullname} = {base64Data}");
            string base64Data1 = base64Object.Base64StringDecode(base64Data);
            Console.WriteLine($"Base64 decode of string {base64Data} = {base64Data1}");
            Console.WriteLine("\n");


            string plaintext = fullname;
            int encryptionDepth = 20;

            int[] key = Encoding.Unicode.GetBytes(plaintext).Select(x => Convert.ToInt32(x)).ToArray(); //Notice the use of Unicode
            for (int i = 0; i < key.Length; i++)
            {
                //Console.WriteLine(key[i]);
            }
            //Console.WriteLine("\n\n");
            string cipherasString = String.Join(",", key.Select(x => x.ToString())); //For display purposes
            Encrypter encrypter = new Encrypter(plaintext, key, encryptionDepth);
            //Single Level Encrytion
            string nameEncryptWithCipher = Encrypter.EncryptWithCipher(plaintext, key);
            Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");
            string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, key);
            Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");
            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(plaintext, key, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");
            
            Console.WriteLine("\n");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, key, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");
            //Base64 Encoded
            Console.WriteLine($"Base64 encoded {plaintext} {encrypter.Base64}");
            string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");
        }
    }
}
