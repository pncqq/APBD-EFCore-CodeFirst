using CW9.DTO_s;
using CW9.Enums;
using CW9.Models;
using CW9.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetPrescriptionController : ControllerBase
{
    private readonly IPrescriptionRepository _repository;

    public GetPrescriptionController(IPrescriptionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("/{idPresc:int}")]
    public async Task<IActionResult> GetPrescriptionAsync(int idPresc)
    {
        var res = await _repository.GetPrescriptionAsync(idPresc);

        return res is Prescription
            ? (IActionResult)Ok(res)
            : throw new Exception("Nie znaleziono recepty lub recepta niekompletna.");
    }
}