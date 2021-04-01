using JetBrains.Annotations;
using System;
using System.Drawing;

namespace FigScene.Models.Complex
{
    /// <summary>
    /// Contains IDrawable figure and settings to draw it
    /// </summary>
    public sealed class FigureWithParameters
    {
        private IDrawable _figure;

        public Point Center { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public FigureWithParameters(
            [NotNull] IDrawable figure,
            Point center,
            int height,
            int width)
        {
            _figure = figure ?? throw new Exception($"Null parameter {nameof(figure)} exception");
            Center = center;
            Height = height;
            Width = width;
        }

        public FigureWithParameters(
                [NotNull] Type figureType,
                Point center,
                int height,
                int width)
            : this(
                Activator.CreateInstance(figureType) as IDrawable 
                    ?? throw new Exception($"Unable to cast type {figureType.Name} to {typeof(IDrawable).Name}"), 
                center, 
                height, 
                width) { }

        public void DrawOnBitmap([NotNull] Bitmap bitmap)
        {
            _figure.DrawOnBitmap(
                bitmap: bitmap ?? throw new Exception($"Null parameter {nameof(bitmap)}"), 
                center: Center, 
                width: Width, 
                height: Height);
        }
    }
}
