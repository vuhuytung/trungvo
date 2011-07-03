//
// Create by:   Hoan.Trinh@vtc.vn
// Create Date: 2008.11.08
// Purpose:     Mã hóa dữ liệu
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using VTCO.Config;

namespace VTCO.Encrypt
{
    /// <summary>
    /// Thực hiện việc mã hóa dữ liệu
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Mã hóa MD5 (mã hóa dữ liệu 1 chiều)
        /// </summary>
        /// <param name="_strValue">Xâu cần mã hóa</param>
        /// <returns></returns>
        public static string GetMD5UTF8(string _strValue)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = UTF8Encoding.Default.GetBytes(_strValue);
            encodedBytes = md5.ComputeHash(originalBytes);
            
            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes).ToLower().Replace("-", "");
        }
        /// <summary>
        /// Mã hóa MD5 (mã hóa dữ liệu 1 chiều)
        /// </summary>
        /// <param name="_strValue">Xâu cần mã hóa</param>
        /// <returns></returns>
        public static string GetMD5(string _strValue)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            originalBytes = System.Text.ASCIIEncoding.Default.GetBytes(_strValue);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }


        /// <summary>
        /// Tạo đối tượng RSACryptoServiceProvider
        /// </summary>
        /// <returns></returns>
        public static RSACryptoServiceProvider CreateRSACryptoServiceProvider()
        {
            const int PROVIDER_RSA_FULL = 1;
            const string CONTAINER_NAME = "VTCOnlinePassContainerKey";
            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;
            cspParams.Flags = CspProviderFlags.UseUserProtectedKey;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            return new RSACryptoServiceProvider(cspParams);
        }
        /// <summary>
        /// Mã hóa dữ liệu theo RSA. KeyFile:publickey.xml
        /// </summary>
        /// <param name="_dataEncrypt">Dữ liệu cần mã hóa</param>
        /// <returns>Dữ liệu đã mã hóa</returns>
        public static string RsaEncrypt(string _dataEncrypt)
        {
            RSACryptoServiceProvider rsa = CreateRSACryptoServiceProvider();
            StreamReader reader = new StreamReader(SettingSingleton.Instance.KeyPath + "publickey.xml");
            string publicOnlyKeyXML = reader.ReadToEnd();
            rsa.FromXmlString(publicOnlyKeyXML);
            reader.Close();

            //read plaintext, encrypt it to ciphertext

            byte[] plainbytes = System.Text.Encoding.UTF8.GetBytes(_dataEncrypt);
            byte[] cipherbytes = rsa.Encrypt(plainbytes, false);
            return Convert.ToBase64String(cipherbytes);
        }
        /// <summary>
        /// Giải mã dữ liệu theo RSA. KeyFile:privatekey.xml
        /// </summary>
        /// <param name="_dataDecrypt"></param>
        /// <returns></returns>
        public static string RsaDecrypt(string _dataDecrypt)
        {
            RSACryptoServiceProvider rsa = CreateRSACryptoServiceProvider();
            byte[] cipherbytes = Convert.FromBase64String(_dataDecrypt);

            StreamReader reader = new StreamReader(SettingSingleton.Instance.KeyPath + "privatekey.xml");
            string publicPrivateKeyXML = reader.ReadToEnd();
            rsa.FromXmlString(publicPrivateKeyXML);
            reader.Close();

            //read ciphertext, decrypt it to plaintext
            byte[] plain = rsa.Decrypt(cipherbytes, false);
            return System.Text.Encoding.UTF8.GetString(plain);

        }

        /// <summary>
        /// Tạo RSA Key
        /// Phương thức này chỉ sử dụng cho trường hợp tạo key RSA lần đầu tiên
        /// </summary>
        public static void CreateRSAKey()
        {
            if (!System.IO.Directory.Exists(Global.Settings.KeyPath))
            {
                System.IO.Directory.CreateDirectory(Global.Settings.KeyPath);
            }
            RSACryptoServiceProvider rsa = CreateRSACryptoServiceProvider();
            //provide public and private RSA params
            StreamWriter writer = new StreamWriter(Global.Settings.KeyPath + "privatekey.xml");
            string publicPrivateKeyXML = rsa.ToXmlString(true);
            writer.Write(publicPrivateKeyXML);
            writer.Close();

            //provide public only RSA params
            writer = new StreamWriter(Global.Settings.KeyPath + "publickey.xml");
            string publicOnlyKeyXML = rsa.ToXmlString(false);
            writer.Write(publicOnlyKeyXML);
            writer.Close();
        }
       
    }
}
