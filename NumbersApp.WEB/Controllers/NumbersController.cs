using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using NumbersApp.WEB.EF.Entities;
using NumbersApp.WEB.Extensions;
using NumbersApp.WEB.Interfaces;

namespace NumbersApp.WEB.Controllers;

[ApiController]
public class NumbersController : ControllerBase
{
    private readonly INumbersRepository _numbersRepository;

    public NumbersController(INumbersRepository numbersRepository)
    {
        _numbersRepository = numbersRepository;
    }

    [HttpPost("prime/[action]")]
    public async Task<IActionResult> IsThisAPrimeNumber([Required][FromBody] int number)
    {
        var entity = await _numbersRepository.GetByValueAsync(number);

        bool isPrime;

        if (entity is not null)
        {
            isPrime = entity.IsPrime;
        }
        else
        {
            var created = await AddNumber(number);
            isPrime = created.IsPrime;
        }

        return isPrime
            ? Ok($"Number {number} is prime")
            : BadRequest($"Number {number} is not prime");
    }

    private async Task<Number> AddNumber(int number)
    {
        var entity = new Number
        {
            Value = number,
            IsPrime = number.IsPrime()
        };

        await _numbersRepository.AddAsync(entity);

        return entity;
    }
}