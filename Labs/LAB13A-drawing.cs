-- Name:  Dakin T. Werneburg
-- File: LAB13-drawing.cs
-- Date:  2/24/2021


using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Drawing
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrawingPad : Page
    {
        public DrawingPad()
        {
            this.InitializeComponent();
        }

        private void drawingCanvas_Tapped(object sender, TappedRoutedEventArgs e) 
        { 
            Point mouseLocation = e.GetPosition(drawingCanvas); 
            Square mySquare = new Square(100); 
            if (mySquare is IDraw) 
            { 
                IDraw drawSquare = mySquare; 
                drawSquare.SetLocation((int)mouseLocation.X, (int)mouseLocation.Y); 
                drawSquare.Draw(drawingCanvas); 
            }

            if (mySquare is IColor) 
            { 
                IColor colorSquare = mySquare; 
                colorSquare.SetColor(Colors.BlueViolet); 
            }


        }

        private void drawingCanvas_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Point mouseLocation = e.GetPosition(drawingCanvas); 
            Circle myCircle = new Circle(100); 
            if (myCircle is IDraw) 
            { 
                IDraw drawCircle = myCircle; 
                drawCircle.SetLocation((int)mouseLocation.X, (int)mouseLocation.Y); 
                drawCircle.Draw(drawingCanvas); 
            }
            if (myCircle is IColor) 
            { 
                IColor colorCircle = myCircle; 
                colorCircle.SetColor(Colors.HotPink); 
            }
        }
    }
}
