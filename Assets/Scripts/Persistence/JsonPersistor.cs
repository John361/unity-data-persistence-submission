using System.IO;
using UnityEngine;

public abstract class JsonPersistor<T> : IPersistable<T>
{
    protected readonly string fileName;

    protected JsonPersistor(string fileName)
    {
        this.fileName = fileName;
    }

    public T Load()
    {
        string path = Application.persistentDataPath + this.GetFileNameWithExtension();

        if (File.Exists(path))
        {
            throw new FileNotFoundException("File not found");
        }

        string json = File.ReadAllText(path);
        T obj = JsonUtility.FromJson<T>(json);

        return obj;
    }

    public void Save(T obj)
    {
        string json = JsonUtility.ToJson(obj);
        File.WriteAllText(Application.persistentDataPath + this.GetFileNameWithExtension(), json);
    }

    protected string GetFileNameWithExtension()
    {
        return this.fileName + ".json";
    }
}
