using CW9.DTO_s;
using CW9.Models;

namespace CW9.Repositories.Interfaces;

public interface IDoctorRepository
{
    public Task<dynamic> GetDoctorAsync(int idDoctor);
    public Task<dynamic> GetDoctorsAsync();
    public Task<bool> AddNewDoctorAsync(DoctorDto doctor);
    public Task<bool> ModifyDoctorAsync(DoctorDto doctor);
    public Task<bool> DeleteDoctorAsync(int idDoctor);
}