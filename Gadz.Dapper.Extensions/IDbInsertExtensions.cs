using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gadz.Dapper.Extensions
{
    public static class IDbInsertExtensions
    {
        private static IDictionary<Type, string> _cache = new Dictionary<Type, string>();

        public static Task<int> InsertAsync<T>(this IDbConnection connection, T dto)
        {
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(typeof(T));

            return connection.ExecuteAsync(sql, dto);
        }
    }
}
