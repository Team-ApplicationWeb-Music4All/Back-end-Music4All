using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IMusicianDomain
{
    Task<List<Musician>> getAll();
    Task<Musician> getEventById(int id);
    Task<bool> createEvent(Musician musician);
    Task<bool> updateEvent(int id, Musician musician);
    Task<bool> deleteEvent(int id);
}