using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Storm.Mvvm;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fourplaceproject.ViewModel
{
    class RegisterViewModel:ViewModelBase
    {
        private string _mail;
        private string _mdp;
        private string _firstname;
        private string _lastname;
        private string _info;

        public string Mail
        {
            get=>_mail;
            set=>SetProperty(ref _mail, value);
        }
        public string Mdp
        {
            get => _mdp;
            set => SetProperty(ref _mdp, value);
        }
        public string FirstName
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);
        }
        public string LastName
        {
            get => _lastname;
            set => SetProperty(ref _lastname, value);
        }
        public string Info
        {
            get => _info;
            set => SetProperty(ref _info, value);
        }

        public ICommand GoEnregistrer { get; set; }
        public INavigation Navigation { get; set; }

        public RegisterViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            GoEnregistrer = new Command(async () => await TryEnregistrer());
            Info = "";
        }

        public async Task TryEnregistrer()
        {
            
            bool res = await Service.Register(Mail, Mdp, FirstName, LastName);
            
            if (res)
            {
                await Navigation.PopAsync();
            }
            else
            {
                Info = "Echec de l'enregistrement";
                OnPropertyChanged("Info");
            }
        }
        
    }
}
