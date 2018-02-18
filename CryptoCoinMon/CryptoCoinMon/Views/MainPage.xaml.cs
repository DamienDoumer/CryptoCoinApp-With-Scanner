using CryptoCoinMon.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoCoinMon.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

            //var assembly = typeof(MainPage).Assembly;
            //Img.Source = ImageSource.FromResource(@"CryptoCoinMon.Images.CryptoLogo.png", assembly) ;
            //var g = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
        protected override void OnAppearing()
        {
            var context = BindingContext as MainViewModel;
            context?.Initialize();
            base.OnAppearing();
        }
    }
}