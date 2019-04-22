using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.Mvvm.Forms;
using Storm.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using fourplaceproject.ViewModel;
using fourplaceproject.Model;

namespace fourplaceproject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : BaseContentPage
	{
		public Home ()
		{
			InitializeComponent();
            BindingContext= new HomeViewModel(Navigation);
            ListeLieux.ItemTapped += ListeLieux_ItemTapped;

        }
        private void ListeLieux_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            PlaceItemSummary lieu = (PlaceItemSummary)e.Item;
            Navigation.PushAsync(new PlaceDetail( lieu));
        }
    }
}