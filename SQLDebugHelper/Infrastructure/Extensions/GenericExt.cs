using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQLDebugHelper.Infrastructure.Extensions
{
    public static class GenericExt
    {
        public static DataTable ToDataTable( this IEnumerable<dynamic> items)
        {
            var t = new DataTable();

            if ( items.Count() > 0 )
            {
                var first = (IDictionary<string, object>)items.First();

                foreach ( var k in first.Keys )
                {
                    var c = t.Columns.Add( k );
                    var val = first[k];

                    if ( val != null )
                    {
                        var dataType = val.GetType();

                        if ( dataType == typeof( Byte[] ) )
                        {
                            dataType = typeof( String );
                        }

                        c.DataType = dataType;
                    }
                }

                foreach ( var item in items )
                {
                    var r = t.NewRow();
                    var i = (IDictionary<string, object>)item;
                    foreach ( var k in i.Keys )
                    {
                        var val = i[k];
                        if ( val == null ) val = DBNull.Value;

                        if ( val.GetType() == typeof( Byte[] ) )
                        {
                            r[k] = val.GetType();
                        }
                        else
                        {
                            r[k] = val;
                        }
                    }
                    t.Rows.Add( r );
                }
            }
            return t;
        }
    }
}
