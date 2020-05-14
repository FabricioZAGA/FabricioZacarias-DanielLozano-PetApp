using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using ZGAF_DELR_EXAMEN_2P.Models;
using ZGAF_DELR_EXAMEN_2P.Services;

namespace ZGAF_DELR_EXAMEN_2P.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetMapPage : ContentPage
    {
        public PetMapPage(PetModel petSelected)
        {
            InitializeComponent();

            MapPet.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(petSelected.Latitude, petSelected.Longitude),
                    Distance.FromMiles(.5)
            ));

            string imagePath = new ImageService().SaveImageFromBase64(petSelected.ImageBase64, petSelected.Id);
            petSelected.ImageBase64 = imagePath;
            MapPet.Pet = petSelected;

            MapPet.Pins.Add(
                new Pin
                {
                    Type = PinType.Place,
                    Label = petSelected.Name,
                    Position = new Position(petSelected.Latitude, petSelected.Longitude)
                }
            );
            
            Name.Text = petSelected.Name;
            Age.Text = (DateTime.Now.Year - petSelected.BornDate.Year).ToString() + " años";
            Notes.Text = petSelected.Notes;
        }
    }
}