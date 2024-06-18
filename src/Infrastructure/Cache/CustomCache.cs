using System.Collections.Concurrent;

namespace Assignment.Infrastructure.Cache;
public class CustomCache : ICustomCache
{
    private readonly ConcurrentDictionary<string, object> _cache;

    public CustomCache()
    {
        _cache = new ConcurrentDictionary<string, object>();
    }

    public object Get(string key)
    {
        _cache.TryGetValue(key, out var cachedItem);
        return cachedItem!;
    }

    public void Set(string key, object value) { _cache[key] = value; }

    public object GetOrAdd(string key, object item)
    {
        return _cache.GetOrAdd(key, item);
    }
}
