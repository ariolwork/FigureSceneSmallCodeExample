using System.Collections.Generic;
using System.Drawing;

namespace FigScene.Models.Angular.Examples
{
    public sealed class Triangle : BaseAngularFigure
    {
        protected override List<Point> Points => new List<Point> {
            new Point(0,1),
            new Point(2,1),
            new Point(1,0),
        };
    }
}
