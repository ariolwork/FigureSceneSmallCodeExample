using System.Collections.Generic;
using System.Drawing;

namespace FigScene.Models.Angular.Examples
{
    public sealed class Rectangle : BaseAngularFigure
    {
        protected override List<Point> Points => new List<Point> {
            new Point(0,0),
            new Point(0,1),
            new Point(2,1),
            new Point(2,0)
        };
    }
}
