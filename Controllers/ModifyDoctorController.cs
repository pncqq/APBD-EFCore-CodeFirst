using CW9.DTO_s;
using CW9.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ModifyDoctorController : ControllerBase
{
    private readonly IDoctorRepository _repository;

    public ModifyDoctorController(IDoctorRepository repository)
    {
        _repository = repository;
    }

    [HttpPut]
    public async Task<IActionResult> ModifyDoctorAsync([FromQuery] DoctorDto doctor)
    {
        var res = await _repository.ModifyDoctorAsync(doctor);

        return res ? Ok("Zmodyfikowano.") : throw new Exception("Blad przy modyfikacji");
    }
}