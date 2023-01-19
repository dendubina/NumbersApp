using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using NumbersApp.WEB.Interfaces;

namespace NumbersApp.WEB.Controllers;

[ApiController]
public class NumbersController : ControllerBase
{
    private readonly INumbersService _numbersService;

    public NumbersController(INumbersService numbersService)
    {
        _numbersService = numbersService;
    }

    [HttpPost("prime/[action]")]
    public IActionResult IsThisAPrimeNumber([Required][FromBody] int number)
    {
        return _numbersService.IsPrime(number)
            ? Ok("Number is prime")
            : BadRequest("Number is not prime");
    }
}