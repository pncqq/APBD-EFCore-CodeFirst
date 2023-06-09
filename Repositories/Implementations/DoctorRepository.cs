using CW9.Context;
using CW9.DTO_s;
using CW9.Enums;
using CW9.Models;
using CW9.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CW9.Repositories.Implementations;

public class DoctorRepository : IDoctorRepository
{
    private readonly MainDbContext _context;

    public DoctorRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<dynamic> GetDoctorAsync(int idDoctor)
    {
        try
        {
            var doctor = await _context.Doctors
                .Where(d => d.IdDoctor == idDoctor)
                .FirstAsync();

            return doctor;
        }
        catch (Exception e)
        {
            return DatabaseStatus.DoctorNotFound;
        }
    }

    public async Task<dynamic> GetDoctorsAsync()
    {
        try
        {
            var doctors = await _context.Doctors
                .ToListAsync();

            return doctors;
        }
        catch (Exception e)
        {
            return DatabaseStatus.DoctorNotFound;
        }
    }

    public async Task<bool> AddNewDoctorAsync(DoctorDto doctor)
    {
        //Sprawdzamy czy doktor o danym id istnieje
        try
        {
            await _context.Doctors
                .Where(d => d.IdDoctor == doctor.IdDoctor)
                .SingleAsync();
        }
        catch (Exception e)
        {
            //Jesli nie - dodaj do bazy
            await _context.Doctors
                .AddAsync(new Doctor
                {
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                });

            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> ModifyDoctorAsync(DoctorDto doctor)
    {
        try
        {
            var doc = await _context.Doctors
                .SingleAsync(d => d.IdDoctor == doctor.IdDoctor);

            doc.Email = doctor.Email;
            doc.FirstName = doctor.FirstName;
            doc.LastName = doctor.LastName;

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeleteDoctorAsync(int idDoctor)
    {
        var doctorToDelete = new Doctor
        {
            IdDoctor = idDoctor
        };

        try
        {
            _context.Doctors.Attach(doctorToDelete);
            _context.Doctors.Remove(doctorToDelete);
        }
        catch (Exception e)
        {
            return false;
        }

        await _context.SaveChangesAsync();

        return true;
    }
}