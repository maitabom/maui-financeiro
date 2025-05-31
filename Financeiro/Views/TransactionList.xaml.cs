namespace Financeiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionNew _transactionAddPage;
    private readonly TransactionEdit _transactionEditPage;

    public TransactionList(TransactionNew transactionAdd, TransactionEdit transactionEdit)
    {
        _transactionAddPage = transactionAdd;
        _transactionEditPage = transactionEdit;

        InitializeComponent();
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_transactionAddPage);
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(_transactionEditPage);
    }
}