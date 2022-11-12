using Music4All.Infraestructure;
using Music4All.Infraestructure.Models;
using Music4All.Shared;

namespace Music4All.Domain;

public class EventDomain : IEventDomain
{
    
    private readonly IEventRepository _eventRepository;
     
    public EventDomain(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task<List<Event>> getAll()
    {
        
        return await _eventRepository.getAll();
    }

    public async Task<Event> getEventById(int id)
    {
        return await _eventRepository.getEventById(id);
    }

    public async Task<bool> createEvent(Event evento)
    {

        if (evento.Description == evento.Title)
        {
            throw new ArgumentException("Description and Name are equeals");
        }

        evento.Id = evento.Id;
        evento.Title = evento.Title.ReplaceBlankByUndercores();
        evento.Description = evento.Description.ReplaceBlankByUndercores();
     //   evento.Title = evento.ContractorId.ToString();
      //  evento.Contractor = evento.Contractor;
        return await _eventRepository.create(evento);
    }

    public async Task<bool> updateEvent(int id, Event evento)
    {
        return await _eventRepository.Update(id, evento);
    }

    public async Task<bool> deleteEvent(int id)
    {
        return await _eventRepository.Delete(id);
    }
}