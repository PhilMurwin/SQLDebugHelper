using System.Linq;
using System.Windows.Forms;

namespace SQLDebugHelper.Infrastructure.Extensions
{
    public static class ControlExt
    {
        public static Control GetNamedChildControl( this Control ctrl, string ctrlName )
        {
            if ( ctrl.HasChildren )
            {
                foreach ( var child in ctrl.Controls.OfType<Control>() )
                {
                    if ( child.Name.ToLower() == ctrlName.ToLower() )
                    {
                        return child;
                    }
                    else if ( child.HasChildren )
                    {
                        return child.GetNamedChildControl( ctrlName );
                    }
                }
            }

            return null;
        }

        public static void RemoveAllChildControls( this Control ctrl )
        {
            ctrl.Controls.Clear();
        }
    }
}
