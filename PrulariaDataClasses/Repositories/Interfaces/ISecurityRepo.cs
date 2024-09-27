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
        List<Securitygroep> GetAllSecurityGroepen();
        Securitygroep? GetSecuritygroep(int id);
        List<Personeelslid> GetPersoneelsledenBySecuritygroepId(int id);
        List<Personeelslid> GetAllPersoneelsleden();
        Personeelslid? GetPersoneelslid(int id);
        List<Personeelslid> GetAllPersoneelsledenNotInGroup(int id);
        void AddPersoneelslidToSecuritygroep(int gebruikerId, int groepId);
        void RemovePersoneelslidToSecuritygroep(int gebruikerId, int groepId);
        void AddPersoneelslidAccount(Personeelslidaccount account);
        Task<List<Personeelslid>> SearchPersoneelsLid(string searchValue);
        void AddPersoneelslid(Personeelslid account);

        Task<List<Personeelslid>> SearchGetPersoneelsledenBySecuritygroepId(string searchValue, int id);

        Task<List<Personeelslid>> SearchAllPersoneelsLedenNotInGroep(int id, string searchValue);
    }      
}
