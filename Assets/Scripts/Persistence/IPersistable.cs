public interface IPersistable<T>
{
    public void Save(T obj);
    public T Load();
}
