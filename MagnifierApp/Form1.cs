using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagnifierApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new magnifier box
            PictureBox magnifierBox = new PictureBox
            {
                Width = 100,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, 10)  // Set the initial position of the magnifier box
            };

            // Capture and display the magnified content within the box
            Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics graphics = Graphics.FromImage(screenshot as Image))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
            }

            Rectangle magnifierRect = new Rectangle(magnifierBox.Location, magnifierBox.Size);
            Bitmap magnifiedContent = screenshot.Clone(magnifierRect, screenshot.PixelFormat);
            magnifierBox.Image = magnifiedContent;

            // Add the magnifier box to the form
            Controls.Add(magnifierBox);

            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
