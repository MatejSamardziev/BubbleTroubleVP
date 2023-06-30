using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class ChoseCharacterMenu : Form
    {
        int CharSelector = 0;
        public ChoseCharacterMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(0);
            GameForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(1);
            GameForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(2);
            GameForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(3);
            GameForm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(4);
            GameForm.Show();
            this.Hide();
        }

        private void ChoseCharacterMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(5);
            GameForm.Show();
            this.Hide();
        }
        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            Form1 GameForm = new Form1(6);
            GameForm.Show();
            this.Hide();
        }
    }
}
