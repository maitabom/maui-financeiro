using Financeiro.Views;
using System.Globalization;

namespace Financeiro
{
    public partial class App : Application
    {
        private readonly TransactionList _transactionListPage;

        public App(TransactionList listPage)
        {
            _transactionListPage = listPage;
            InitializeComponent();

            var culture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(_transactionListPage));
        }
    }
}