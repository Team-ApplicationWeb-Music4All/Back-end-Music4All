using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IContractorDomain
{
    Task<List<Contractor>> getAll();
    Task<Contractor> getEventById(int id);
    Task<bool> createEvent(Contractor contractor);
    Task<bool> updateEvent(int id, Contractor contractor);
    Task<bool> deleteEvent(int id);
}