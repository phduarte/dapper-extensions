using System;

namespace Gadz.Dapper.Extensions
{
    /// <summary>
    /// Used to customize the column info to match the database definition.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        /// <summary>
        /// Customize the column info to match the database definition.
        /// </summary>
        /// <param name="name">The column name in database.</param>
        /// <param name="expression">Explicit expression to be considered instead of the value.</param>
        /// <param name="ignore">Allow you ignore a column from the mapping.</param>
        public ColumnAttribute(string name = null, string expression = null, bool ignore = false, int order = 0)
        {
            Name = name;
            Expression = expression;
            Ignore = ignore;
            Order = order;
        }

        /// <summary>
        /// The column name in database.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Explicit expression to be considered instead of the value.
        /// <code>e.g. GETDATE(), NEWID(), SELECT TOP 1 column1 FROM table;</code>
        /// </summary>
        public string Expression { get; }
        /// <summary>
        /// Allow you ignore a column from the mapping.
        /// </summary>
        public bool Ignore { get; }

        public int Order { get; }
    }
}
