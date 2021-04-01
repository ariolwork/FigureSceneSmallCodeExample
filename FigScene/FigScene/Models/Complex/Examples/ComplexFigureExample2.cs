using FigScene.Models.Angular.Examples;
using FigScene.Models.Smooth.Examples;
using System.Collections.Generic;
using System.Drawing;

namespace FigScene.Models.Complex.Examples
{
    public sealed class ComplexFigureExample2 : BaseComplexFigure
    {
        protected override List<FigureWithParameters> Figures => new List<FigureWithParameters> {
            new FigureWithParameters(
                figureType: typeof(Triangle),
                center: new Point(0, 0),
                width: IMAGEWIDTH,
                height:IMAGEHEIGHT),
            new FigureWithParameters(
                figureType: typeof(Circle),
                center: new Point(0, 0),
                width: IMAGEWIDTH*2,
                height:IMAGEHEIGHT),
            new FigureWithParameters(
                figureType: typeof(Square),
                center: new Point(0, 0),
                width: IMAGEWIDTH,
                height:IMAGEHEIGHT)
        };
    }
}
