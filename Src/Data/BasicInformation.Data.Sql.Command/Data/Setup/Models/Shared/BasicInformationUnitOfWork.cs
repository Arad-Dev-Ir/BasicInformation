namespace BasicInformation.Data.Sql.Commands;

using Swan.Web.Data.Sql.Command;

public class BasicInformationUnitOfWork : UnitOfWork<BasicInformationCommandContext>
{
    public BasicInformationUnitOfWork(BasicInformationCommandContext context) : base(context)
    { }
}