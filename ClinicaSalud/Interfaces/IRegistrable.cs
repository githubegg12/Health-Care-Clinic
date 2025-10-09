using ClinicaSalud.Models;

namespace ClinicaSalud.Interfaces;

public interface IRegistrable<T>
{
    T Register(T patient);
}