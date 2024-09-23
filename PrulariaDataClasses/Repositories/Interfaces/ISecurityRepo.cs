using Prularia.Models;

namespace Prularia.Repositories
{
    public interface ISecurityRepo
    {
        Task<Personeelslidaccount?> TryGetPersoneelslidAccountAsync(string email);
        Task<Personeelslid?> TryGetPersoneelslidFromAccountAsync(Personeelslidaccount account);
        Personeelslidaccount? GetAccount(int id);
        Task<Personeelslidaccount?> GetAccountAsync(int id);
        void UpdateAccount(Personeelslidaccount account);
    }    
}
