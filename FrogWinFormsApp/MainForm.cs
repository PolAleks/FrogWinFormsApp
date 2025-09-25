using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class MainForm : Form
    {
        private int score = 0;
        private List<PictureBox> pictureBoxes;
        public MainForm()
        {
            InitializeComponent();
            pictureBoxes = Controls.OfType<PictureBox>().ToList();
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

                labelScore.Text = (++score).ToString();
            }

            if (IsWinner())
            {
                CongratulationOnVictory();
            }
        }

        private void CongratulationOnVictory()
        {
            string message = score > 24 ? $"Ваш результат - {score} прыжка. Можно лучше.\n" : $"{score} - лучший результат.\n";
            var result = MessageBox.Show($"{message}Хотите сыграть еще раз?", "Вы выиграли!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
                Application.Restart();
            else
                Application.Exit();
        }

        private bool IsWinner()
        {
            return pictureBoxes.Where(p => p.AccessibleName == "Right").All(p => p.Location.X < 440) && emptyPictureBox.Location.X == 440;
        }

        private void начатьСначалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
