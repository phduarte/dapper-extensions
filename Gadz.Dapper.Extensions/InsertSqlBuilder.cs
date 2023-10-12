using System;

namespace Gadz.Dapper.Extensions
{
    internal class InsertSqlBuilder : SqlBuilder
    {
        protected override string Generate(Type type)
        {
            var (tableName, columns, values) = Map(type);

            return "INSERT INTO <TABLE>(<COLUMNS>) VALUES(<VALUES>);"
                    .Replace("<TABLE>", tableName)
                    .Replace("<COLUMNS>", string.Join(",", columns))
                    .Replace("<VALUES>", string.Join(",", values));
        }
    }
}
