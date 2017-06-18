using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Input.Inking;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleSketch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DrawingPad : Page
    {
        private SolidColorBrush _brush = new SolidColorBrush(Colors.Black);

        public DrawingPad()
        {
            this.InitializeComponent();
        }
        
        private void BlackB_Click_1(object sender, RoutedEventArgs e)
        {
            _brush.Color = Colors.Black;
           
        }

        private void BlueB_Click_1(object sender, RoutedEventArgs e)
        {
            _brush.Color = Colors.Blue;
        }

        private void YelloB_Click_1(object sender, RoutedEventArgs e)
        {
            _brush.Color = Colors.Yellow;
        }

        private void GreenB_Click_1(object sender, RoutedEventArgs e)
        {
            _brush.Color = Colors.Green;
        
        }

        private void RedB_Click_1(object sender, RoutedEventArgs e)
        {
            _brush.Color = Colors.Red;
        }

        private void InkCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            InkPresenter myPresenter = InkCanvas.InkPresenter;
            myPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Pen | Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Touch;
            InkDrawingAttributes myAttributes = myPresenter.CopyDefaultDrawingAttributes();
            myAttributes.Color = _brush.Color;
            myAttributes.PenTip = PenTipShape.Circle;
            myAttributes.Size = new Size(2, 6);
            myPresenter.UpdateDefaultDrawingAttributes(myAttributes);
        }

        private void InkCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
        }
    }
}
