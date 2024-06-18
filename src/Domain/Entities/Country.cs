
namespace Assignment.Domain.Entities;
public class Country : BaseAuditableEntity
{
    public string? Name { get; set; }
    public IList<City> Cities { get; private set; } = new List<City>();
}
