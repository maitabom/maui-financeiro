using CommunityToolkit.Mvvm.Messaging;
using Financeiro.Models;
using Financeiro.Repositories;
using System.Text;

namespace Financeiro.Views;

public partial class TransactionEdit : ContentPage
{
	private Transaction? _transaction;
    private readonly ITransactionRepository _repository;

    public TransactionEdit(ITransactionRepository repository)
	{
		InitializeComponent();
		_repository = repository;
    }

    private void imaClose_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (!Validate()) return;

        var transation = SaveData();

        WeakReferenceMessenger.Default.Send<Transaction>(transation);
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

    private Transaction SaveData()
    {
        Transaction transaction = new Transaction()
        {
            Id = _transaction?.Id ?? 0, // Se for uma edição, mantém o ID existente
            Type = rdbIncome.IsChecked ? TransactionType.Income : TransactionType.Expense,
            Date = dtpDate.Date,
            Name = txtName.Text.Trim(),
            Value = Double.Parse(txtValue.Text.Trim())
        };

        _repository.Update(transaction);

        return transaction;
    }

    private bool Validate()
    {
        bool isValid = true;
        StringBuilder error = new StringBuilder();

        if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrWhiteSpace(txtName.Text))
        {
            error.AppendLine("O campo Nome é obrigatório.");
            isValid = false;
        }

        if (String.IsNullOrEmpty(txtValue.Text) || String.IsNullOrWhiteSpace(txtValue.Text))
        {
            error.AppendLine("O campo Valor é obrigatório.");
            isValid = false;
        }

        double result;

        if (!String.IsNullOrEmpty(txtValue.Text) && !Double.TryParse(txtValue.Text, out result))
        {
            error.AppendLine("O campo Valor deve ser um número válido.");
            isValid = false;
        }

        if (!isValid)
        {
            lblError.IsVisible = true;
            lblError.Text = error.ToString();
        }

        return isValid;
    }
}