using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace SQLDebugHelper.Forms
{
	public partial class ProcMap : Form
	{
		#region Variables
		private ElementHost ctrlHost;
		private Windows.Controls.GraphPanel wpfControl;
		private string m_GraphML;
		private string m_MapTitle = string.Empty;
		#endregion Variables

		public ProcMap(string graphstring, string mapTitle)
		{
			m_MapTitle = mapTitle;
			m_GraphML = graphstring;

			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			try
			{
				wpfControl = new Windows.Controls.GraphPanel();
				wpfControl.InitializeComponent();

				ctrlHost = new ElementHost();
				ctrlHost.Dock = DockStyle.Fill;
				this.Controls.Add(ctrlHost);
				ctrlHost.Child = wpfControl;

				Cursor = Cursors.WaitCursor;
				wpfControl.LoadData(m_GraphML);
				Cursor = Cursors.Default;


			}
			catch (Exception err)
			{
				MessageBox.Show("Exception: " + err.Message, "ProcMap - OnLoad");
			}
			finally
			{
				base.OnLoad(e);
			}
		}

		private void SaveImage()
		{
			string saveFilePath = string.Empty;

			using (SaveFileDialog savePath = new SaveFileDialog())
			{
				savePath.Filter = "Png Image (.png)|*.png";

				if (!string.IsNullOrEmpty(m_MapTitle))
				{
					savePath.FileName = m_MapTitle;
				}

				if (savePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					saveFilePath = savePath.FileName;
				}
			}

			if (!string.IsNullOrEmpty(saveFilePath))
			{
				GraphToImage g2i = new GraphToImage();
				g2i.ExportToPng(wpfControl.layout, new Uri(saveFilePath));
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSaveImage_Click(object sender, EventArgs e)
		{
			SaveImage();
		}
	}
}
