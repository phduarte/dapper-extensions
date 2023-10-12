using System;

namespace Gadz.Dapper.Extensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string name = null, string expression = null, bool ignore = false)
        {
            Name = name;
            Expression = expression;
            Ignore = ignore;
        }

        public string Name { get; }
        public string Expression { get; }
        public bool Ignore { get; }
    }
}
