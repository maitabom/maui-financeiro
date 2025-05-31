using Financeiro.Views;

namespace Financeiro
{
    public partial class App : Application
    {
        private readonly TransactionList _transactionListPage;

        public App(TransactionList listPage)
        {
            _transactionListPage = listPage;
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(_transactionListPage));
        }
    }
}