namespace VendingMachine.CleanArchitecture.Infrastructure.Interfaces;

public interface IMenuRepository
{
  Task<string?> GetValuefromResource(string resourcetype, string key, string lang);

}
