using Prularia.Models;

namespace PrulariaModels.Repositories.Interfaces;
public interface ISecurityRepo
{
    Personeelslidaccount? GetAccount(int id);
    void UpdateAccount(Personeelslidaccount account);
}
