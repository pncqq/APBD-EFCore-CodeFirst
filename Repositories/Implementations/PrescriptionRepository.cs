using CW9.DTO_s;
using CW9.Enums;
using CW9.Models;
using CW9.Context;
using CW9.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CW9.Repositories.Implementations;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly MainDbContext _context;

    public PrescriptionRepository(MainDbContext context)
    {
        _context = context;
    }


    public async Task<dynamic> GetPrescriptionAsync(int idPresc)
    {
        return await _context.Prescriptions
            .Where(p => p.IdPrescription == idPresc)
            .Include(prescription => prescription.Doctor)
            .Include(p => p.Patient)
            .Include(p => p.PrescriptionMedicament)
            .ThenInclude(pm => pm.Medicament)
            .FirstAsync();
    }
}