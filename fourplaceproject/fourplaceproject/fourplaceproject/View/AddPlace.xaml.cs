using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.Mvvm.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using fourplaceproject.ViewModel;

namespace fourplaceproject.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPlace : BaseContentPage
	{
		public AddPlace ()
		{
			InitializeComponent();
            BindingContext = new AddPlaceViewModel(Navigation);
		}
	}
}