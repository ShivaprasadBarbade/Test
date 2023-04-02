using System.Data;
using System.Linq.Expressions;

namespace CorporateClassifieds.Repository.Dapper
{
    public interface IDatabase
    {
        IEnumerable<T> Fetch<T>(string sql, object param = null, CommandType? commandType = null);

        T FirstOrDefault<T>(string sql, object param = null, CommandType? commandType = null);

        T SingleOrDefault<T>(string sql, object param = null, CommandType? commandType = null);

        void Insert<T>(IEnumerable<T> entities) where T : class;

        dynamic Insert<T>(T sql) where T : class;

        bool Update<T>(T sql) where T : class;

        void Update<T>(IEnumerable<T> entities) where T : class;

        void UpdatePartial<TIn, TOut>(IEnumerable<TIn> entities, Expression<Func<TIn, TOut>> func) where TIn : class where TOut : class;

        bool UpdatePartial<TIn, TOut>(TIn entity, Expression<Func<TIn, TOut>> func) where TIn : class where TOut : class;

        bool Delete<T>(T sql) where T : class;
        int Execute<T>(string sql);

    }
}
