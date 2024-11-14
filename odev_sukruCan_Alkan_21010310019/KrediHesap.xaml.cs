using System.Globalization;

namespace odev_sukruCan_Alkan_21010310019;

public partial class KrediHesap : ContentPage
{
    public KrediHesap()
    {
        InitializeComponent();
        HesaplaButton.Clicked += HesaplaButton_Clicked;

    }

    private void HesaplaButton_Clicked(object sender, EventArgs e)
    {
        double krediTutari;
        if (!double.TryParse(
                    KrediTutariEntry.Text.Replace(",", ""),
                    NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                    CultureInfo.GetCultureInfo("tr-TR"),
                    out krediTutari))
        {
            DisplayAlert("Hata", "Hatali kredi Tutari  girildi.", "Tamam");
            return;
        }

        double faizOrani;
        if (!double.TryParse(FaizOraniEntry.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out faizOrani))
        {
            DisplayAlert("Hata", "Hatali faiz orani girildi.", "Tamam");
            return;
        }

        int vade;
        if (!int.TryParse(VadeEntry.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out vade))
        {
            DisplayAlert("Hata", "Ge�ersiz kredi s�resi girildi.", "Tamam");
            return;
        }

        double kkdfRate = 0;
        double bsmvRate = 0;

        string secilenTur = krediPicker.SelectedItem?.ToString();
        switch (secilenTur)
        {
            case "�htiya� Kredisi":
                kkdfRate = 0.15;
                bsmvRate = 0.10;
                break;

            case "Konut Kredisi":
                kkdfRate = 0;
                bsmvRate = 0;
                break;

            case "Ta��t Kredisi":
                kkdfRate = 0.15;
                bsmvRate = 0.05;
                break;

            case "Ticari Kredisi":
                kkdfRate = 0;
                bsmvRate = 0.05;
                break;

            default:
                DisplayAlert("Hata", "Ge�ersiz kredi t�r� se�ildi.", "Tamam");
                return;
        }

        //double kkdf = krediTutari * kkdfRate;
        //double bsmv = krediTutari * bsmvRate;

        double brutFaiz = ((faizOrani + (faizOrani * bsmvRate) + (faizOrani * kkdfRate)) / 100);

        double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * krediTutari;

        double toplam = taksit * vade;

        AylikTaksitLabel.Text = "Ayl�k taksit: " + taksit.ToString("C", CultureInfo.GetCultureInfo("tr-TR"));
        ToplamOdemeLabel.Text = "Toplam �deme: " + toplam.ToString("C", CultureInfo.GetCultureInfo("tr-TR"));
        ToplamFaizLabel.Text = "Toplam faiz: " + (toplam - krediTutari).ToString("C", CultureInfo.GetCultureInfo("tr-TR"));
    }



    private void _Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        VadeEntry.Text = value.ToString("F0");

        HesaplaButton_Clicked(sender, EventArgs.Empty);

    }
    private void pickerSelectedIndex(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        string secilenKredi = (string)picker.SelectedItem;


        DisplayAlert("Se�ilen kredi t�r�", secilenKredi, "Tamam");

    }
}