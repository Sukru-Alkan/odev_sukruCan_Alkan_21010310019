namespace odev_sukruCan_Alkan_21010310019;

public partial class kitleEndeksi : ContentPage
{
    public kitleEndeksi()
    {
        InitializeComponent();
        kilo_Entry.TextChanged += EntryTextChanged;
        boy_Entry.TextChanged += EntryTextChanged;
        kilo_Slider.ValueChanged += kilo_Slider_ValueChanged;
        boy_Slider.ValueChanged += boy_Slider_ValueChanged;

    }
    private void kilo_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double kilo = e.NewValue;
        kilo_Entry.Text = kilo.ToString("F0");
        CalculateVKI();
    }
    private void boy_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double boy = boy_Slider.Value;
        boy_Entry.Text = boy.ToString("F0");
        CalculateVKI();


    }
    private void EntryTextChanged(object sender, TextChangedEventArgs e)
    {
        CalculateVKI();
    }


    private void CalculateVKI()
    {
        if (double.TryParse(kilo_Entry.Text, out double kilo) && double.TryParse(boy_Entry.Text, out double boy))
        {
            double boyMeters = boy / 100;
            double vki = kilo / (boyMeters * boyMeters);

            string result = string.Empty;

            if (vki < 16)
            {
                result = "�leri D�zeyde Zay�f";
            }
            else if (vki >= 16 && vki < 17)
            {
                result = "Orta D�zeyde Zay�f";
            }
            else if (vki >= 17 && vki < 18.5)
            {
                result = "Hafif D�zeyde Zay�f";
            }
            else if (vki >= 18.5 && vki < 25)
            {
                result = "Normal Kilolu";
            }
            else if (vki >= 25 && vki < 30)
            {
                result = "Hafif �i�man / Fazla Kilolu";
            }
            else if (vki >= 30 && vki < 35)
            {
                result = "1. Derecede Obez";
            }
            else if (vki >= 35 && vki < 40)
            {
                result = "2. Derecede Obez";
            }
            else if (vki >= 40)
            {
                result = "3. Derecede Obez / Morbid Obez";
            }

            sonuc.Text = $"VK�: {vki:F2}";
            durum.Text = result;
        }
        else
        {
            sonuc.Text = "T�m degerler girinz ";
            durum.Text = string.Empty;
        }


    }
}