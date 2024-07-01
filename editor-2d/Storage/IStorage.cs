namespace Krista
{
    public interface IStorage
    {
        void SaveData<T>(string path, T data);
        T LoadData<T>(string path);
    }
}