using System.Globalization;

namespace Financeiro.Libraries.Converters;

public class TransactionNameTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var name = value as string;

        return String.IsNullOrEmpty(name) ? String.Empty : name.First().ToString().ToUpper();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
