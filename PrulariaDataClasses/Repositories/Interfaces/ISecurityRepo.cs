using Prularia.Models;

namespace Prularia.Repositories
{
    public interface ISecurityRepo
    {
        Task<Personeelslidaccount?> TryGetPersoneelslidAccountAsync(string email);
        Task<Personeelslid?> TryGetPersoneelslidFromAccountAsync(Personeelslidaccount account);
        Personeelslidaccount? GetAccount(int id);
        Personeelslid? GetPersoneelslid(int id);
        Securitygroep? GetSecuritygroep(int id);
        void UpdateAccount(Personeelslidaccount account);
        void UpdateSecurityGroep(Securitygroep groep);
        Task<IEnumerable<Securitygroep>?> GetSecurityGroepen();
        Task<IEnumerable<Personeelslid>?> GetPersoneelsleden();
    }    
}
