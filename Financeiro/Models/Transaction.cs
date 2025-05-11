using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Models;

public class Transaction
{
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public required String Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public Decimal Value { get; set; }
}
