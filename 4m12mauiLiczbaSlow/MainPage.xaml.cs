using System.Globalization;
using System.Runtime.CompilerServices;

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
            string wyczyscSpacje(string s)
            {
                while(s.Contains("  "))
                {
                    s = s.Replace("  ", " ");
                }
                return s;
            }
            if (string.IsNullOrEmpty(entNapis.Text))
            {
                await DisplayAlert("info", "w ciągu jest 0 słów", "rozumiem");
                return;
            }
            string napis = wyczyscSpacje(entNapis.Text);
            napis = napis.Trim();
            if(napis == " ")
            {
                await DisplayAlert("info", "w ciągu jest 0 słów", "rozumiem");
                return;
            }
            int licznik = 1;
            foreach (var c in napis)
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

            string napis = entNapis.Text.ToUpper();
            napis = wyczyscTekst(napis);
            string p = "Napis nie jest palindromem";
            if(odwrocNapis(napis) == napis)
                p = "Napis jest palindromem";
            await DisplayAlert("info", p,"rozumiemi");
            //entNapis.Text = napis;
        }
        private async void btnCzyAnagram(object sender, EventArgs e)
        {
            // drugi pomysł pomysł: usuwać znaki z pierwszego stringu w drugim
            //  
            if (string.IsNullOrEmpty(entAnagram1.Text) || string.IsNullOrEmpty(entAnagram1.Text))
            {
                await DisplayAlert("info", "pusty napis nie jest anagramem", "rozumiem");
                return;
            }
            string s1 = wyczyscTekst(entAnagram1.Text.ToUpper());
            string s2 = wyczyscTekst(entAnagram2.Text.ToUpper());
            if(s1.Length != s2.Length)
            {
                await DisplayAlert("info", "to nie anagramy", "ok");
                return;
            }
            foreach(var c in s1)
            {
                int poz = s2.IndexOf(c);
                if(poz == -1)
                {
                    await DisplayAlert("info", "to nie anagramy", "ok");
                    return;
                }
                s2 = s2.Remove(poz, 1);
            }
            string p = "to nie jest anagram";
            if(s2.Length == 0)
                p = "to jest anagram";
            await DisplayAlert("info", p, "ok");

        }
        private async void btnCzyAnagram1(object sender, EventArgs e)
        {
            // pierwszy pomysł: zamienić na tablice, posortować,
            // zamienić na string  i porównać 
            if (string.IsNullOrEmpty(entAnagram1.Text) || string.IsNullOrEmpty(entAnagram1.Text))
            {
                await DisplayAlert("info", "pusty napis nie jest anagramem", "rozumiem");
                return;
            }
            string s1 = wyczyscTekst(entAnagram1.Text.ToUpper());
            string s2 = wyczyscTekst(entAnagram2.Text.ToUpper());
            char[] t1 = s1.ToCharArray();
            Array.Sort(t1);
            char[] t2 = s2.ToCharArray();
            Array.Sort(t2);
            s1 = s2 = "";
            foreach (var c in t1)
                s1 += c;
            foreach (var c in t2)
                s2 += c;
            string p = "to nie jest anagram";
            if(s1 == s2)
                p = "to jest anagram";
            await DisplayAlert("info", p, "ok");
        }


        private static string wyczyscTekst(string s)
        {
            string znaki = " ,.?!";
            foreach (var c in znaki)
                if (s.Contains(c))
                    s = s.Replace(c.ToString(), "");
            return s;
        }
    }

}
