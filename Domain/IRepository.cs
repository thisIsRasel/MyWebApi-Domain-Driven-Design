namespace Domain
{
    public interface IRepository<T>
        where T : class
    {
        void Insert(T obj);

        void Update();

        void Delete();
    }
}
