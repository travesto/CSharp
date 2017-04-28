using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship3
{
    public partial class FormSplash : Form
    {
        public static string nickname;
        public FormSplash()
        {
            InitializeComponent();
            text_nickname.Text = nickname;
        }

        private void text_nickname_TextChanged(object sender, EventArgs e)
        {
            nickname = text_nickname.Text;
        }

        // PLAY ONLINE
        private void button2_Click(object sender, EventArgs e)
        {
            if(text_nickname.Text != "")
            {
                this.Hide();
                FormPlaceShips form = new FormPlaceShips();
                form.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_nickname.Text != "")
            {
                this.Hide();
                FormPlaceShips form = new FormPlaceShips();
                form.ShowDialog();
            }
        }

        
    }
}
