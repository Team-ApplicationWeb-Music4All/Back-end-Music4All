using Music4All.Infraestructure;
using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public class ContractorDomain: IContractorDomain
{
    private readonly IContractorRepository _contractorRepository;
     
    public ContractorDomain(IContractorRepository contractorRepository)
    {
        _contractorRepository = contractorRepository;
    }
    public async Task<List<Contractor>> getAll()
    {
        
        return await _contractorRepository.getAll();
    }

    public async Task<Contractor> getEventById(int id)
    {
        return await _contractorRepository.getEventById(id);
    }

    public async Task<bool> createEvent(Contractor contractor)
    {
        
        contractor.Id = contractor.Id;
        contractor.Name = contractor.Name;
        contractor.Description = contractor.Description;
        contractor.Age = contractor.Age;
        return await _contractorRepository.create(contractor);
    }

    public async Task<bool> updateEvent(int id, Contractor contractor)
    {
        return await _contractorRepository.Update(id, contractor);
    }

    public async Task<bool> deleteEvent(int id)
    {
        return await _contractorRepository.Delete(id);
    }
}