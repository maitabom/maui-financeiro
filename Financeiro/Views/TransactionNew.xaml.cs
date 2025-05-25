namespace Financeiro.Views;

public partial class TransactionNew : ContentPage
{
	public TransactionNew()
	{
		InitializeComponent();
	}

    private void imaClose_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}