using System.Collections.Generic;

namespace Gadz.Dapper.Extensions
{
    /// <summary>
    /// Creates a specific sql builder according to the command type.
    /// </summary>
    public static class SqlBuilderFactory
    {
        private static Dictionary<CommandType, SqlBuilder> _dic = new Dictionary<CommandType, SqlBuilder>()
        {
            { CommandType.Insert, new InsertSqlBuilder() }
        };

        /// <summary>
        /// Get an instance of a sql builder to generate a sql statement for the specific command type.
        /// </summary>
        /// <param name="commandType">type of command to be generated.</param>
        /// <returns>Sql Builder</returns>
        public static ISqlBuilder For(CommandType commandType)
        {
            return _dic[commandType];
        }
    }
}
