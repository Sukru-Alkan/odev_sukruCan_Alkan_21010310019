namespace odev_sukruCan_Alkan_21010310019;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
    }

    // 'menu_clicked' olay işleyicisi
    private void menu_clicked(object sender, EventArgs e)
    {
        // Burada olayın işleyişini tanımlayın
        // Örneğin, bir mesaj kutusu gösterme:
        DisplayAlert("Menu", "Menu clicked!", "OK");
        Shell.Current.FlyoutIsPresented= true;
    }
}
