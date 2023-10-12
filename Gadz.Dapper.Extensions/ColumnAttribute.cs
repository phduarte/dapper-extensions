using System;

namespace Gadz.Dapper.Extensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string name, string expression = null)
        {
            Name = name;
            Expression = expression;
        }

        public string Name { get; }
        public string Expression { get; }
    }
}
