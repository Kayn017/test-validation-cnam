namespace CreditImmo.Models.Interfaces;

using CreditImmo.Controllers.Interfaces;

public interface ISerialisable
{
    public void Serialize(ISerializer serializer);
}