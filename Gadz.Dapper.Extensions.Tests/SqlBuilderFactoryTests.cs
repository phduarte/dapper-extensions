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

            Assert.That(sql, Is.EqualTo("INSERT INTO [PAYMENT]([PAYMENT_UUID],[DIGITIZABLE_LINE],[PAYMENT_DT],[CREATED_AT_DT],[CREATED_BY_DS]) VALUES(@PAYMENT_UUID,@DIGITIZABLE_LINE,@PAYMENT_DT,@CREATED_AT_DT,@CREATED_BY_DS);"));
        }

        [Test]
        public void InsertSqlBuilder_WhenUsedTableWithoutSchema_ShouldRecognizeAttributeName()
        {
            var dto = fixture.Create<TableWithOriginalNameAndWithoutSchema>();
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(dto.GetType());

            Assert.That(sql, Is.EqualTo("INSERT [TableWithOriginalNameAndWithoutSchema]([insert_dt],[insert_sequence]) VALUES((GETDATE()),(SELECT ISNULL(MAX(insert_sequence)+1,1) from #temp));"));
        }

        [Test]
        public void InsertSqlBuilder_WhenUsedTableWithSchema_ShouldRecognizeAttributeName()
        {
            var dto = new TableWithDifferentNameAndSchemaName
            {
                Date = DateTime.Parse("2023-10-01 10:00"),
                Sequence = 1
            };
            var sql = SqlBuilderFactory.For(CommandType.Insert).Build(dto.GetType());

            Assert.That(sql, Is.EqualTo("INSERT [dbo].[#temp]([insert_dt],[insert_sequence]) VALUES(@insert_dt,@insert_sequence);"));
        }
    }
}