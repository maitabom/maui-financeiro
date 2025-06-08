using CommunityToolkit.Mvvm.Messaging;
using Financeiro.Models;
using Financeiro.Repositories;

namespace Financeiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;
    private Color? _colorOrigin;
    private string? _textOrigin;


    public TransactionList(ITransactionRepository repository)
    {
        _transactionRepository = repository;

        InitializeComponent();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        LoadData();

        WeakReferenceMessenger.Default.Register<Transaction>(this, (sender, message) =>
        {
            LoadData();
        });
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        if (Handler?.MauiContext?.Services.GetService<TransactionNew>() is TransactionNew transactionAdd)
        {
            Navigation.PushModalAsync(transactionAdd);
        }
        else
        {
            DisplayAlert("Erro", "Não foi possível inicializar a página de nova transação.", "OK");
        }
    }

    private void GridItemTransaction_Tapped(object sender, TappedEventArgs e)
    {

        if (Handler?.MauiContext?.Services.GetService<TransactionEdit>() is TransactionEdit transactionEdit)
        {
            var grid = (Grid)sender;
            var recognizer = (TapGestureRecognizer)grid.GestureRecognizers[0];
            var transaction = recognizer.CommandParameter as Transaction;

            if (transaction != null) 
            {
                transactionEdit.SetTransaction(transaction);
                Navigation.PushModalAsync(transactionEdit);
            }
        }
        else
        {
            DisplayAlert("Erro", "Não foi possível inicializar a página de nova transação.", "OK");
        }
    }

    private async void BorderLabelTransaction_Tapped(object sender, TappedEventArgs e)
    {
        await AnimationBorder((Border)sender, true);

        bool result = await DisplayAlert("Excluir", "Deseja realmente excluir esta transação?", "Sim", "Não");


        if (result)
        {
            var border = (Border)sender;
            var recognizer = (TapGestureRecognizer)border.GestureRecognizers[0];
            var transaction = recognizer.CommandParameter as Transaction;

            if (transaction != null)
            {
                _transactionRepository.Delete(transaction);
                LoadData();
            }
        }
        else
        {
            await AnimationBorder((Border)sender, false);
        }
    }

    private void LoadData()
    {
        var list = _transactionRepository.GetAll();
        clvTransacions.ItemsSource = list;

        var total = list.Sum(x => x.Type == TransactionType.Income ? x.Value : -x.Value);
        var incomes = list.Where(x => x.Type == TransactionType.Income).Sum(x => x.Value);
        var expenses = list.Where(x => x.Type == TransactionType.Expense).Sum(x => x.Value);

        lblBalance.Text = total.ToString("C2");
        lblIncome.Text = incomes.ToString("C2");   
        lblExpense.Text = expenses.ToString("C2");
    }

    private async Task AnimationBorder(Border border, bool isDeleteAnimation)
    {
        if (isDeleteAnimation)
        {
            await border.RotateYTo(180, 1000);
            _colorOrigin = border.BackgroundColor;

            border.BackgroundColor = Colors.Red;
            var label = border.Content as Label;

            if (label != null)
            {
                _textOrigin = label.Text;

                label.Text = "X";
                label.TextColor = Colors.White;
            }
        }
        else
        {
            await border.RotateYTo(0, 1000);

            border.BackgroundColor = _colorOrigin ?? Colors.Transparent;

            var label = border.Content as Label;

            if (label != null && _textOrigin != null)
            {
                label.Text = _textOrigin;
                label.TextColor = Colors.Black;
            }
        }
    }
}