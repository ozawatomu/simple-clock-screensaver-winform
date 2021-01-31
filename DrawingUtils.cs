using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClockScreensaver
{
	class DrawingUtils
	{
		public static void DrawCenterImage(PaintEventArgs e, Image image, int centerX, int centerY, int width, int height)
		{
			int topLeftX = Convert.ToInt32(Math.Round(centerX - width / 2.0));
			int topLeftY = Convert.ToInt32(Math.Round(centerY - height / 2.0));
			e.Graphics.DrawImage(image, topLeftX, topLeftY, width, height);
		}

		public static void DrawCenterString(PaintEventArgs e, string text, Font font, float x, float y)
		{
			SizeF size = e.Graphics.MeasureString(text, font);
			float topLeftX = x - (size.Width / 2);
			float topLeftY = y - (size.Height / 2);
			e.Graphics.DrawString(text, font, new SolidBrush(Color.White), topLeftX, topLeftY);
		}
	}
}
