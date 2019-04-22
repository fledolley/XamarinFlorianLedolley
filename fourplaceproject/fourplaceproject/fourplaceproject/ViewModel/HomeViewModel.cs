using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Storm.Mvvm;
using Xamarin.Forms;
using fourplaceproject.Model;
using fourplaceproject.View;
using System.Threading.Tasks;

namespace fourplaceproject.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        private List<PlaceItemSummary>_lieux;

        public List<PlaceItemSummary> Lieux
        {
            get => _lieux;
            set => SetProperty(ref _lieux, value);
        }

        public ICommand GoMDP { protected set; get; }
        public ICommand AddPlaceCommand { protected set; get; }
        public ICommand ReloadCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        public HomeViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            GoMDP = new Command(async ()=> await AccesEditProfil() );
            AddPlaceCommand = new Command(async ()=> await AccesAjouterPlace() );
            
        }
        public async Task AccesEditProfil()
        {
            await Navigation.PushAsync(new ModifMdp());
        }
        
        public async Task AccesAjouterPlace()
        {
            await Navigation.PushAsync(new AddPlace());
        }
        public override async Task OnResume()
        {
            await base.OnResume();
            ListeLieux lieux = await Service.GetPlaces();
            
            if (lieux != null)
            {
                foreach (PlaceItemSummary place in lieux.LLieux)
                {
                    place.ImageUrl = App.URI_API + App.IMAGES +"/"+ place.ImageId;
                }
                Lieux = lieux.LLieux;
            }
            else
            {
                
            }
           
        }

    }
}
