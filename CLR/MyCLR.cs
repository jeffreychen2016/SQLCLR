using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void MyCLR ()
    {
        SqlContext.Pipe.Send("This is a text from the sample SQLCLR");
    }
}
