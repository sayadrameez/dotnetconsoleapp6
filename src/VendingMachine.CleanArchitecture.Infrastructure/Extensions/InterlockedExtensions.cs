namespace VendingMachine.CleanArchitecture.Infrastructure.Extensions;

public static class InterlockedExtensions
{
  public static decimal Add(ref decimal location1, decimal value)
  {
    location1 = value + location1;
    return location1;
    //decimal newCurrentValue = location1; // non-volatile read, so may be stale
    //while (true)
    //{
    //  decimal currentValue = newCurrentValue;
    //  decimal newValue = currentValue + value;
    //  //TODO: finding a locking mechanism
    //  //newCurrentValue = Interlocked.CompareExchange(ref location1, newValue, currentValue);

    //  //if (newCurrentValue == currentValue)
    //  return newValue;
    //}
  }
}
