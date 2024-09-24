using Prularia.Models;

namespace Prularia.Repositories
{
    public interface ISecurityRepo
    {
        Task<Personeelslidaccount?> TryGetPersoneelslidAccountAsync(string email);
        Task<Personeelslid?> TryGetPersoneelslidFromAccountAsync(Personeelslidaccount account);
        Personeelslidaccount? GetAccount(int id);
        void UpdateAccount(Personeelslidaccount account);
        List<Securitygroep> GetAllSecurityGroepen();
        Securitygroep? GetSecuritygroep(int id);
        List<Personeelslid> GetPersoneelsledenBySecuritygroepId(int id);
        List<Personeelslid> GetAllPersoneelsleden();
        Personeelslid? GetPersoneelslid(int id);

        void Add(Gebruikersaccount account);
    }    
}
