namespace CreditImmo.Models.Interfaces;

public interface IArgumentInjectable
{
    public void Initialize(Dictionary<string, string> args);
}