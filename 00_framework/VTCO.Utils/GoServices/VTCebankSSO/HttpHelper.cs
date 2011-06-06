using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace VTCO.Utils.GoServices.VTCebankSSO
{
    public  class HttpHelper
    {
        /// <summary>Send the Message to Merchant</summary>
        public static string GetStringHttpResponse(string url)
        {
            string response = null;
            try
            {
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

                myRequest.Method = "GET";
                //myRequest.ContentLength = data.Length;
                myRequest.CookieContainer = new CookieContainer();
                //myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentType = "text/xml; encoding='utf-8'";
                myRequest.KeepAlive = false;

                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(myResponse.GetResponseStream()))
                    {
                        if (reader != null)
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Graph API Errors or general web exceptions
                throw ex;
            }
            catch (Exception)
            { }

            return response;
        }

        /// <summary>Send the Message to Merchant</summary>
        public static object GetHttpResponse(string url)
        {
            object response = null;
            try
            {
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

                myRequest.Method = "GET";
                //myRequest.ContentLength = data.Length;
                myRequest.CookieContainer = new CookieContainer();
                //myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentType = "text/xml; encoding='utf-8'";
                myRequest.KeepAlive = false;

                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(myResponse.GetResponseStream()))
                    {
                        if (reader != null)
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Graph API Errors or general web exceptions 

                response = ex.Message;

            }
            catch (Exception)
            { }

            return response;
        }

        /// <summary>Send the Message to Merchant</summary>
        public static object GetJsonObject(string url)
        {
            object responseXml = null;
            try
            {
                // For development only, shouldn't be here on production

                CookieContainer cookie = new CookieContainer();
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "GET";
                //myRequest.ContentLength = data.Length;
                myRequest.CookieContainer = cookie;
                //myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentType = "text/xml; encoding='utf-8'";
                myRequest.KeepAlive = false;



                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    //  responseXml = JsonSerializer.DeserializeObject(myResponse.GetResponseStream());

                }
            }
            catch (WebException ex)
            {

                responseXml = ex.Message;

            }

            return responseXml;
        }

        /// <summary>
        ///    Classed used to bypass self-signed server certificate
        /// </summary>
        /// <remarks>
        ///     To be used in development only.
        /// </remarks>
        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
        {
            public TrustAllCertificatePolicy()
            { }

            public bool CheckValidationResult(ServicePoint sp,
              X509Certificate cert, WebRequest req, int problem)
            {
                return true;
            }
        }
    }
}
