using System;
using System.Collections.Generic;
using System.Text;

namespace Mip.Farm.Infrastructure.Postgres;

public interface IPagedQueryPostgres
{
    int Page { get; }
    int Results { get; }
}
