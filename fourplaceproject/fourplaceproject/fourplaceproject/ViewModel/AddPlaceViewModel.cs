using System;
using System.Collections.Generic;
using System.Text;
using Storm.Mvvm;
using Xamarin.Forms;
using System.Windows.Input;

namespace fourplaceproject.ViewModel
{
    class AddPlaceViewModel : ViewModelBase 
    {

        private string _msg = "";
        private string _title = "";
        private string _description = "";
        private int? _imageId;
        private string _imageUrl;


        

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }




        public ICommand PrendrePhoto { protected set; get; }
        public ICommand ChoisirPhoto { protected set; get; }
        public ICommand Ajouter { protected set; get; }
        public INavigation Navigation { get; set; }




        public AddPlaceViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

    }
}
