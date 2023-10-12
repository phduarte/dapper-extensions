using System;

namespace Gadz.Dapper.Extensions
{
    /// <summary>
    /// Used to customize the table info to match the database definition.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// Corresponding name of the table in the database.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Schema where the database base is placed, if necessary.
        /// </summary>
        public string Schema { get; }

        /// <summary>
        /// Customize the table info to match the database definition.
        /// </summary>
        /// <param name="name">Corresponding name of the table in the database.</param>
        /// <param name="schema">Schema where the database base is placed, if necessary.</param>
        public TableAttribute(string name = null, string schema = null)
        {
            Name = name;
            Schema = schema;
        }
    }
}
