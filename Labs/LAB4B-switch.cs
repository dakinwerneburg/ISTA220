﻿
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SwitchStatement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void copyClick(object sender, RoutedEventArgs e)
        {
            target.Text = "";
            string from = source.Text;
            for (int i = 0; i != from.Length; i++)
            {
                char current = from[i];
                copyOne(current);
            }
        }

        private void copyOne(char current)
        {
            switch(current)
            {
                case '<':
                    target.Text += "&lt;";
                    break;
                case '>':
                    target.Text += "&gt;";
                    break;
                case '&':
                    target.Text += "&amp;";
                    break;
                case '\"':
                    target.Text += "&quot;";
                    break;
                case '\'':
                    target.Text += "&apos;";
                    break;
                case 'e':
                    target.Text += "?";
                    break;
                default:
                    target.Text += current;
                    break;
            }     
        }
    }
}