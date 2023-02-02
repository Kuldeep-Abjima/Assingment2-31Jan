using Microsoft.Extensions.Logging;
using Student.DataInterface;
using System.Data;

namespace Student.Data
{
    public abstract class BaseRepository<T> where T : class
    {
        private IDbConnection _DbContext;
        private readonly ILogger _logger;
        public BaseRepository(ILogger logger, IDataBaseFactory dataBaseFactory)
        {
            _logger = logger;
            DataBaseFactory = dataBaseFactory;
        }

        protected IDataBaseFactory DataBaseFactory
        {
            get;
            private set;
        }
        protected IDbConnection Datacontext { 
            get
            {
                return _DbContext ??= DataBaseFactory.Get();
            } 
        
        }
    }
}
