using System.Drawing;

namespace FigScene.Models.Smooth.Examples
{
    public sealed class Circle : BitmapFigure
    {
        protected override void Draw(Bitmap bitmap, Point center, int width, int height)
        {
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawEllipse(_pen, center.X-width/2, center.Y - height/2, width, height);
            }
        }
    }
}
