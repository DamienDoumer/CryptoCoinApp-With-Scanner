using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoCoinMon
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage).Assembly;
            Img.Source = ImageSource.FromResource(@"CryptoCoinMon.Images.CryptoLogo.png", assembly) ;
            var g = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        }
    }
}