using Financeiro.Models;
using System.Globalization;

namespace Financeiro.Libraries.Converters;

public class TransactionColortConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Transaction transaction)
        {
            if (transaction.Type == TransactionType.Income)
            {
                return Color.FromArgb("#939E5A");
            }
            else if (transaction.Type == TransactionType.Expense)
            {
                return Color.FromArgb("#FF0000");
            }
        }

        return Colors.Black;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
