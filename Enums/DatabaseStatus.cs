using CW9.Models;

namespace CW9.Enums;

public enum DatabaseStatus
{
    UserAlreadyInDb,
    DoctorNotFound,
    UserAdded,
    UserNotFound,
    WrongPassword,
    TokenExpired
}