using Assignment.Domain.Entities;

namespace Assignment.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Country> Countries { get; }

    DbSet<City> Cities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
