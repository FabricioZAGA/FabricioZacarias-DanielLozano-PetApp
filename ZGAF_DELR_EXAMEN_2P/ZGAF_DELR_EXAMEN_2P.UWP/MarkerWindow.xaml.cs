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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZGAF_DELR_EXAMEN_2P.Models;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ZGAF_DELR_EXAMEN_2P.UWP
{
    public sealed partial class MarkerWindow : UserControl
    {
        public MarkerWindow(PetModel pet)
        {
            this.InitializeComponent();
            MarkerWindowImage.ImageSource = new BitmapImage(new Uri(pet.ImageBase64));
            MarkerWindowTitle.Text = pet.Name;
            MarkerWindowNotes.Text = pet.Direction;
        }
    }
}
