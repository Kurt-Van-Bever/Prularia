using Microsoft.EntityFrameworkCore;
using Prularia.Models;

namespace Prularia.Repositories
{
    public class SQLSecurityRepo : ISecurityRepo
    {
        private readonly PrulariaContext _context;

        public SQLSecurityRepo(PrulariaContext context)
        {
            _context = context;
        }

        public async Task<Personeelslidaccount?> TryGetPersoneelslidAccountAsync(string email)
        {
            return await _context.Personeelslidaccounts.FirstOrDefaultAsync(a => a.Emailadres == email);
        }

        public async Task<Personeelslid?> TryGetPersoneelslidFromAccountAsync(Personeelslidaccount account)
        {   // database bevat 1-veel relatie, maar is eigenlijk 1-1
            return await _context.Personeelsleden.Include(l => l.SecurityGroepen).FirstOrDefaultAsync(l => l.PersoneelslidAccountId == account.PersoneelslidAccountId);
        }

        public Personeelslidaccount? GetAccount(int id) => _context.Personeelslidaccounts
            .Include(p => p.Personeelsleden)
            .FirstOrDefault(p => p.PersoneelslidAccountId == id);
        public void UpdateAccount(Personeelslidaccount account)
        {
            _context.Update(account);
            _context.SaveChanges();
        }

        public List<Securitygroep> GetAllSecurityGroepen() => _context.Securitygroepen.ToList();

        public Securitygroep? GetSecuritygroep(int id) => _context.Securitygroepen.Find(id);

        public List<Personeelslid> GetPersoneelsledenBySecuritygroepId(int id)
            => _context.Personeelsleden
                .Where(p => p.SecurityGroepen.Any(g => g.SecurityGroepId == id))
                .Include(p => p.PersoneelslidAccount)
                .Include(p => p.SecurityGroepen)
                .ToList();
        public List<Personeelslid> GetAllPersoneelsleden()
                => _context.Personeelsleden
                        .Include(acc => acc.PersoneelslidAccount)
                        .ToList();

        public Personeelslid? GetPersoneelslid(int id)
        {
            var personeelslid = _context.Personeelsleden
            .Include(p => p.PersoneelslidAccount)
            .Include(p => p.SecurityGroepen)
            .SingleOrDefault(p => p.PersoneelslidId == id);

            return personeelslid;
        }

        public List<Personeelslid> GetAllPersoneelsledenNotInGroup(int id)
        {
            var groep = _context.Securitygroepen.Find(id);

            var personeelsleden = _context.Personeelsleden
                .Where(p => !p.SecurityGroepen.Contains(groep!))
                .Include(p => p.PersoneelslidAccount)
                .Include(p => p.SecurityGroepen)
                .ToList();

            return personeelsleden;
        }

        public void AddPersoneelslidToSecuritygroep(int gebruikerId, int groepId)
        {
            var groep = _context.Securitygroepen.Find(groepId);
            var gebruiker = _context.Personeelsleden.Find(gebruikerId);
            if (gebruiker != null && groep != null)
                groep.Personeelsleden.Add(gebruiker);
            _context.SaveChanges();
        }

        public void RemovePersoneelslidToSecuritygroep(int gebruikerId, int groepId)
        {
            var groep = _context.Securitygroepen
                .Include(s => s.Personeelsleden)
                .FirstOrDefault(s => s.SecurityGroepId == groepId);
            var gebruiker = _context.Personeelsleden.Find(gebruikerId);
            if (gebruiker != null && groep != null)
                groep.Personeelsleden.Remove(gebruiker);
            _context.SaveChanges();
        }

        public async Task<Personeelslidaccount?> GetAccountAsync(int id)
        {
            return await _context.Personeelslidaccounts
                .Include(p => p.Personeelsleden)
                .FirstOrDefaultAsync(p => p.PersoneelslidAccountId == id);
        }
        public void AddPersoneelslidAccount(Personeelslidaccount account)
        {
            _context.Personeelslidaccounts.Add(account);
            _context.SaveChanges();
        }
        public void AddPersoneelslid(Personeelslid lid)
        {
            _context.Personeelsleden.Add(lid);
            _context.SaveChanges();
        }



    }


}
        
