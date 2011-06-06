﻿//
// Author:      hoan.trinh
// Create Date: 2010-01-08
// Description: Các hàm xử lý chung
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace VTCO.Library
{
    public class Lib
    {
        /// <summary>
        /// Lấy giá trị của Property của object
        /// </summary>
        /// <param name="obj">object chứa property</param>
        /// <param name="property">tên property</param>
        /// <returns></returns>
        public static object GetProperty(object obj, string property)
        {
            var objPro = obj.GetType().GetProperty(property);
            if (objPro == null) return null;
            return objPro.GetValue(obj, null);
        }
        /// <summary>
        /// Format FulltextSearch
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatFullTextSearch(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                while (value.IndexOf("  ") != -1)
                {
                    value = value.Replace("  ", " ");
                }
            }
            value = value.Trim();
            bool isNhayKeps = false;
            List<string> lstWord = new List<string>();
            List<string> lstAND = new List<string>();
            string str = "";
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '"')
                {
                    if (!isNhayKeps)
                    {
                        if (!string.IsNullOrEmpty(str.Trim()))
                        {
                            lstAND.Add(str.Trim());
                        }
                        str = value[i].ToString();
                        isNhayKeps = true;
                    }
                    else
                    {
                        str = str.Trim() + value[i];
                        if (str.Length > 2)
                        {
                            lstWord.Add(str);
                        }
                        isNhayKeps = false;
                        str = "";
                    }
                }
                else
                {
                    str += value[i];
                }
            }
            str = str.Trim();
            if (!string.IsNullOrEmpty(str))
            {
                if (str.StartsWith("\""))
                {
                    if (!str.EndsWith("\""))
                    {
                        str += '"';
                        lstWord.Add(str);
                    }
                }
                else
                {
                    lstAND.Add(str);
                }
            }
            string strRet = "";

            foreach (string s in lstAND)
            {
                foreach (string s1 in s.Split(' '))
                {
                    lstWord.Add('"' + s1 + '"');
                }
            }

            foreach (string s in lstWord.Distinct())
            {
                strRet += s + " AND ";
            }
            if (!string.IsNullOrEmpty(strRet))
            {
                strRet = strRet.Remove(strRet.Length - 5);
            }
            return strRet;
        }

        /// <summary>
        /// Lấy ngày tháng từ xâu ngày tháng theo chuẩn Việt Nam
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? GetDateTime(string value)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value)) return null;
            string[] arr = value.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 3) return null;
            int iDay = 0, iMonth = 0, iYear = 0;
            try { iDay = Convert.ToInt32(arr[0]); }
            catch { return null; }
            try { iMonth = Convert.ToInt32(arr[1]); }
            catch { return null; }
            try { iYear = Convert.ToInt32(arr[2]); }
            catch { return null; }
            try
            {
                DateTime dt = new DateTime(iYear, iMonth, iDay);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Thay thế các kí tự đặc biệt thành các ảnh Emotion
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string ReplaceEmotion(string Input)
        {
            string strTemp = string.Empty;
            string strReturn = string.Empty;
            foreach (char c in Input)
            {
                strReturn += c;
                strTemp += c;
                if (strTemp.IndexOf(":(") > -1)
                {
                    strReturn = strReturn.Replace(":(", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/2.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(";;)") > -1)
                {
                    strReturn = strReturn.Replace(";;)", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/5.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(";)") > -1)
                {
                    strReturn = strReturn.Replace(";)", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/3.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":D") > -1)
                {
                    strReturn = strReturn.Replace(":D", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/4.gif' />");
                    strTemp = string.Empty;
                }

                if (strTemp.IndexOf(":-/") > -1)
                {
                    strReturn = strReturn.Replace(":-/", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/6.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":x") > -1)
                {
                    strReturn = strReturn.Replace(":x", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/7.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":P") > -1)
                {
                    strReturn = strReturn.Replace(":P", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/8.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":*") > -1)
                {
                    strReturn = strReturn.Replace(":*", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/9.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf("=((") > -1)
                {
                    strReturn = strReturn.Replace("=((", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/10.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":o") > -1)
                {
                    strReturn = strReturn.Replace(":o", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/11.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf("B-)") > -1)
                {
                    strReturn = strReturn.Replace("B-)", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/13.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":-S") > -1)
                {
                    strReturn = strReturn.Replace(":-S", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/14.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":|") > -1)
                {
                    strReturn = strReturn.Replace(":|", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/16.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf("@-)") > -1)
                {
                    strReturn = strReturn.Replace("@-)", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/15.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":^)") > -1)
                {
                    strReturn = strReturn.Replace(":^)", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/12.gif' />");
                    strTemp = string.Empty;
                }
                if (strTemp.IndexOf(":)") > -1)
                {
                    strReturn = strReturn.Replace(":)", "<img src='/plugin/editor/tiny_mce/plugins/emotions/img/1.gif' />");
                    strTemp = string.Empty;
                }
            }
            return strReturn;
        }

        private const string URL_CHARS_UNICODE
            = "AÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴBCDĐEÉÈẸẺẼÊẾỀỆỂỄFGHIÍÌỊỈĨJKLMNOÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠPQRSTUÚÙỤỦŨƯỨỪỰỬỮVWXYÝỲỴỶỸZaáàạảãâấầậẩẫăắằặẳẵbcdđeéèẹẻẽêếềệểễfghiíìịỉĩjklmnoóòọỏõôốồộổỗơớờợởỡpqrstuúùụủũưứừựửữvwxyýỳỵỷỹz0123456789_";
        private const string URL_CHARS_ANSI
            = "AAAAAAAAAAAAAAAAAABCDDEEEEEEEEEEEEFGHIIIIIIJKLMNOOOOOOOOOOOOOOOOOOPQRSTUUUUUUUUUUUUVWXYYYYYYZaaaaaaaaaaaaaaaaaabcddeeeeeeeeeeeefghiiiiiijklmnoooooooooooooooooopqrstuuuuuuuuuuuuvwxyyyyyyz0123456789_";
        private const string URL_CHARS_BASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";

        /// <summary>
        /// Hàm Get URL Text của 1 xâu
        /// Mục đích: phục vụ cho SEO
        /// </summary>
        /// <param name="plainText">Xâu dữ liệu đầu vào</param>
        /// <returns>xâu dữ liệu đầu ra dưới dạng URL text</returns>
        public static string GetUrlText(string plainText)
        {
            int iLength = plainText.Length;
            StringBuilder sBuilder = new StringBuilder(plainText);
            int iIndex = 0;
            // Loại bỏ các ký tự có dấu
            for (int i = 0; i < iLength; i++)
            {
                iIndex = URL_CHARS_UNICODE.IndexOf(plainText[i]);
                if (iIndex == -1)
                    sBuilder[i] = plainText[i];
                else
                    sBuilder[i] = URL_CHARS_ANSI[iIndex];
            }

            // Loại bỏ các ký tự lạ
            for (int i = 0; i < iLength; i++)
            {
                if (URL_CHARS_BASE.IndexOf(sBuilder[i]) == -1)
                {
                    sBuilder[i] = '-';
                }
            }

            // Trim các ký tự thừa "-"
            string strTemp = sBuilder.ToString();
            strTemp = strTemp.Trim('-');

            while (strTemp.IndexOf("--") != -1)
            {
                strTemp = strTemp.Replace("--", "-");
            }
            if (strTemp.Length > 60)
            {
                int _i = strTemp.IndexOf('-', 59);
                if (_i != -1)
                {
                    strTemp = strTemp.Substring(0, _i);
                }
            }

            return strTemp.ToLower();
        }
        /// <summary>
        /// Hàm lấy xâu định dạng theo kiểu tiền tệ: 1234123 --> 1,234,123
        /// </summary>
        /// <param name="argValue"></param>
        /// <returns></returns>
        public static string FormatMoney(long argValue)
        {
            var _comma = (1 / 2.0).ToString().Substring(1, 1);
            var _digit = ".";
            if (_comma == ".")
            {
                _digit = ",";
            }
            var _sSign = "";
            if (argValue < 0)
            {
                _sSign = "-";
                argValue = -argValue;
            }
            var _sTemp = "" + argValue;
            var _index = _sTemp.IndexOf(_comma);
            
            var _digitExt = "";
            if (_index != -1)
            {
                _digitExt = _sTemp.Substring(_index + 1);
                _sTemp = _sTemp.Substring(0, _index);
            }

            var _sReturn = "";
            while (_sTemp.Length > 3)
            {
                _sReturn = _digit + _sTemp.Substring(_sTemp.Length - 3) + _sReturn;
                _sTemp = _sTemp.Substring(0, _sTemp.Length - 3);
            }
            _sReturn = _sSign + _sTemp + _sReturn;
            if (_digitExt.Length > 0)
            {
                _sReturn += _comma + _digitExt;
            }
            return _sReturn;
        }

        /// <summary>
        /// Hàm đọc nội dung File
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFile(string filePath)
        {
            System.IO.StreamReader streamReader = null;
            try
            {
                streamReader = new System.IO.StreamReader(filePath);
                return streamReader.ReadToEnd();
            }
            finally
            {
                streamReader.Close();
            }
        }

        public static string SubString(string value,int  length,string extend)
        {
            if (value.Length < length) return value;
            return value.Substring(0,1) + extend;
        }

    }
}
