namespace Financeiro.Views;

public partial class TransactionList : ContentPage
{
    public TransactionList()
    {
        InitializeComponent();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransactionNew());
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TransactionEdit());
    }
}