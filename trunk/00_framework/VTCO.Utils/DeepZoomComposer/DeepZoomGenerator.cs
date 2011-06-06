using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
namespace VTCO.Utils.DeepZoomComposer
{
    /// <summary>
    /// DeepZoom encapsulates code used to generate a DeepZoom image from a
    /// single image. This class does not contain any Windows Forms related or user
    /// interface code. 
    /// </summary>
    public class DeepZoomGenerator
    {

        /// <summary>
        /// Occurs when the creation of the deep zoom image progresses.
        /// </summary>
        public event EventHandler<DeepZoomCreationProgressEventArgs> CreationProgress;

        /// <summary>Overlap in pixels for DeepZoom image tiles</summary>
        internal const int tileOverlap = 1;
        internal const int maxThumbnailWidth = 125;

        private int m_ThumbnailImageWidth = 100;

        public int ThumbnailImageWidth
        {
            get { return m_ThumbnailImageWidth; }
            set { m_ThumbnailImageWidth = value; }
        }
        private int m_ThumbnailImageHeight = 100;

        public int ThumbnailImageHeight
        {
            get { return m_ThumbnailImageHeight; }
            set { m_ThumbnailImageHeight = value; }
        }

        private string m_ImagePath = "";

        /// <summary>
        /// Image Path
        /// </summary>
        public string ImagePath
        {
            get { return m_ImagePath; }
            set { m_ImagePath = value; }
        }
        

        private ImageCodecInfo jpegCodec;

        /// <summary>
        /// Gets or sets the database persister.
        /// </summary>
        /// <value>The database persister.</value>
        //public IDzDbPersistance DatabasePersister { get; set; }

        private long m_JpegQuality = 95L;
        /// <summary>JPEG quality used for jpg image tiles, must be between 1 and 100</summary>
        public long JpegQuality
        {
            get { return m_JpegQuality; }
            set { m_JpegQuality = value; }
        }

        private PixelFormat m_ColorPixelFormat = PixelFormat.Max;
        /// <summary>PixelFormat used in memory bitmaps</summary>
        public PixelFormat ColorPixelFormat
        {
            get { return m_ColorPixelFormat; }
            set { m_ColorPixelFormat = value; }
        }

