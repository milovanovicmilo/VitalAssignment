namespace Assignment.Infrastructure.Cache;
public class CustomCache : ICustomCache
{
    private readonly IDictionary<string, object> _cache;

    public CustomCache()
    {
        _cache = new Dictionary<string, object>();
    }

    public object Get(string key)
    {
        _cache.TryGetValue(key, out var cachedItem);
        return cachedItem!;
    }

    public void Set(string key, object value) { _cache[key] = value; }

    public object GetOrCreate(string key, object item)
    {
        var cachedItem = Get(key);
        if (cachedItem == null)
        {
            _cache[key] = new object();
            Set(key, item!);
            cachedItem = _cache[key];
        }
        return cachedItem;
    }
}
