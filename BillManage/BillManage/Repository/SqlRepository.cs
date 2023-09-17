using Dapper;
using System.Data;

namespace BillManage
{
    public class SqlRepository<T> : IRepository<T>
    {
        private IDbConnection Connection { get; set; }
        public SqlRepository(IDbConnection connection)
        {
            Connection = connection;
        }

        public IEnumerable<T> ReadData()
        {
            var result = Connection.Query<T>($"SELECT * FROM {typeof(T).Name}");
            return result;
        }
    }
}
