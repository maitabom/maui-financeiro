using Financeiro.Models;
using LiteDB;

namespace Financeiro.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly LiteDatabase _database;
    private readonly string _collectionName = "transactions";

    public TransactionRepository(LiteDatabase database)
    {
        _database = database;
    }

    public List<Transaction> GetAll()
    {
        return _database.GetCollection<Transaction>(_collectionName)
                        .Query()
                        .OrderByDescending(t => t.Date)
                        .ToList();
    }

    public void Add(Transaction transaction)
    {
        var collection = _database.GetCollection<Transaction>(_collectionName);
        collection.Insert(transaction);
        collection.EnsureIndex(x => x.Id);
    }

    public void Update(Transaction transaction)
    {
        var collection = _database.GetCollection<Transaction>(_collectionName);
        collection.Update(transaction);
    }

    public void Delete(Transaction transacion)
    {
        var collection = _database.GetCollection<Transaction>(_collectionName);
        collection.Delete(transacion.Id);
    }
}
