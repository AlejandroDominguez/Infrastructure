namespace CrossCutting.Core.Cache
{
    public interface ICache
    {
        void Set(string key, object value);

        void Remove(string key);

        object Get(string key);

        void CleanAll();

        object this[string key] { get; set; }
    }
}
