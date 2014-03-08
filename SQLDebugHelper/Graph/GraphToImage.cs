using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

/// <summary>
/// Class handles operations for printing the graph to image.
/// </summary>
class GraphToImage
{
	//Set resolution of image.
	const double dpi = 96d;

	//Set pixelformat of image.
	PixelFormat pixelFormat = PixelFormats.Pbgra32;

	/// <summary>
	/// Method exports the graphlayout to an png image.
	/// </summary>
	/// <param name="path">destination of image</param>
	/// <param name="surface">graphlayout you want to print</param>
	public void ExportToPng(Windows.Controls.MyGraphLayout surface, Uri path)
	{
		//Save current canvas transform
		Transform transform = surface.LayoutTransform;

		//Reset current transform (in case it is scaled or rotated)
		surface.LayoutTransform = null;

		//Get the size of canvas
		Size size = new Size(surface.ActualWidth, surface.ActualHeight);

		//Measure and arrange the surface
		//VERY IMPORTANT
		surface.Measure(size);
		surface.Arrange(new Rect(size));

		//Create a render bitmap and push the surface to it
		RenderTargetBitmap renderBitmap =
		  new RenderTargetBitmap(
			(int)size.Width,
			(int)size.Height,
			dpi,
			dpi,
			pixelFormat);

		//Render the graphlayout onto the bitmap.
		renderBitmap.Render(surface);

		//Create a file stream for saving image
		using (FileStream outStream = new FileStream(path.LocalPath, FileMode.Create))
		{
			//Use png encoder for our data
			PngBitmapEncoder encoder = new PngBitmapEncoder();

			//Push the rendered bitmap to it
			encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

			//Save the data to the stream
			encoder.Save(outStream);
		}

		//Restore previously saved layout
		surface.LayoutTransform = transform;
	}
}