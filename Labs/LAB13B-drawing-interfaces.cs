-- Name:  Dakin T. Werneburg
-- File: LAB13B-drawing-interfaces.cs
-- Date:  2/24/2021

using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls;
using System;

namespace Drawing
{
    abstract class DrawingShape
    {
        protected int size;
        protected int locX = 0;
        protected int locY = 0;
        protected Shape shape = null;

        protected DrawingShape(int s)
        {
            size = s;
        }

        public void SetLocation(int xCoord, int yCoord)
        {
            locX = xCoord;
            locY = yCoord;
        }
        public void SetColor(Color color)
        {
            if (shape != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                shape.Fill = brush;
            }
        }

        public virtual void Draw(Canvas canvas)
        {
            if (shape == null)
            {
                throw new InvalidOperationException("Shape is null ");
            }

            shape.Height = size;
            shape.Width = size;
            Canvas.SetTop(shape, locY);
            Canvas.SetLeft(shape, locX);
            canvas.Children.Add(shape);
        }
    }
}
