using Prularia.Models;
using PrulariaModels.Repositories.Interfaces;

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

}
