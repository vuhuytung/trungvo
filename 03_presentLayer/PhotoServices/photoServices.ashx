<%@ WebHandler Language="C#" Class="photoThumbnail" %>

using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Caching;
using System.Configuration;
using VTCO.Library;
using VTCO.Config;
using System.Linq;

public class photoThumbnail : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    //  ----- Copyright Philipos Sakellaropoulos 2002 -------
    // Modified by hoan.trinh 2008
    Image _img;
    ImageResize _ImageResize = new ImageResize();
    String _path;
    String _pathnoimage;
    String _CurrentDir;
    /// <summary>
    /// Service lấy ảnh từ server
    /// Các tham số đầu vào:
    /// name = tên ảnh                  (default:System.Configuration.ConfigurationManager.AppSettings["NoImageName"].ToString()
    /// w = độ rộng ảnh                 (default:168)
    /// h = chiều cao ảnh:              (default:168)
    /// f = fix theo kich thuoc anh     (default:0)
    /// </summary>
    /// <param name="context"></param>

    public void ProcessRequest(HttpContext context)
    {
        bool bFoundImages = false;
        string strSaveThumbnails = "";
        bool bSaveThumbnails = !(System.Configuration.ConfigurationManager.AppSettings["DefaultSaveThumbnails"] == "false");
        bool bFoundSaveThumbnails = false;

        int _iWidth = 168;
        int _iHeight = 168;
        int _iPercent = 100;
        string _sIsFix = string.Empty;
        int _iWidthFix = 0;
        int _iHeighFix = 0;

        // get width and height
        if (context.Request["w"] != null) _iWidth = Int32.Parse(context.Request["w"]);
        if (context.Request["h"] != null) _iHeight = Int32.Parse(context.Request["h"]);
        

        string _name = context.Request["name"] ?? "";
        string _type = (context.Request["type"] ?? "").ToLower();

        _pathnoimage = Global.Settings.ResourcesNoImage;
        string strImageSize = "";
        switch (_type)
        {
            case "logo":
                _path = Global.Settings.ResourcesPhotoLogo + _name;
                strImageSize = Global.Settings.ResourcesImageSizeLogo;
                break;
            case "product":
                _path = Global.Settings.ResourcesPhotoProduct + _name;
                strImageSize = Global.Settings.ResourcesImageSizeProduct;
                break;
            case "showproduct":
                _path = Global.Settings.ResourcesPhotoShowProduct + _name;
                strImageSize = Global.Settings.ResourcesImageSizeShowProduct;
                break;
            case "wantads":
                _path = Global.Settings.ResourcesPhotoWantAds + _name;
                strImageSize = Global.Settings.ResourcesImageSizeWantAds;
                break;
            case "news":
                _path = Global.Settings.ResourcesPhotoNews + _name;
                strImageSize = Global.Settings.ResourcesImageSizeNews;
                break;
            case "theme":
                _path = Global.Settings.ResourcesPhotoTheme + _name;
                strImageSize = Global.Settings.ResourcesImageSizeTheme;
                break;
            case "advertisement":
                _path = Global.Settings.ResourcesPhotoAdvertisement + _name;
                strImageSize = Global.Settings.ResourcesImageSizeAdvertisement;
                break;
            default:
                _path = _pathnoimage;
                break;
        }
        _path = _path.Replace("/", "\\");
        _pathnoimage = _pathnoimage.Replace("/", "\\");

        //File cache cua anh
        strSaveThumbnails = _path + "." + _iWidth.ToString() + "." + _iHeight.ToString() + "." + "cache";
        _iWidthFix = _iWidth;
        _iHeighFix = _iHeight;
        
        //Kiem tra File cache cua anh
        bFoundSaveThumbnails = File.Exists(strSaveThumbnails);

        // the thumbnail does not exist in cache, create it...
        // Create a bitmap of the thumbnail and show it
        if (bFoundSaveThumbnails && bSaveThumbnails)
        {

            try
            {
                bFoundImages = true;
                _img = Image.FromFile(strSaveThumbnails);
            }
            catch
            {
                bFoundImages = false;
                _img = Image.FromFile(_pathnoimage);
            }
        }
        else
        {
            Image orgImage = null;
            try
            {
                bFoundImages = true;
                orgImage = Image.FromFile(_path);
            }
            catch
            {
                bFoundImages = false;
                orgImage = Image.FromFile(_pathnoimage);
            }

            if (_iHeight == 0)
            {
                _iHeight = Convert.ToInt32(orgImage.Height * (_iWidth / (orgImage.Width * 1.0)));
            }
            else if (_iWidth == 0)
            {
                _iWidth = Convert.ToInt32(orgImage.Width * (_iHeight / (orgImage.Height * 1.0)));
            }
            else
            {
                if (orgImage.Width / (_iWidth * 1.0) > orgImage.Height / (_iHeight * 1.0))
                {
                    _iHeight = Convert.ToInt32(orgImage.Height * (_iWidth / (orgImage.Width * 1.0)));
                }
                else
                {
                    _iWidth = Convert.ToInt32(orgImage.Width * (_iHeight / (orgImage.Height * 1.0)));
                }
            }  

            // Hạn chế kích thước ảnh
            if (_iWidth <= 0 || _iWidth > 2560) _iWidth = 168;
            if (_iHeight <= 0 || _iHeight > 2560) _iHeight = 168;
            
            if (_iHeight > 0)
            {
                _img = _ImageResize.Crop(orgImage, _iWidth, _iHeight, ImageResize.AnchorPosition.Center);
            }
            else
            {
                _iPercent = (int)((float)_iWidth / ((float)orgImage.Width / 100));
                if (_iPercent > 100) _iPercent = 100;
                _img = _ImageResize.ScaleByPercent(orgImage, _iPercent);
            }
            orgImage.Dispose();
        }
        
        // let's cache this for 30 days
        context.Response.ContentType = "image/jpeg";
 
        System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
        EncoderParameters EncParms = new EncoderParameters(1);

        EncParms.Param = new EncoderParameter[]    
            {
                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L)
            };

        ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

        _img.Save(
            context.Response.OutputStream,
            ici, 
            EncParms
            );
        
        if (bFoundImages && !bFoundSaveThumbnails && bSaveThumbnails)
        {
            // Save thumbnail
            // Kiểm tra kích thước hiện tại có cho phép save ảnh thumbnail không
            strImageSize = strImageSize.Trim();
            if (strImageSize != "")
            {
                string[] arrImageSize = strImageSize.Split(',');
                string strWidthxHeight = _iWidthFix.ToString() + "x" + _iHeighFix.ToString();

                if (arrImageSize.Contains(strWidthxHeight))
                {
                    try
                    {
                        _img.Save(
                        strSaveThumbnails,
                        ici,
                        EncParms
                        );
                    }
                    catch { }
                }
            }
        }
        
        try
        {
            _img.Dispose();
        }
        catch { }
        
    }
    private ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        ImageCodecInfo[] encoders;

        encoders = ImageCodecInfo.GetImageEncoders();

        for (int j = 0; j < encoders.Length; ++j)
        {

            if (encoders[j].MimeType == mimeType)

                return encoders[j];

        }

        return null;

    }
    
    static public void RemovedCallback(String k, Object item, CacheItemRemovedReason r)
    {
        ((Bitmap)item).Dispose();
        //LogMessage("Callback");
    }

    // for custom tracing, normal tracing does not work with WebHandlers
    static void LogMessage(String mess)
    {
        StreamWriter sw = new StreamWriter("c:\\ASP.NET_log.txt", true);
        sw.WriteLine(mess);
        sw.Close();
    }

    public bool IsReusable
    {
        get { return true; }
    }
}