using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;
using Windows.Storage.Streams;

namespace SimpleSketch
{
    public class DrawSettings
    {
        

        public void Init(ref InkCanvas display, ref ComboBox size, ref Button color)
        {
            string penSize = (size.SelectedItem as ComboBoxItem).Tag?.ToString();
            string colorButton = color.Tag.ToString();
            InkDrawingAttributes attributes = new InkDrawingAttributes();
            attributes.Color = GetColor(colorButton);
            attributes.Size = new Size(int.Parse(penSize), int.Parse(penSize));
            attributes.IgnorePressure = false;
            display.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
            display.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch | CoreInputDeviceTypes.Pen;
        }

        private Color GetColor(string value)
        {
            return Color.FromArgb(
                Byte.Parse(value.Substring(0, 2), NumberStyles.HexNumber),
                Byte.Parse(value.Substring(2, 2), NumberStyles.HexNumber),
                Byte.Parse(value.Substring(4, 2), NumberStyles.HexNumber),
                Byte.Parse(value.Substring(6, 2), NumberStyles.HexNumber)
            );
        }

        public void ChangeColor(ref InkCanvas canvas, ref Button color)
        {
            if (canvas != null)
            {
                string colorButton = color.Tag.ToString();
                InkDrawingAttributes attributes = canvas.InkPresenter.CopyDefaultDrawingAttributes();
                attributes.Color = GetColor(colorButton);
                canvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
            }
        }

        public void ChangeSize(ref InkCanvas canvas, ref ComboBox size)
        {
            if (canvas != null)
            {
                string newSize = (size.SelectedItem as ComboBoxItem).Tag.ToString();
                InkDrawingAttributes attributes = canvas.InkPresenter.CopyDefaultDrawingAttributes();
                attributes.Size = new Size(int.Parse(newSize), int.Parse(newSize));
                canvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
            }
        }
        
    }
}
