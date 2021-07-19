using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public static partial class CustomExtensions
    {
        public static long GetNextSequenceValue(this DbContext context, string name, string schema = null)
        {
            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.BigInt)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            context.Database.ExecuteSqlRaw($"SELECT @result = (NEXT VALUE FOR [{name}])", result);

            return (long)result.Value;
        }
    }
}