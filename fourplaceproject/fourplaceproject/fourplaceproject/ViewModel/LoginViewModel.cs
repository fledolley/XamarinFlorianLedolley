using System;
using System.Collections.Generic;
using System.Text;
using Storm.Mvvm;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using fourplaceproject;
using fourplaceproject.View;
namespace fourplaceproject.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        
        

        private  string _mail;
        private string _mdp;
        private string _info;

        public string Mail
        {
            get => _mail;
            set => SetProperty(ref _mail, value);
        }
        public string Mdp
        {
            get => _mdp;
            set => SetProperty(ref _mdp, value);
        }
        public string Info
        {
            get => _info;
            set => SetProperty(ref _info, value);
        }



        public ICommand TLogin { protected set; get; }
        public ICommand TRegister { protected set; get; }
        public INavigation Navigation;

        public LoginViewModel(INavigation navigation)
        {
            this.Navigation= navigation;
            TLogin = new Command(async () => await TryLogin());
            TRegister = new Command(async () => await TryRegister());
            Info = "";
        }
        async Task TryLogin(){
            bool co=await Service.TryLogin(Mail, Mdp);
            if (co)
            {
                await Navigation.PushAsync(new Home());
            }
            else
            {
                Info = "Probleme de connection";
                OnPropertyChanged("Info");
            }
            
            
        }
        async Task TryRegister()
        {
            await Navigation.PushAsync(new RegisterUser());
        }
    }
}
