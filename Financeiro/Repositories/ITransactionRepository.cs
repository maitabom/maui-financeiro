using Financeiro.Models;

namespace Financeiro.Repositories;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    void Delete(Transaction transaction);
    List<Transaction> GetAll();
    void Update(Transaction transaction);
}