using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using fourplaceproject.View;
using MonkeyCache.SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace fourplaceproject
{
    public partial class App : Application
    {

        public static string URI_API { get; set; }
        public static string REFRESH { get; set; }
        public static string LOGIN { get; set; }
        public static string ME { get; set; }
        public static string REGISTER { get; set; }
        public static string PASSWORD { get; set; }
        public static string IMAGES { get; set; }
        public static string PLACES { get; set; }
        public static string COMMENTS { get; set; }
        public App()
        {
            URI_API = "https://td-api.julienmialon.com";
            REFRESH = "/auth/refresh";
            LOGIN = "/auth/login";
            REGISTER = "/auth/register";
            ME = "/me";
            PASSWORD = "/me/password";
            IMAGES = "/images";
            PLACES = "/places";
            COMMENTS = "/comments";
            InitializeComponent();
            Barrel.ApplicationId = "fourplaceproject";

            MainPage = new NavigationPage(new Login()) ;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
