using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SpamLib
{
    class PasswordEncoder
    {
        //private RSACryptoServiceProvider Provider;

        //public static string Encode(string input)
        //{
        //    Provider = new RSACryptoServiceProvider();
        //    Provider.ImportParameters("pass");
        //    byte[] encrypted = Provider.Encrypt(Encoding.UTF8.GetBytes(input), true);
            
        //    //return new string(pwd.Select(c => (char)(c + key)).ToArray());
        //}

        //public static string Decode(string pwd)
        //{
        //    Provider = new RSACryptoServiceProvider();
        //    return Encoding.UTF8.GetString(Provider.Decrypt(encrypted, true));
        //    //return new string(pwd.Select(c => (char)(c - key)).ToArray());
        //}
    }
}
