using CW9.DTO_s;
using CW9.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AddDoctorController : ControllerBase
{
    private readonly IDoctorRepository _repository;

    public AddDoctorController(IDoctorRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctorAsync([FromBody] DoctorDto doctor)
    {
        var res = await _repository.AddNewDoctorAsync(doctor);
        return res ? StatusCode(201,"Dodano.") : throw new Exception("Blad przy dodawaniu");
    }
}