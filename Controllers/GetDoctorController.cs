using CW9.Enums;
using CW9.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetDoctorController : ControllerBase
{
    private readonly IDoctorRepository _repository;

    public GetDoctorController(IDoctorRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{idDoctor:int}")]
    public async Task<IActionResult> GetDoctorAsync(int idDoctor)
    {
        var res = await _repository.GetDoctorAsync(idDoctor);

        return res is DatabaseStatus ? throw new Exception() : (IActionResult)Ok(res);
    }
}