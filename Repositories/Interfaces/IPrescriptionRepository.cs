using CW9.DTO_s;
using CW9.Models;

namespace CW9.Repositories.Interfaces;

public interface IPrescriptionRepository
{
    public Task<dynamic> GetPrescriptionAsync(int idPresc);
}