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
            var acc = await _context.Personeelslidaccounts.FirstOrDefaultAsync(a => a.Emailadres == email);
            if (acc == null) return null;
            return acc;
        }

        public async Task<Personeelslid?> TryGetPersoneelslidFromAccountAsync(Personeelslidaccount account)
        {   // database bevat 1-veel relatie, maar is eigenlijk 1-1
            return await _context.Personeelsleden.Include(l => l.SecurityGroepen).FirstOrDefaultAsync(l => l.PersoneelslidAccountId == account.PersoneelslidAccountId);
        }

        public Personeelslidaccount? GetAccount(int id) => _context.Personeelslidaccounts.Find(id);
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

    }


}
