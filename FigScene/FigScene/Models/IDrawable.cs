using JetBrains.Annotations;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace FigScene.Models
{
    public interface IDrawable
    {
        /// <summary>
        /// Returns Image with figure
        /// </summary>
        [NotNull]
        BitmapImage Image { get; }

        /// <summary>
        /// Draw current on exist bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="center"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void DrawOnBitmap([NotNull] Bitmap bitmap, [NotNull] Point center, int width, int height);
    }
}
