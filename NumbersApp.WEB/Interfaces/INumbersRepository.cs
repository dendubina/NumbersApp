using NumbersApp.WEB.EF.Entities;

namespace NumbersApp.WEB.Interfaces
{
    public interface INumbersRepository
    {
        Task AddAsync(Number number);

        Task<Number?> GetByValueAsync(int value);
    }
}
