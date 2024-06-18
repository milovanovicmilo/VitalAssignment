namespace Assignment.Infrastructure.Cache;
public interface ICustomCache
{
    object Get(string key);

    void Set(string key, object value);

    object GetOrAdd(string key, object value);
}
