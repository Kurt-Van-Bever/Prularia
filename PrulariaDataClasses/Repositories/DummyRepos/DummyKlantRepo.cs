﻿using Prularia.Models;

namespace Prularia.Repositories;

public class DummyKlantRepo : IKlantRepo
{
    public Klant? Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Klant>> GetKlantenAsync()
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

    Task<ICollection<Contactpersoon>> IKlantRepo.GetContactpersonenAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> DisableKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> ActivateAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Klant?> ActivateKlantAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Contactpersoon?> DisableContactpersoonAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Contactpersoon?> ActivateContactpersoonAsync(int id)
    {
        throw new NotImplementedException();
    }
}
