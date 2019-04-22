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
	public partial class RegisterUser : BaseContentPage
	{


        
		public RegisterUser ()
		{
			InitializeComponent ();
            BindingContext = new RegisterViewModel(Navigation);

        }
	}
}