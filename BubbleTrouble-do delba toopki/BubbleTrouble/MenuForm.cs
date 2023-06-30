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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(0);
            gameForm.Show();

            this.Hide();
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            ChoseCharacterMenu CharMenu = new ChoseCharacterMenu();
            CharMenu.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The goal of the game is to shoot down all of the balls using your harpoon! Use the left and right arrow keys to move and right mouse click to shoot. But be careful to not get hit by the balls!");
        }
    }
}
