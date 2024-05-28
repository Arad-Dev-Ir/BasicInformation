namespace BasicInformation.Data.Sql.Queries;

using Microsoft.EntityFrameworkCore;
using Swan.Web.Data.Sql.Query;
using Keyword = Keyword.Queries.Keyword;

public class BasicInformationQueryContext : QueryContext
{
    public DbSet<Keyword> Keywords { get; set; }

    public BasicInformationQueryContext(DbContextOptions<BasicInformationQueryContext> options) : base(options)
    { }
}