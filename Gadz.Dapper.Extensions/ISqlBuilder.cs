using System;

namespace Gadz.Dapper.Extensions
{
    /// <summary>
    /// A Sql Statements builder
    /// </summary>
    public interface ISqlBuilder
    {
        /// <summary>
        /// Creates a SQL statement based on the type.
        /// </summary>
        /// <param name="type">Database Object Representation</param>
        /// <returns>SQL Statement</returns>
        string Build(Type type);
    }
}
