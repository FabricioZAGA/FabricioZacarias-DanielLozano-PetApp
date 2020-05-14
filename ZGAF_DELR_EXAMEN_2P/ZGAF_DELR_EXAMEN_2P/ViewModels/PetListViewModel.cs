using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZGAF_DELR_EXAMEN_2P.Models;
using ZGAF_DELR_EXAMEN_2P.Views;

namespace ZGAF_DELR_EXAMEN_2P.ViewModels
{
    public class PetListViewModel : BaseViewModel
    {
        static PetListViewModel instance;
        //Propiedades y Atributos
        private Command _NewCommand;
        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewPetAction));

        List<PetModel> pets;
        public List<PetModel> Pets
        {
            get => pets;
            set => SetProperty(ref pets, value);
        }

        PetModel petSelected;
        public PetModel PetSelected
        {
            get => petSelected;
            set
            {
                if (SetProperty(ref petSelected, value))
                {
                    SelectTaskAction();
                }
            }
        }

        //Constructor
        public PetListViewModel()
        {
            instance = this;
            LoadTasks();
        }


        //Métodos 
        public static PetListViewModel GetInstance()
        {
            if (instance == null) instance = new PetListViewModel();
            return instance;
        }

        public async void LoadTasks()
        {
            Pets = await App.PetDatabase.GetAllTasksAsync();
            
        }

        private void NewPetAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PetDetailPage());
        }

        private void SelectTaskAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PetDetailPage(PetSelected));
        }
    }
}
