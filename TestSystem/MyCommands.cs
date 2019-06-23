using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace TestSystem
{
    public class MyCommands
    {
        public static RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(MyCommands), new InputGestureCollection() { new KeyGesture(Key.Q, ModifierKeys.Control) });
        public static RoutedUICommand FontSize = new RoutedUICommand("FontSize", "EditFontSize", typeof(MyCommands));
        public static RoutedUICommand Load = new RoutedUICommand("Load session", "Load", typeof(MyCommands));
    }
}
