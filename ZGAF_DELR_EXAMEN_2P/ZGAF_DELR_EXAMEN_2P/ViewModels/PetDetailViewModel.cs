using Plugin.Media;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZGAF_DELR_EXAMEN_2P.Models;
using ZGAF_DELR_EXAMEN_2P.Services;
using ZGAF_DELR_EXAMEN_2P.Views;

namespace ZGAF_DELR_EXAMEN_2P.ViewModels
{
    public class PetDetailViewModel : BaseViewModel
    {
        private int id;

        Command _saveCommand;
        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(SaveAction));

        Command _deleteCommand;
        public Command DeleteCommand => _deleteCommand ?? (_deleteCommand = new Command(DeleteAction));

        Command _mapCommand;
        public Command MapCommand => _mapCommand ?? (_mapCommand = new Command(MapAction));

        Command _GetLocationCommand;
        public Command GetLocationCommand => _GetLocationCommand ?? (_GetLocationCommand = new Command(GetLocationAction));
        Command _TakePictureCommand;
        public Command TakePictureCommand => _TakePictureCommand ?? (_TakePictureCommand = new Command(TakePictureAction));

        Command _SelectPictureCommand;
        public Command SelectPictureCommand => _SelectPictureCommand ?? (_SelectPictureCommand = new Command(SelectPictureAction));

        string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        DateTime _BornDate;
        public DateTime BornDate
        {
            get => _BornDate;
            set => SetProperty(ref _BornDate, value);
        }

        string _Gender;
        public string Gender
        {
            get => _Gender;
            set => SetProperty(ref _Gender, value);
        }

        string _Breed;
        public string Breed
        {
            get => _Breed;
            set => SetProperty(ref _Breed, value);
        }

        int _Weight;
        public int Weight
        {
            get => _Weight;
            set => SetProperty(ref _Weight, value);
        }

        double _Latitude;
        public double Latitude
        {
            get => _Latitude;
            set => SetProperty(ref _Latitude, value);
        }

        double _Longitude;
        public double Longitude
        {
            get => _Longitude;
            set => SetProperty(ref _Longitude, value);
        }

        string _Notes;
        public string Notes
        {
            get => _Notes;
            set => SetProperty(ref _Notes, value);
        }

        string _ImageBase64;
        public string ImageBase64
        {
            get => _ImageBase64;
            set => SetProperty(ref _ImageBase64, value);
        }

        string _Direction;
        public string Direction
        {
            get => _Direction;
            set => SetProperty(ref _Direction, value);
        }

        public PetDetailViewModel()
        {
            BornDate = DateTime.Now;
        }

        public PetDetailViewModel(PetModel pet)
        {
            if (pet != null)
            {
                id = pet.Id;
                Name = pet.Name;
                BornDate = pet.BornDate;
                Gender = pet.Gender;
                Breed = pet.Breed;
                Weight = pet.Weight;
                Notes = pet.Notes;
                Latitude = pet.Latitude;
                Longitude = pet.Longitude;
                ImageBase64 = pet.ImageBase64;
                Direction = pet.Direction;
            }
        }

        private async void SaveAction()
        {
            IsBusy = true;
            await App.PetDatabase.SaveTaskAsync(new PetModel
            {
                Id = id,
                Name = Name,
                BornDate = BornDate,
                Gender = Gender,
                Breed = Breed,
                Weight = Weight,
                Notes = Notes,
                Latitude = Latitude,
                Longitude = Longitude,
                ImageBase64 = ImageBase64,
                Direction = Direction
            });

            PetListViewModel.GetInstance().LoadTasks();



            IsBusy = false;
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void DeleteAction()
        {
            IsBusy = true;

            await App.PetDatabase.DeleteTaskAsync(new PetModel
            {
                Id = id,
                Name = Name,
                BornDate = BornDate,
                Gender = Gender,
                Breed = Breed,
                Weight = Weight,
                Notes = Notes,
                Latitude = Latitude,
                Longitude = Longitude,
                ImageBase64 = ImageBase64,
                Direction = Direction
            });

            PetListViewModel.GetInstance().LoadTasks();


            IsBusy = false;
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void MapAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PetMapPage(new PetModel
            {
                Id = id,
                Name = Name,
                BornDate = BornDate,
                Gender = Gender,
                Breed = Breed,
                Weight = Weight,
                Notes = Notes,
                Latitude = Latitude,
                Longitude = Longitude,
                ImageBase64 = ImageBase64,
                Direction = Direction
            }));
        }

        private async void GetLocationAction()
        {
            
            ApiResponse response = await new ApiService().GetDataAsync<ApiGoogle>(Direction);
            if (response == null || !response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error al cargar los viajes", response.Message, "Ok");
                return;
            }
            
            ApiGoogle apiResponse = (ApiGoogle)response.Result;
            Latitude = apiResponse.results[0].geometry.location.lat;
            Longitude = apiResponse.results[0].geometry.location.lng;
            await Application.Current.MainPage.DisplayAlert("Ubicación Guardada", "Se ha añadido la nueva dirección correctamente\n\n" +
                "Coordenadas: " + Latitude + ", " + Longitude, "OK");
        }

        private async void TakePictureAction()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                await CrossMedia.Current.Initialize();
            }

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);
            await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");
        }

        private async void SelectPictureAction()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                await CrossMedia.Current.Initialize();
            }

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Seleccionar fotografías no soportada", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null)
                return;

            ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);
        }
    }
}
