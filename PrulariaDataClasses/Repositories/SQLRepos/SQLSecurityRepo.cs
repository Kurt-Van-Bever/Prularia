using Prularia.Models;
using PrulariaModels.Repositories.Interfaces;

namespace PrulariaModels.Repositories.SQLRepos;
public class SQLSecurityRepo : ISecurityRepo
{
    private readonly PrulariaContext _context;
    public SQLSecurityRepo(PrulariaContext context)
    {
        _context = context;
    }

    public Personeelslidaccount? GetAccount(int id) => _context.Personeelslidaccount.Find(id);

    public void UpdateAccount(Personeelslidaccount account)
    {
        _context.Update(account);
        _context.SaveChanges();
    }
}
