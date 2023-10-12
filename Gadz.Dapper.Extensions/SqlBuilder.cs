using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gadz.Dapper.Extensions
{
    internal abstract class SqlBuilder : ISqlBuilder
    {
        private static IDictionary<Type, string> _cache = new Dictionary<Type, string>();

        public virtual string Build(Type type)
        {
            if (_cache.TryGetValue(type, out string sql))
            {
                return sql;
            }

            var newSql = Generate(type);
            _cache.Add(type, newSql);

            return newSql;
        }

        protected abstract string Generate(Type type);

        protected static (string TableName, IEnumerable<string> Columns, IEnumerable<string> Values) Map(Type type)
        {
            var columns = new List<string>();
            var values = new List<string>();
            var tableName = GetTableName(type);

            foreach (var p in type.GetProperties())
            {
                var attr = p.GetCustomAttribute<ColumnAttribute>();

                if (attr?.Ignore ?? false) continue;

                var name = $"[{attr?.Name ?? p.Name}]";
                var exp = attr?.Expression;
                var value = !string.IsNullOrEmpty(exp) ? $"({exp})" : $"@{name}";

                columns.Add(name);
                values.Add(value);
            }

            return (tableName, columns, values);
        }

        protected static string GetTableName(Type type)
        {
            var tableAttr = type.GetCustomAttributes(true)?.OfType<TableAttribute>()?.FirstOrDefault();
            var tableName = $"[{tableAttr?.Name ?? type.Name}]";
            var dbSchema = tableAttr?.Schema ?? string.Empty;

            return string.IsNullOrEmpty(dbSchema) ? tableName : $"[{dbSchema}].{tableName}";
        }
    }
}
