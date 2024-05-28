﻿namespace BasicInformation.Data.Sql.NewsService.Commands;

using Swan.Web.Data.Sql.Command;
using Name = Core.NewsService.Models.Name;

public class NameConversion : Conversion<Name, string>
{
    public NameConversion() : base(e => e.Value, e => Name.Instance(e))
    { }
}