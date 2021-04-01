using FigScene.Models.Angular.Examples;
using System.Collections.Generic;
using System.Drawing;

namespace FigScene.Models.Complex.Examples
{
    public sealed class ComplexFigureExample1 : BaseComplexFigure
    {
        protected override List<FigureWithParameters> Figures => new List<FigureWithParameters> {
            new FigureWithParameters(
                figureType: typeof(Triangle),
                center: new Point(0, 0),
                width: IMAGEWIDTH,
                height:IMAGEHEIGHT),
            new FigureWithParameters(
                figureType: typeof(Square),
                center: new Point(0, 0),
                width: IMAGEWIDTH,
                height:IMAGEHEIGHT/2)
        };
    }
}
