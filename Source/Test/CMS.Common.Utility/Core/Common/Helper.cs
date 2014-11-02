namespace CMS.Common.Utility.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.IO;


    public static class Helper
    {
        public static string GetMd5Hash(string input)    
        {        // Create a new instance of the MD5CryptoServiceProvider object.        
            MD5 md5Hasher = MD5.Create();        
            // Convert the input string to a byte array and compute the hash.        
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));        
            // Create a new Stringbuilder to collect the bytes        
            // and create a string.        
            StringBuilder sBuilder = new StringBuilder();        
            // Loop through each byte of the hashed data         
            // and format each one as a hexadecimal string.        
            for (int i = 0; i < data.Length; i++)        
            {           
                sBuilder.Append(data[i].ToString("x2"));        
            }        
            // Return the hexadecimal string.        
            return sBuilder.ToString();    
        }
        public static bool VerifyMd5Hash(string input, string hash)    
        {        
            // Hash the input.        
            string hashOfInput = GetMd5Hash(input);        
            // Create a StringComparer an comare the hashes.        
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;        
            if (0 == comparer.Compare(hashOfInput, hash))        
            {            
                return true;        
            }        
            else        
            {            
                return false;        
            }    
        }

        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt); 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey); 
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey); 
            MemoryStream ms = new MemoryStream(); 
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write); 
            
            cs.Write(inputByteArray, 0, inputByteArray.Length); 
            cs.FlushFinalBlock(); 
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            } 
            
            ret.ToString(); return ret.ToString();
        }

        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2]; 
            for (int x = 0; x < pToDecrypt.Length / 2; x++) 
            { 
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16)); 
                inputByteArray[x] = (byte)i; 
            } 
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey); 
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey); 
            MemoryStream ms = new MemoryStream(); 
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write); 
            cs.Write(inputByteArray, 0, inputByteArray.Length); 
            cs.FlushFinalBlock(); 
            StringBuilder ret = new StringBuilder(); 
            
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}
