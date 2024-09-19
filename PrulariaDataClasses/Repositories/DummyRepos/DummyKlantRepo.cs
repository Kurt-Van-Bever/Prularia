using Prularia.Models;
using System;

namespace Prularia.Repositories;

public class DummyKlantRepo : IKlantRepo
{
    public Klant? Get(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Klant klant)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> GetKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> GetNatuurlijkePersonenAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> GetRechtspersonenAsync()
    {
        throw new NotImplementedException();
    }
    //Task<ICollection<Contactpersoon>> GetContactpersonenAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}

    Task<ICollection<Contactpersoon>> IKlantRepo.GetContactpersonenAsync(int id)
    {
        throw new NotImplementedException();
    }
}
