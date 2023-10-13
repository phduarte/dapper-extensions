using AutoFixture;
using NUnit.Framework;
using static Gadz.Dapper.Extensions.Tests.Dtos;

namespace Gadz.Dapper.Extensions.Tests
{
    public class SqlBuilderFactoryTests
    {
        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public void InsertSqlBuilder_WhenUsingSimpleMapping_ShouldGenerateSqlCorrectly()
        {
            var defaultDto = fixture.Create<TableLayout>();
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(defaultDto.GetType());
            var expected = "INSERT INTO [TableLayout]([EntityId],[TextField],[IntField],[DecimalField],[DateTimeField]) VALUES(@EntityId,@TextField,@IntField,@DecimalField,@DateTimeField);";

            Assert.That(sql, Is.EqualTo(expected));
        }

        [Test]
        public void InsertSqlBuilder_WhenUsingTableWithoutSchema_ShouldRecognizeAttributeName()
        {
            var dto = fixture.Create<TableWithOriginalNameAndWithoutSchema>();
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(dto.GetType());
            var expected = "INSERT INTO [TableWithOriginalNameAndWithoutSchema]([insert_dt],[insert_sequence]) VALUES((GETDATE()),(SELECT ISNULL(MAX(insert_sequence)+1,1) from #temp));";

            Assert.That(sql, Is.EqualTo(expected));
        }

        [Test]
        public void InsertSqlBuilder_WhenUsingTableWithSchema_ShouldRecognizeAttributeName()
        {
            var dto = new TableWithDifferentNameAndSchemaName
            {
                Date = DateTime.Parse("2023-10-01 10:00"),
                Sequence = 1
            };
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(dto.GetType());
            var expected = "INSERT INTO [dbo].[#temp]([insert_dt],[insert_sequence]) VALUES(@insert_dt,@insert_sequence);";

            Assert.That(sql, Is.EqualTo(expected));
        }

        [Test]
        public void InsertSqlBuilder_WhenIgnoredProperties_ShouldIgnoreInSqlStatement()
        {
            var dto = new TableWithIgnoreAttribute
            {
                Date = DateTime.Parse("2023-10-01 10:00"),
                Sequence = 1
            };
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(dto.GetType());
            var expected = "INSERT INTO [TableWithIgnoreAttribute]([insert_dt]) VALUES(@insert_dt);";

            Assert.That(sql, Is.EqualTo(expected));
        }
    }
}