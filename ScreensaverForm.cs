using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimpleClockScreensaver
{
	public partial class ScreensaverForm : Form
	{
		Timer drawTimer = new Timer();
		int drawFPS = 60;

		Point mousePositionOnOpen;
		bool isMousePositionOnOpenCaptured = false;

		PrivateFontCollection privateFontCollection = new PrivateFontCollection();
		Font ubuntuRegular220;

		public ScreensaverForm()
		{
			InitializeComponent();

			// Use double buffering to improve drawing performance
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
			ShowInTaskbar = false;
			DoubleBuffered = true;

			// Capture the mouse
			Capture = true;

			// Hide the mouse
			Cursor.Hide();

			// Set fullscreen
			Bounds = Screen.PrimaryScreen.Bounds;
			TopMost = true;
			WindowState = FormWindowState.Normal;
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;

			drawTimer.Tick += new EventHandler((object sender, EventArgs e) => this.Invalidate());
			drawTimer.Interval = (int)Math.Ceiling(1000.0 / drawFPS);
			drawTimer.Start();

			// Load fonts
			ubuntuRegular220 = LoadFont(Properties.Resources.Ubuntu_Regular, 220);
		}

		Font LoadFont(byte[] fontData, int fontSize)
		{
			IntPtr ubuntuFontDataPtr = Marshal.AllocCoTaskMem(fontData.Length);
			Marshal.Copy(fontData, 0, ubuntuFontDataPtr, fontData.Length);
			privateFontCollection.AddMemoryFont(ubuntuFontDataPtr, fontData.Length);
			return new Font(privateFontCollection.Families[0], fontSize);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

			DateTime time = DateTime.Now;
			string timeString = time.ToString("hh mm");
			DrawingUtils.DrawCenterString(e, timeString, ubuntuRegular220, Convert.ToSingle(Size.Width / 2.0), Convert.ToSingle(Size.Height / 2.0));
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Image bgImage = (Image)Properties.Resources.ResourceManager.GetObject("fern");

			double bgWidthToHeightRatio = (double)bgImage.Width / (double)bgImage.Height;
			int bgWidth = Size.Width;
			int bgHeight = Convert.ToInt32(Math.Ceiling(bgWidth / bgWidthToHeightRatio));
			if (bgHeight < Size.Height)
			{
				bgHeight = Size.Height;
				bgWidth = Convert.ToInt32(Math.Ceiling(bgHeight * bgWidthToHeightRatio));
			}
			DrawingUtils.DrawCenterImage(e, bgImage, (int)Math.Round(Size.Width / 2.0), (int)Math.Round(Size.Height / 2.0), bgWidth, bgHeight);
		}

		private void OnScreensaverFormLoad(object sender, EventArgs e)
		{
			
		}

		void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (isMousePositionOnOpenCaptured)
			{
				if ((Math.Abs(MousePosition.X - mousePositionOnOpen.X) > 10) || (Math.Abs(MousePosition.Y - mousePositionOnOpen.Y) > 10))
				{
					//Close();
				}
			}
			else
			{
				mousePositionOnOpen = MousePosition;
				isMousePositionOnOpenCaptured = true;
			}
		}

		void OnMouseDown(object sender, MouseEventArgs e)
		{
			//Close();
		}

		void OnKeyDown(object sender, KeyEventArgs e)
		{
			//Close();
		}
	}
}
