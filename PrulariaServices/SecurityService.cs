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
    public Securitygroep? GetSecuritygroep(int id) => _securityRepo.GetSecuritygroep(id);

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

    public bool TryPersoneelAccountSetDisabled(int personeelslidAccountId, bool disabled)
    {
        Personeelslidaccount? acc = _securityRepo.GetAccount(personeelslidAccountId);
        if (acc == null) return false;

        acc.Disabled = disabled;
        _securityRepo.UpdateAccount(acc);
        return true;
    }

    public async Task<IEnumerable<Securitygroep>?> GetSecurityGroepen()
    {
        return await _securityRepo.GetSecurityGroepen();
    }
    public async Task<IEnumerable<Personeelslid>?> GetPersoneelsleden()
    {
        return await _securityRepo.GetPersoneelsleden();
    }

    public void RemovePersoneelFromSecurityGroep(int groepId, int personeelId)
    {
        Securitygroep groep = _securityRepo.GetSecuritygroep(groepId)!;
        Personeelslid lid = _securityRepo.GetPersoneelslid(personeelId)!;
        groep.Personeelsleden.Remove(lid);
        _securityRepo.UpdateSecurityGroep(groep);
    }

    public void AddPersoneelToSecurityGroup(int groepId, int personeelId)
    {
        Securitygroep groep = _securityRepo.GetSecuritygroep(groepId)!;
        Personeelslid lid = _securityRepo.GetPersoneelslid(personeelId)!;
        groep.Personeelsleden.Add(lid);
        _securityRepo.UpdateSecurityGroep(groep);
    }
}
