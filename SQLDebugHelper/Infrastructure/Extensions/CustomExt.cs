using SQLDebugHelper.Models;
using System.Collections.Generic;
using System.Linq;

namespace SQLDebugHelper.Infrastructure.Extensions
{
    public static class CustomExt
    {
        public static string FindFieldOfType( this List<SQLObjectColumnModel> colList, string sqlTypeName )
        {
            var col = colList.FirstOrDefault( c => c.Type == sqlTypeName );

            return (col == null ? null : col.Name);
        }
    }
}
