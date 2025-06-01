using CommunityToolkit.Mvvm.Messaging;
using Financeiro.Models;
using Financeiro.Repositories;

namespace Financeiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;

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

    private void btnEdit_Clicked(object sender, EventArgs e)
    {
        if (Handler?.MauiContext?.Services.GetService<TransactionEdit>() is TransactionEdit transactionEdit)
        {
            Navigation.PushModalAsync(transactionEdit);
        }
        else
        {
            DisplayAlert("Erro", "Não foi possível inicializar a página de nova transação.", "OK");
        }
    }

    private void LoadData()
    {
        var list = _transactionRepository.GetAll();
        clvTransacions.ItemsSource = list;
    }
}