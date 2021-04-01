using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FigScene.Models.Angular
{
    public abstract class BaseAngularFigure : BitmapFigure
    {
        protected abstract List<Point> Points { get; }

        protected override void Draw(Bitmap bitmap, Point center, int width, int height)
        {
            var points = MovePoints(NormalizedPoints(width, height), center);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                for (var i = 0; i < points.Count - 1; i++)
                {
                    graphics.DrawLine(_pen, points[i], points[i + 1]);
                }
                graphics.DrawLine(_pen, points[0], points[points.Count - 1]);
            }
        }

        /// <summary>
        /// Move center to new point
        /// </summary>
        /// <param name="localPoints"></param>
        /// <param name="center"></param>
        /// <returns></returns>
        protected virtual List<Point> MovePoints(List<Point> localPoints, Point center)
        {
            return localPoints.Select(p =>
                    new Point(p.X + center.X, p.Y + center.Y)
                ).ToList();
        } 

        /// <summary>
        /// Move points to (0,0) and change size to be into frames
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        protected virtual List<Point> NormalizedPoints(int width, int height)
        {
            var localPoints = Points.ToList();
            var xPoints = localPoints.Select(p => p.X);
            var yPoints = localPoints.Select(p => p.Y);
            var minX = xPoints.Min();
            var maxX = xPoints.Max();
            var minY = yPoints.Min();
            var maxY = yPoints.Max();
            var zoom = float.MaxValue;
            var localXZoom = (float)width / (maxX - minX);
            if (zoom > localXZoom)
            {
                zoom = localXZoom;
            }

            var localYZoom = (float)height / (maxY - minY);
            if (zoom > localYZoom)
            {
                zoom = localYZoom;
            }
            var center = new Point(-width / 2, -height / 2);
            return MovePoints(
                localPoints.Select(p =>
                    new Point((int)((p.X - minX) * zoom), (int)((p.Y - minY) * zoom))
                    ).ToList(),
                center);
        }
    }
}
