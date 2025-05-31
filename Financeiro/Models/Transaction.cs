using LiteDB;

namespace Financeiro.Models;

public class Transaction
{
    [BsonId]
    public int Id { get; set; }
    public TransactionType Type { get; set; }
    public required String Name { get; set; }
    public DateTimeOffset Date { get; set; }
    public Double Value { get; set; }
}
