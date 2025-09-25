using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClickedPictureBox(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPictureBox)
        {
            var distanse = Math.Abs(clickedPictureBox.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Width;
            if (distanse > 2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                (clickedPictureBox.Location, emptyPictureBox.Location) = (emptyPictureBox.Location, clickedPictureBox.Location);
            }
        }
    }
}
