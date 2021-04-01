using System.Drawing;
using System.Windows.Media.Imaging;

namespace FigScene.Models
{
    public abstract class BitmapFigure : IDrawable
    {
        protected const int IMAGEHEIGHT = 100;
        protected const int IMAGEWIDTH = 100;
        protected const int BITMAPHEIGHT = 200;
        protected const int BITMAPWIDTH = 200;

        protected Pen _pen = new Pen(Color.Black, IMAGEHEIGHT/20);

        /// <summary>
        /// Lets Cache image to make it some faster
        /// </summary>
        private BitmapImage _image; 

        public void DrawOnBitmap(Bitmap bitmap, Point center, int width, int height)
        {
            Draw( 
                bitmap: bitmap,  
                center: center,  
                width: width,  
                height: height);
        }

        public BitmapImage Image =>_image ?? (_image = BmpImageFromBmp(GetBitmapImage()));

        /// <summary>
        /// Draw Image on current bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="center"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected abstract void Draw(Bitmap bitmap, Point center, int width, int height);

        /// <summary>
        /// Draw image at the scene center
        /// </summary>
        /// <returns></returns>
        private Bitmap GetBitmapImage()
        {
            var bitmap = new Bitmap(BITMAPWIDTH, BITMAPHEIGHT);
            Draw(
                bitmap: bitmap, 
                center: new Point(BITMAPWIDTH / 2, BITMAPHEIGHT / 2), 
                width: IMAGEWIDTH, 
                height: IMAGEHEIGHT);
            return bitmap;
        }

        /// <summary>
        /// convert Bitmap to BitmapImage
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        private BitmapImage BmpImageFromBmp(Bitmap bmp)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
