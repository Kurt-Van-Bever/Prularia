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

        public Personeelslidaccount? GetAccount(int id) => _context.Personeelslidaccounts.Find(id);
        public Personeelslid? GetPersoneelslid(int id) => _context.Personeelsleden.Find(id);
        public Securitygroep? GetSecuritygroep(int id) => _context.Securitygroepen.Include(g => g.Personeelsleden).FirstOrDefault(g => g.SecurityGroepId == id);
        public void UpdateAccount(Personeelslidaccount account)
        {
            _context.Update(account);
            _context.SaveChanges();
        }
        public void UpdateSecurityGroep(Securitygroep groep)
        {
            _context.Update(groep);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Securitygroep>?> GetSecurityGroepen() => await _context.Securitygroepen.Include(g => g.Personeelsleden).ToListAsync();

        public async Task<IEnumerable<Personeelslid>?> GetPersoneelsleden() => await _context.Personeelsleden.ToListAsync();
    }    
}
