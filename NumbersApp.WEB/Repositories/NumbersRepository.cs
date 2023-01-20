using Microsoft.EntityFrameworkCore;
using NumbersApp.WEB.EF;
using NumbersApp.WEB.EF.Entities;
using NumbersApp.WEB.Interfaces;

namespace NumbersApp.WEB.Repositories;

public class NumbersRepository : INumbersRepository
{
    private readonly AppDbContext _dbContext;

    public NumbersRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Number number)
    {
        await _dbContext.Numbers.AddAsync(number);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Number?> GetByValueAsync(int value)
        => _dbContext.Numbers.FirstOrDefaultAsync(x => x.Value == value);
}