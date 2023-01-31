using System.Data;

namespace Student.DataInterface
{
    public interface IDataBaseFactory: IDisposable
    {
        IDbConnection Get();
    }
}