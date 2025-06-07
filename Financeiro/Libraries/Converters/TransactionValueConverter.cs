using Financeiro.Models;
using System.Globalization;

namespace Financeiro.Libraries.Converters;

public class TransactionValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Transaction transaction)
        {
            var formattedValue = transaction.Value.ToString("C", culture);

            if (transaction.Type == TransactionType.Income)
            {
                return $"{formattedValue} ( + )";
            }
            else if (transaction.Type == TransactionType.Expense)
            {
                return $"{formattedValue} ( - )";
            }
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
