using System.Text;

namespace Financeiro.Views;

public partial class TransactionNew : ContentPage
{
	public TransactionNew()
	{
		InitializeComponent();
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

        if (!Double.TryParse(txtValue.Text, out result))
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