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
        public DrawSettings DrawSettings = new DrawSettings();
        
        

        public DrawingPad()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DrawSettings.Init(display: ref InkCanvas, size: ref Size, color: ref BtnBlack);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
                        if (InkCanvas.InkPresenter.InputProcessingConfiguration.Mode == InkInputProcessingMode.Inking) 
            {
                InkCanvas.InkPresenter.InputProcessingConfiguration.Mode =
                    InkInputProcessingMode.Erasing;
            } 
            else 
            {
                InkCanvas.InkPresenter.InputProcessingConfiguration.Mode =
                    InkInputProcessingMode.Inking;
            }
        }

        private void Size_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawSettings != null) DrawSettings.ChangeSize(ref InkCanvas, ref Size);
        }

        private void BtnGreen_Click(object sender, RoutedEventArgs e)
        {
            DrawSettings.ChangeColor(ref InkCanvas, ref BtnGreen);
        }

        private void BtnRed_Click(object sender, RoutedEventArgs e)
        {
            DrawSettings.ChangeColor(ref InkCanvas, ref BtnRed);
        }

        private void BtnYellow_Click(object sender, RoutedEventArgs e)
        {
            DrawSettings.ChangeColor(ref InkCanvas, ref BtnYellow);
        }

        private void BtnBlue_Click(object sender, RoutedEventArgs e)
        {
            DrawSettings.ChangeColor(ref InkCanvas, ref BtnBlue);
        }

        private void BtnBlack_Click(object sender, RoutedEventArgs e)
        {
            DrawSettings.ChangeColor(ref InkCanvas, ref BtnBlack);
        }
    }
}
