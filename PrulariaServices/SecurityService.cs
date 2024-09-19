using Prularia.Models;
using Prularia.Repositories;

namespace Prularia.Services;

public class SecurityService
{
    private readonly ISecurityRepo _securityRepo;

    public SecurityService(ISecurityRepo securityRepo)
    {
        _securityRepo = securityRepo; 
    }

    public async Task<Personeelslid?> TryGetPersoneelslidFromLogin(string email, string pw)
    {
        Personeelslidaccount? acc = await _securityRepo.TryGetPersoneelslidAccountAsync(email);
        if (acc == null) return null;
        if (acc.Disabled) return null;
        //if (BCrypt.Net.BCrypt.Verify(pw, acc.Paswoord) == false) return null;

        return await _securityRepo.TryGetPersoneelslidFromAccountAsync(acc);
    }
}
