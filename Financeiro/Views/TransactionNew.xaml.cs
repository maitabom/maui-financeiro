using CommunityToolkit.Mvvm.Messaging;
using Financeiro.Models;
using Financeiro.Repositories;
using System.Text;

namespace Financeiro.Views;

public partial class TransactionNew : ContentPage
{
	private readonly ITransactionRepository _repository;

    public TransactionNew(ITransactionRepository repository)
	{
		InitializeComponent();
        _repository = repository;
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

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

    private Transaction SaveData()
    {
        Transaction transaction = new Transaction()
        {
            Type = rdbIncome.IsChecked ? TransactionType.Income : TransactionType.Expense,
            Date = dtpDate.Date,
            Name = txtName.Text.Trim(),
            Value = Double.Parse(txtValue.Text.Trim())
        };

        _repository.Add(transaction);

        return transaction;
    }

    private bool Validate()
    {
        bool isValid = true;
        StringBuilder error = new StringBuilder();

        if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrWhiteSpace(txtName.Text))
        {     
            error.AppendLine("O campo Nome � obrigat�rio.");
            isValid = false;
        }

        if (String.IsNullOrEmpty(txtValue.Text) || String.IsNullOrWhiteSpace(txtValue.Text))
        {
            error.AppendLine("O campo Valor � obrigat�rio.");
            isValid = false;
        }

        double result;

        if (!String.IsNullOrEmpty(txtValue.Text) && !Double.TryParse(txtValue.Text, out result))
        {
            error.AppendLine("O campo Valor deve ser um n�mero v�lido.");
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