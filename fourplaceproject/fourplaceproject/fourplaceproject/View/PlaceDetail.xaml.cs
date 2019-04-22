using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.Mvvm.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using fourplaceproject.ViewModel;
using fourplaceproject.Model;

namespace fourplaceproject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaceDetail : BaseContentPage
	{

		public PlaceDetail (PlaceItemSummary lieu)
		{
			InitializeComponent();
            BindingContext = new PlaceDetailViewModel(lieu);
		}
	}
}