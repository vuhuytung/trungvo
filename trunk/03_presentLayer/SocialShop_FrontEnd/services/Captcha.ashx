<%@ WebHandler Language="C#" Class="Captcha" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Web.SessionState;

public class Captcha : IHttpHandler, IRequiresSessionState
{
    #region Constant
    private const int CODE_LENGTH = 6;
    private const int IMAGE_HEIGHT = 30;
    private const int IMAGE_WIDTH = 150;
    private const string FONT_NAME = "arial";
    #endregion
    
    public void ProcessRequest (HttpContext context) {        
        context.Response.ContentType = "image/png";
        Bitmap bmPhoto = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
        Graphics grPhoto = Graphics.FromImage(bmPhoto);

        grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBilinear;
        grPhoto.CompositingQuality = CompositingQuality.HighQuality;
        grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

        Rectangle rect = new Rectangle(0, 0, IMAGE_WIDTH, IMAGE_HEIGHT);
        HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.Black);
        grPhoto.FillRectangle(hatchBrush, rect);

        string strText = getRandomCode();
        
        // Lưu text vào session
        context.Session[VTCO.Config.Constants.SESSION_IMAGE_CODE] = strText;
        
        // Set up the text font.
        SizeF size;
        float fontSize = rect.Height + 1;        
        Font font;
        // Adjust the font size until the text fits within the image.
        do
        {
            fontSize--;
            font = new Font(FONT_NAME, fontSize, FontStyle.Bold);
            size = grPhoto.MeasureString(strText, font);
            
        } while (size.Width > rect.Width);
        // Set up the text format.
        StringFormat format = new StringFormat();
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;

        // Create a path using the text and warp it randomly.
        GraphicsPath path = new GraphicsPath();
        path.AddString(strText, font.FontFamily, (int)font.Style, font.Size, rect, format);

        Random r = new Random();
        float v = 4F;
        PointF[] points =
			{
				new PointF(r.Next(rect.Width) / v, r.Next(rect.Height) / v),
				new PointF(rect.Width - r.Next(rect.Width) / v, r.Next(rect.Height) / v),
				new PointF(r.Next(rect.Width) / v, rect.Height - r.Next(rect.Height) / v),
				new PointF(rect.Width - r.Next(rect.Width) / v, rect.Height - r.Next(rect.Height) / v)
			};
        Matrix matrix = new Matrix();
        matrix.Translate(0F, 0F);
        path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

        // Draw the text.
        hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.LightGray, Color.DarkGray);
        grPhoto.FillPath(hatchBrush, path);

        // Add some random noise.
        int m = Math.Max(rect.Width, rect.Height);
        for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
        {
            int x = r.Next(rect.Width);
            int y = r.Next(rect.Height);
            int w = r.Next(m / 50);
            int h = r.Next(m / 50);
            grPhoto.FillEllipse(hatchBrush, x, y, w, h);
        }

        // Clean up.
        font.Dispose();
        hatchBrush.Dispose();
        grPhoto.Dispose();
        
        MemoryStream memorystream = new MemoryStream();
        bmPhoto.Save(memorystream, System.Drawing.Imaging.ImageFormat.Png);
        memorystream.WriteTo(context.Response.OutputStream);
        bmPhoto.Dispose();
        memorystream.Close();
        memorystream.Dispose();
    }
    
    public string getRandomCode()
    {
        string strCode = "";
        string strRandomCode = "";
        for (char ch = 'a'; ch <= 'z'; ch++)
        {
            strCode += ch;
            strCode += ch.ToString().ToUpper();
        }
        Random r = new Random();
        
        for (int i = 0; i < CODE_LENGTH; i++)
        {
            strRandomCode += strCode[r.Next(strCode.Length)]; 
        }
        
        return strRandomCode;
    }

    public bool IsReusable
    {
        get {
            return false;
        }
    }

}