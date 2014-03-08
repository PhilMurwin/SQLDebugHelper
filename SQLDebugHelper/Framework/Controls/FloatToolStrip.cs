using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Framework.Controls
{
	public class FloatToolStrip : ToolStrip
	{
		public event EventHandler Undocked;

		[BrowsableAttribute(false)]
		private FloatForm ToolFloatForm
		{
			get; 
			set;
		}

		protected override void OnMouseDown(MouseEventArgs mea)
		{
			base.OnMouseDown(mea);
			return;

			if (this.GripRectangle.Contains(mea.Location) && this.Parent.ToString() == typeof(ToolStripPanel).ToString())
			{
				Point Location = PointToScreen(Point.Empty);

				//For more control, this would be a custom form.
				//You could then have event handlers that would react
				//when it is dragged to an edge, and redock it
				//automatically.
				ToolFloatForm = new FloatForm();
				ToolFloatForm.StartPosition = FormStartPosition.Manual;
				ToolFloatForm.Owner = this.FindForm();
				ToolFloatForm.AllowDrop = true;
				ToolFloatForm.DragEnter += new DragEventHandler(ToolFloatForm_Drag);

				Point pt = Location;
				pt.Offset(5, 5);

				ToolFloatForm.Location = pt;
				ToolFloatForm.Text = this.Text;
				ToolFloatForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				ToolFloatForm.ClientSize = this.Size;

				//A control can be contained in only one form.
				//This moves the ToolStrip out of the original form and into
				//the floating form.
				ToolFloatForm.Controls.Add(this);
				ToolFloatForm.Show();

				//Raise the event to notify the form.
				if (Undocked != null)
				{
					Undocked(this, EventArgs.Empty);
				}
			}
			else
			{
				//Perform the normal mouse-click handling.
				base.OnMouseDown(mea);
			}
		}

		public void ToolFloatForm_Drag(Object obj, DragEventArgs args)
		{
			Object obj2 = args.Data;
		}
	}
}
