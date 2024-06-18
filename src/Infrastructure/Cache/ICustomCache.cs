namespace Assignment.Infrastructure.Cache;
public interface ICustomCache
{
    object Get(string key);

    void Set(string key, object value);

    object GetOrCreate(string key, object value);
}
