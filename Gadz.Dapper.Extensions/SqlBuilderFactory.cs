using System.Collections.Generic;

namespace Gadz.Dapper.Extensions
{
    public static class SqlBuilderFactory
    {
        private static Dictionary<CommandType, SqlBuilder> _dic = new Dictionary<CommandType, SqlBuilder>()
        {
            { CommandType.Insert,new InsertSqlBuilder() }
        };

        public static SqlBuilder For(CommandType commandType)
        {
            return _dic[commandType];
        }
    }
}
