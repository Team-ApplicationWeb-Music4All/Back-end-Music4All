using Music4All.Infraestructure;
using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public class MusicianDomain : IMusicianDomain
{
    private readonly IMusicianRepository _musicianRepository;
    private IMusicianDomain _musicianDomainImplementation;

    public MusicianDomain(IMusicianRepository musicianRepository)
    {
        _musicianRepository = musicianRepository;
    }
    public async Task<List<Musician>> getAll()
    {
        
        return await _musicianRepository.getAll();
    }

    public async Task<Musician> getEventById(int id)
    {
        return await _musicianRepository.getEventById(id);
    }

    public async Task<bool> createEvent(Musician musician)
    {
        
        musician.Id = musician.Id;
        musician.Name = musician.Name;
        musician.Description = musician.Description;
        musician.Age = musician.Age;
        return await _musicianRepository.create(musician);
    }

    public async Task<bool> updateEvent(int id, Musician musician)
    {
        return await _musicianRepository.Update(id, musician);
    }

    public async Task<bool> deleteEvent(int id)
    {
        return await _musicianRepository.Delete(id);
    }
}