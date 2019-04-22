using System;
using System.Collections.Generic;
using System.Text;
using Storm.Mvvm;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace fourplaceproject.ViewModel
{
    class ModifMdpViewModel:ViewModelBase
    {
        
        private string _oldMdp;
        private string _mdp;
        public ICommand Modification { protected set; get; }
        public INavigation Navigation { get; set; }

     

        public string OldMdp
        {
            get => _oldMdp;
            set => SetProperty(ref _oldMdp, value);
        }

        public string Mdp
        {
            get => _mdp;
            set => SetProperty(ref _mdp, value);
        }

       

        public ModifMdpViewModel(INavigation navigation)
        {
            OldMdp = "";
            Mdp = "";
            Navigation = navigation;
            Modification = new Command(async () => { await TryModifier(); });
        }
        public async Task TryModifier()
        {
            if (await Service.ChangePassword(OldMdp, Mdp))
                await Navigation.PopAsync();
        }
    }
}
