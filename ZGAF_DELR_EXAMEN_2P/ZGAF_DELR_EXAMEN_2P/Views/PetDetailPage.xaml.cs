    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZGAF_DELR_EXAMEN_2P.Models;
using ZGAF_DELR_EXAMEN_2P.ViewModels;

namespace ZGAF_DELR_EXAMEN_2P.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDetailPage : ContentPage
    {
        public PetDetailPage()
        {
            InitializeComponent();
            BindingContext = new PetDetailViewModel();
        }

        public PetDetailPage(PetModel pet)
        {
            InitializeComponent();
            BindingContext = new PetDetailViewModel(pet);
        }
    }
}