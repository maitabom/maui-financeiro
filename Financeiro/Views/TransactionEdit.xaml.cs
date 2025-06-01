using Financeiro.Models;

namespace Financeiro.Views;

public partial class TransactionEdit : ContentPage
{
	private Transaction? _transaction;

    public TransactionEdit()
	{
		InitializeComponent();
	}

    private void imaClose_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

	public void SetTransaction(Transaction transaction)
	{
		_transaction = transaction;

		// Preencher campos com os dados de transaction
		txtName.Text = transaction.Name;
		txtValue.Text = transaction.Value.ToString("F2"); // Ajuste conforme o tipo de Value
		dtpDate.Date = transaction.Date.Date;

		// Supondo que Transaction tem uma propriedade bool IsIncome
		rdbIncome.IsChecked = transaction.Type == TransactionType.Income;
		rdbExpense.IsChecked = transaction.Type == TransactionType.Expense;
    }
}