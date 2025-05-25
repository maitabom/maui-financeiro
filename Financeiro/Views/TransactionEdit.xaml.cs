namespace Financeiro.Views;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
		InitializeComponent();
	}

    private void imaClose_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }
}