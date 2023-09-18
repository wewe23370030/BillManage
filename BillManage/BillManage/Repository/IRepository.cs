namespace BillManage
{
    public interface IRepository<T>
    {
        IEnumerable<T> ReadData(long id);
    }
}
