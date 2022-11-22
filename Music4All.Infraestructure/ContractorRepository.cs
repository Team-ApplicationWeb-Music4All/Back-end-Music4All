using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Context;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public class ContractorRepository :IContractorRepository
{
    private readonly Music4AllBDContext _music4AllBdContext;

    public ContractorRepository(Music4AllBDContext music4AllDbContext)
    {
        _music4AllBdContext = music4AllDbContext;
    }
    public async Task<List<Contractor>> getAll()
    {
       // new Music().Musician.Name
       return await _music4AllBdContext.Contractors
           .ToListAsync();
       
    }

    public async Task<Contractor> getEventById(int id)
    {
        return await _music4AllBdContext.Contractors
            .SingleOrDefaultAsync(contractor => contractor.Id == id);
    }

    public async Task<bool> create(Contractor contractor)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
               
                await _music4AllBdContext.Contractors.AddAsync(contractor);
                await _music4AllBdContext.SaveChangesAsync();
                await _music4AllBdContext.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _music4AllBdContext.Database.RollbackTransactionAsync();
            }
            finally
            {
                _music4AllBdContext.DisposeAsync();
            }
        }

        return true;
    }

    public async Task<bool> Update(int id, Contractor contractor)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingContractor = await _music4AllBdContext.Contractors.FindAsync(id);

                existingContractor.Name = contractor.Name;
                existingContractor.Age = contractor.Age;
                existingContractor.Description = contractor.Description;
                existingContractor.Events = contractor.Events;
                existingContractor.DateCreated = DateTime.Now;

                _music4AllBdContext.Contractors.Update(existingContractor);
                await _music4AllBdContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _music4AllBdContext.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var contractor = await _music4AllBdContext.Contractors.FindAsync(id);

        _music4AllBdContext.Contractors.Remove(contractor);
       await _music4AllBdContext.SaveChangesAsync();
        return true;
    }
}