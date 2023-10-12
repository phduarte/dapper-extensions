using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gadz.Dapper.Extensions
{
    /// <summary>
    /// Extends the IDbConnection to add InsertAsync method.
    /// </summary>
    public static class IDbInsertExtensions
    {
        private static IDictionary<Type, string> _cache = new Dictionary<Type, string>();

        /// <summary>
        /// Execute an INSERT command asynchronously using task
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Task<int> InsertAsync<T>(this IDbConnection connection, T dto)
        {
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(typeof(T));

            return connection.ExecuteAsync(sql, dto);
        }
    }
}
