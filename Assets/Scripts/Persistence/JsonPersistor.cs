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
        if (!this.DataExists())
        {
            throw new FileNotFoundException("File not found");
        }

        string path = Application.persistentDataPath + this.GetFileNameWithExtension();
        string json = File.ReadAllText(path);
        T obj = JsonUtility.FromJson<T>(json);

        return obj;
    }

    public void Save(T obj)
    {
        string json = JsonUtility.ToJson(obj);
        File.WriteAllText(Application.persistentDataPath + this.GetFileNameWithExtension(), json);
    }

    public bool DataExists()
    {
        string path = Application.persistentDataPath + this.GetFileNameWithExtension();
        return File.Exists(path);
    }

    protected string GetFileNameWithExtension()
    {
        return this.fileName + ".json";
    }
}
