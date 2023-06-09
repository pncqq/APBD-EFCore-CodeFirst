using CW9.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DeleteDoctorController : ControllerBase
{
    private readonly IDoctorRepository _repository;

    public DeleteDoctorController(IDoctorRepository repository)
    {
        _repository = repository;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDoctorAsync(int idDoctor)
    {
        var res = await _repository.DeleteDoctorAsync(idDoctor);

        return res ? Ok("Usunięto.") : throw new Exception("Blad przy usuwaniu");
    }
}