        /// <summary>PixelFormat used in memory bitmaps</summary>
        public int TileSize { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="DeepZoomGenerator"/> class with 
        /// default values for jpeg quality (90), tile size (256) and a color format
        /// of 24bppRgb.
        /// </summary>
        public DeepZoomGenerator()
            : this(95L, 256, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeepZoomGenerator"/> class.
        /// </summary>
        /// <param name="jpegQuality">The JPEG quality. Integer values from 0 to 100</param>
        /// <param name="tileSize">Size of the tiles.</param>
        /// <param name="colorPixelFormat">The pixel format.</param>
        public DeepZoomGenerator(long jpegQuality, int tileSize, PixelFormat colorPixelFormat)
        {
            JpegQuality = jpegQuality;
            TileSize = tileSize;
            ColorPixelFormat = colorPixelFormat;
        }


        /// <summary>
        /// Generates a deepzoom image from a file
        /// The image file can be anything
        /// that System.Drawing.Bitmap allows in its constructor, usually tiff or jpg.
        /// </summary>
        /// <param name="sourceFile">Full path to the file</param>
        /// <param name="imageName">Name of the image.</param>
        /// <param name="useJpeg">if set to <c>true</c> [use JPEG].</param>
        /// <param name="useOverlap">if set to <c>true</c> the tiles will be created with a one pixel overlap.</param>
        /// <returns>the id of the image in the database</returns>
        public void GenerateFromFile(string sourceFile, string imageName, bool useJpeg, bool useOverlap)
        {
            Bitmap sourceImage;
            if (File.Exists(sourceFile))
                sourceImage = new Bitmap(sourceFile);
            else
                throw new FileNotFoundException("File not found!", sourceFile);
            if (!Directory.Exists(ImagePath))
            {
                throw new DirectoryNotFoundException("Directory not found!");
            }

            // Generate Xml File
            GenerateXmlFile(imageName,sourceImage.Width,sourceImage.Height, useJpeg, useOverlap);
            // Generate full deepzoom image 
            CreateSingleDeepZoomImage(imageName, sourceImage, useJpeg, useOverlap);

            sourceImage.Dispose();
        }


        /// <summary>
        /// Creates the DeepZoom image tile set for one image.
        /// </summary>
        /// <param name="imageName">Name of the image.</param>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="useJpeg">true if color images (jpg) should be written</param>
        /// <param name="useOverlap">if set to <c>true</c> tiles will be created a one pixel overlap.</param>
        /// <returns>The id of the image in the database</returns>
        private void CreateSingleDeepZoomImage(string imageName, Bitmap bitmap, bool useJpeg, bool useOverlap)
        {
            int maxLevel = CalcMaxLevel(bitmap.Width, bitmap.Height);
            int width = bitmap.Width;
            int height = bitmap.Height;
            double progressStep = (double)100 / maxLevel;
            double progress = 0;
            int overlap = useOverlap ? tileOverlap : 0;

            // Create a thumbnail to store in the db as a preview

            //Bitmap thumbnail = new Bitmap(bitmap, maxThumbnailWidth, bitmap.Height / (bitmap.Width / maxThumbnailWidth));
            // Persist the image info in the database

            for (int level = maxLevel; level >= 0; level--)
            {
                CreateTiles(imageName,bitmap, level, width, height, useJpeg, useOverlap);
                width = (width / 2);
                height = (height / 2);
                progress += progressStep;

                OnDeepZoomCreationProgress(new DeepZoomCreationProgressEventArgs((int)progress));
            }

        }

        /// <summary>
        /// Raises the DeepZoomCreationProgress event.
        /// </summary>
        /// <param name="e">The <see cref="DbDzComposer.DeepZoomCreationProgressEventArgs"/> instance containing the event data.</param>
        private void OnDeepZoomCreationProgress(DeepZoomCreationProgressEventArgs e)
        {
            // To prevent race conditions assign it to a variable and raise the event from there
            EventHandler<DeepZoomCreationProgressEventArgs> handler = CreationProgress;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        /// <summary>
        /// Creates a tile set for the specified bitmap and level. The caller should calculate
        /// and pass on the zoom width and height for for the level.
        /// </summary>
        /// <param name="bitmap">Original bitmap</param>
        /// <param name="level">Level</param>
        /// <param name="width">overall width of the image to be used for specified zoom level</param>
        /// <param name="height">overall height of the image to be used for specified zoom level</param>
        /// <param name="useJpeg">true if color image (should generate jpg)</param>
        /// <param name="useOverlap">true to generate overlapped tiles (deepzoom images), false for fixed 256x256 tiles (collection thumbnails)</param>
        /// <returns>Count of generated tiles</returns>
        internal int CreateTiles(string imageName, Bitmap bitmap, int level, int width, int height, bool useJpeg, bool useOverlap)
        {
            int tilesCount = 0;

            // Make sure we have valid height and width
            if (width < 1) width = 1;
            if (height < 1) height = 1;

            bool useSmoothScaling = useOverlap && ((width < bitmap.Width) || (height < bitmap.Height));
            using (var scaledBitmap = new EditableBitmap(bitmap, ColorPixelFormat, width, height, useSmoothScaling))
            {
                for (int x = 0, iX = 0; x < width; x += TileSize, iX++)
                {
                    int left;
                    int tileWidth = GetTileSize(x, width, out left, useOverlap);
                    for (int y = 0, iY = 0; y < height; y += TileSize, iY++)
                    {
                        int top;
                        int tileHeight = GetTileSize(y, height, out top, useOverlap);
                        var rectTile = new Rectangle(left, top, tileWidth, tileHeight);
                        string outputFile = iX + "_" + iY + (useJpeg ? ".jpg" : ".png");
                        using (EditableBitmap tileBitmap = scaledBitmap.CreateView(rectTile))
                        {
                            if (!useOverlap && ((tileWidth < TileSize) || (tileHeight < TileSize)))
                            {
                                // Collection thumbnail tiles are always the tilesize in minimum, even if the image content
                                // is much smaller. Draw a smaller image on top of a black TileSize x TileSize image.
                                using (var bmExtended = new Bitmap(TileSize, TileSize, tileBitmap.Bitmap.PixelFormat))
                                {
                                    using (Graphics gfx = Graphics.FromImage(bmExtended))
                                    {
                                        gfx.FillRectangle(Brushes.Black, 0, 0, TileSize, TileSize);
                                        gfx.DrawImage(tileBitmap.Bitmap, 0, 0);
                                    }
                                    SaveTile(imageName,bmExtended, level, iX, iY, JpegQuality, useJpeg);
                                }
                            }
                            else
                                SaveTile(imageName, tileBitmap.Bitmap, level, iX, iY, JpegQuality, useJpeg);
                        }
                        tilesCount++;
                    }
                }
            }
            return tilesCount;
        }


        /// <summary>
        /// Returns the maximum tile level for the given image dimensions.
        /// </summary>
        /// <param name="width">Image width in pixels</param>
        /// <param name="height">Image height in pixels</param>
        /// <returns>Maximum DeepZoom tile level for the image</returns>
        internal static int CalcMaxLevel(int width, int height)
        {
            int iDimension = Math.Max(width, height);
            return Convert.ToInt32(Math.Ceiling(Math.Log(iDimension) / Math.Log(2)));
        }

        /// <summary>
        /// Helper function to get tile coordinates. DeepZoom uses tiles that have a net
        /// size of 256 x 256, but have an overlap of 1 pixel on all sides. Tiles at the 
        /// border of the image are slightly smaller (e.g., 257 x 258) than tiles in the 
        /// middle (258 x 258).
        /// 
        /// Collection thumbnails do not use overlap but have tiles that are always exactly
        /// 256 x 256. For the non-overlap case Getc_tileSize will still truncate to the 
        /// image border, it returns the exact rectangle of the source image to be copied.
        /// </summary>
        /// <param name="start">Net start coordinate</param>
        /// <param name="max">Maximum coordinate in image</param>
        /// <param name="actualStart">OUT: Actual start coordinate can be 1 pixel below iStart</param>
        /// <param name="useOverlap">true to use overlap</param>
        /// <returns>Actual tile size</returns>
        internal int GetTileSize(int start, int max, out int actualStart, bool useOverlap)
        {
            int ic_tileSize;
            if (useOverlap)
            {
                ic_tileSize = TileSize + tileOverlap;
                actualStart = start;
                if (start > 0)
                {
                    ic_tileSize += tileOverlap;
                    actualStart -= tileOverlap;
                }
            }
            else
            {
                actualStart = start;
                ic_tileSize = TileSize;
            }
            if (actualStart + ic_tileSize > max)
                ic_tileSize = (max - actualStart);
            if (ic_tileSize < 1)
                ic_tileSize = 1;
            return ic_tileSize;
        }

        /// <summary>
        /// SaveTile is used to save a tile bitmap, either as jpg (bUseJpeg == true) or
        /// as png (bUseJpeg == false).
        /// </summary>
        /// <param name="bitmap">Bitmap to be saved</param>
        /// <param name="level">The level.</param>
        /// <param name="x">The x coordinates of the image</param>
        /// <param name="y">The y coordinates of the image</param>
        /// <param name="quality">Quality (only used for jpg)</param>
        /// <param name="useJpeg">true: save jpg format; false: save png format</param>
        internal void SaveTile(string imageName, Bitmap bitmap, int level, int x, int y, long quality, bool useJpeg)
        {
            string path = ImagePath + imageName + @"_files\" + level.ToString();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            MemoryStream memStream = new MemoryStream();

            //grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            //grPhoto.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            //grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (useJpeg)
            {
                // Encoder parameter for image quality
                var qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                // Jpeg image codec
                if (jpegCodec == null)
                    jpegCodec = GetEncoderInfo(GetMimeType(true));

                if (jpegCodec == null)
                    return;

                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                // Create a new bitmap according to the users quality settings
                bitmap.Save(memStream, jpegCodec, encoderParams);
                Bitmap bmp = new Bitmap(memStream);

                // Save the jpge to the database
                //DatabasePersister.SaveImageTile(imageId, level, x, y, bmp);
                bmp.Save(path + "\\" + x.ToString() + "_" + y.ToString() + ".jpg", ImageFormat.Jpeg);
                bmp.Dispose();
            }
            else
            {
                bitmap.Save(memStream, ImageFormat.Png);
                Bitmap bmp = new Bitmap(memStream);

                // Save the png to the database
                //DatabasePersister.SaveImageTile(imageId, level, x, y, bmp);
                bmp.Save(path + "\\" + x.ToString() + "_" + y.ToString() + ".png", ImageFormat.Png);
                bmp.Dispose();
            }
        }

        /// <summary>
        /// Helper function that returns the mime type for either jpeg or png
        /// </summary>
        /// <param name="useJpeg">if set to <c>true</c> [use JPEG].</param>
        /// <returns></returns>
        private string GetMimeType(bool useJpeg)
        {
            return useJpeg ? "image/jpeg" : "image/png";
        }

        /// <summary>
        /// Helper function that is used to locate the jpeg codec used in GDI+.
        /// </summary>
        /// <param name="mimeType">Mime type for which codec must be located</param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
            
        }

        private void GenerateXmlFile(string imageName, int width, int height, bool useJpeg, bool useOverlap)
        {
            //<?xml version="1.0" encoding="utf-8"?><Image TileSize="256" Overlap="1" Format="png" xmlns="http://schemas.microsoft.com/deepzoom/2008"><Size Width="320" Height="240" /></Image>
            string strXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            strXml += string.Format("<Image TileSize=\"256\" Overlap=\"{0}\" Format=\"{1}\" xmlns=\"http://schemas.microsoft.com/deepzoom/2008\">",
                useOverlap ? 1 : 0,
                useJpeg ? "jpg" : "png"
                );
            strXml += string.Format("<Size Width=\"{0}\" Height=\"{1}\" /></Image>",
                width,
                height);
            StreamWriter file = new StreamWriter(ImagePath + imageName + ".xml",false);
            file.Write(strXml);
            file.Close();
        }
    }
}