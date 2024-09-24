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

    public Personeelslidaccount? GetAccount(int id) => _securityRepo.GetAccount(id);

    public void UpdatePassword(int id , string nieuwPasswoord)
    {
        var account = _securityRepo.GetAccount(id);
        if (account != null)
        {
            account.Paswoord = nieuwPasswoord;
            _securityRepo.UpdateAccount(account);
        }
    }

    public bool VerifyPaswoord(string paswoord, string paswoordHash)
    {
        return BCrypt.Net.BCrypt.Verify(paswoord, paswoordHash);
    }

    public string EncrypteerPaswoord(string paswoord)
    {
        return BCrypt.Net.BCrypt.HashPassword(paswoord);
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
