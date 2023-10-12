namespace Gadz.Dapper.Extensions.Tests;

public class Dtos
{
    public class TableLayout
    {
        public Guid EntityId { get; set; }
        public string TextField { get; set; }
        public int IntField { get; set; }
        public decimal DecimalField { get; set; }
        public DateTime DateTimeField { get; set; }
    }

    [Table("TABLE_LAYOUT_WITH_EXPRESSION_FIELD")]
    public class TableLayoutWithExpressionField
    {
        [Column("UUID")]
        public Guid Id { get; set; }
        [Column("SEQUENCE", "SELECT ISNULL(MAX(SEQUENCE) + 1,1) FROM [TABLE_LAYOUT_WITH_EXPRESSION_FIELD] WHERE UUID = @UUID")]
        public int Sequence { get; set; }
        [Column("STATUS")]
        public int Status { get; set; }
        [Column("CREATION_DT", "GETDATE()")]
        public DateTime CreationDate { get; set; }
        [Column("CREATOR_NAME")]
        public string Creator { get; set; }
    }

    public class TableWithOriginalNameAndWithoutSchema
    {
        [Column("insert_dt", "GETDATE()")]
        public DateTime Date { get; set; }
        [Column("insert_sequence", "SELECT ISNULL(MAX(insert_sequence)+1,1) from #temp")]
        public int Sequence { get; set; }
    }

    [Table("#temp", "dbo")]
    public class TableWithDifferentNameAndSchemaName
    {
        [Column("insert_dt")]
        public DateTime Date { get; set; }
        [Column("insert_sequence")]
        public int Sequence { get; set; }
    }

    [Table("#temp")]
    public class TableWithDifferentName
    {
        [Column("insert_dt")]
        public DateTime Date { get; set; }
        [Column("insert_sequence")]
        public int Sequence { get; set; }
    }
}