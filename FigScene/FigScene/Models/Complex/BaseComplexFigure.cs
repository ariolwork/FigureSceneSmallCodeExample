using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FigScene.Models.Complex
{
    public abstract class BaseComplexFigure : BitmapFigure
    {
        protected abstract List<FigureWithParameters> Figures { get; }

        protected override void Draw(Bitmap bitmap, Point center, int width, int height)
        {
            var localFigures = Figures.ToList();
            localFigures.ForEach(f => 
                f.Center = new Point(f.Center.X + center.X, f.Center.Y + center.Y));

            foreach(var figure in localFigures)
            {
                figure.DrawOnBitmap(bitmap);
            }
        }
    }
}
