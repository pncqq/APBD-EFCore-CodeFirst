using CW9.Enums;
using CW9.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CW9.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetDoctorsController : ControllerBase
{
    private readonly IDoctorRepository _repository;


    public GetDoctorsController(IDoctorRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctorsAsync()
    {
        var res = await _repository.GetDoctorsAsync();
        return res is DatabaseStatus ? throw new Exception() : (IActionResult)Ok(res);
    }
}