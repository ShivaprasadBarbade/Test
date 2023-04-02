using Dapper;
using DapperExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace CorporateClassifieds.Repository.Dapper
{
    public class Database : IDatabase
    {
        private string _connectionString;
        private IDbConnection _db;

        public Database(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new SqlConnection(_connectionString);
                }

                return _db;
            }
        }

        public IEnumerable<T> Fetch<T>(string sql, object param = null, CommandType? commandType = null)
        {
            return this.DB.Query<T>(sql, param, commandType: commandType) ;
        }

        public T FirstOrDefault<T>(string sql, object param = null, CommandType? commandType = null)
        {
            return this.DB.QueryFirstOrDefault<T>(sql,param, commandType: commandType);
        }

        public T SingleOrDefault<T>(string sql, object param = null, CommandType? commandType = null)
        {
            return this.DB.QuerySingleOrDefault<T>(sql,param, commandType: commandType);
        }

        public void Insert<T>(IEnumerable<T> entities) where T : class
        {
            this.DB.Insert(entities);
        }

        public dynamic Insert<T>(T entity)  where T : class
        {
            return this.DB.Insert(entity);
        }

        public bool Update<T>(T entity) where T : class
        {
             return this.DB.Update(entity);
        }

        public void Update<T>(IEnumerable<T> entities) where T : class
        {
             this.DB.Update(entities);
        }
        public void UpdatePartial<TIn, TOut>(IEnumerable<TIn> entitites, Expression<Func<TIn, TOut>> func) where TIn : class where TOut : class
        {
            this.DB.UpdatePartial(entitites, func);
        }

        public bool UpdatePartial<TIn, TOut>(TIn entity, Expression<Func<TIn, TOut>> func) where TIn : class where TOut : class
        {
            return this.DB.UpdatePartial(entity, func);
        }


        public bool Delete<T>(T sql) where T : class
        {
            return this.DB.Delete(sql);
        }
        public int  Execute<T>(string sql)
        {
            return this.DB.Execute(sql);
        }
    }
}
