using System;

namespace Gadz.Dapper.Extensions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Name { get; }
        public string Schema { get; }

        public TableAttribute(string name = null, string schema = null)
        {
            Name = name;
            Schema = schema;
        }
    }
}
