using System.Globalization;

namespace _4m12mauiLiczbaSlow
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnPoliczSlowa(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entNapis.Text))
            {
                await DisplayAlert("info", "w ciągu jest 0 słów", "rozumiem");
                return;
            }
                
            int licznik = 1;
            foreach (var c in entNapis.Text)
                if (c == ' ')
                    licznik++;
            await DisplayAlert("info", $"liczba słów: {licznik}", "rozumiem");

        }
        private async void btnPoliczSamogloski(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entNapis.Text))
            {
                await DisplayAlert("info", "w ciągu jest 0 samogłosek", "rozumiem");
                return;
            }
            string samogloski = "aąeęioóuy";
            int licznik = 0;
            foreach (var c in entNapis.Text)
                if (samogloski.Contains(c.ToString().ToLower()))
                    licznik++;
            await DisplayAlert("info", $"liczba samogłosek: {licznik}", "rozumiem");
        }
        private async void btnCzyPalindrom(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entNapis.Text))
            {
                await DisplayAlert("info", "pusty napis jest/nie jest palindromem", "rozumiem");
                return;
            }
            string odwrocNapis(string s)
            {
                string wynik = "";
                foreach (var c in s)
                    wynik = c + wynik;
                return wynik;
            }
            string p = "Napis nie jest palindromem";
            if(odwrocNapis(entNapis.Text) == entNapis.Text)
                p = "Napis jest palindromem";
            await DisplayAlert("info", p,"rozumiemi");
        }
    }

}
