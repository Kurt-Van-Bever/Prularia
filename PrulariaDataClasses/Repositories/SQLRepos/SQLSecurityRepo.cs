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
    }
}
