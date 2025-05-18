namespace Financeiro.Views;

public partial class TransactionList : ContentPage
{
    public TransactionList()
    {
        InitializeComponent();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        if (Application.Current?.Windows.FirstOrDefault() is { } mainWindow)
        {
            mainWindow.Page = new TransactionNew();
        }
    }
}