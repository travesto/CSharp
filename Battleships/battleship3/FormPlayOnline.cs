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
    public partial class FormPlayOnline : Form
    {
        public FormPlayOnline()
        {
            InitializeComponent();
        }

        private void FormPlayOnline_Load(object sender, EventArgs e)
        {
            local_nickname.Text = FormSplash.nickname;
        }

        private void local_nickname_TextChanged(object sender, EventArgs e)
        {

        }

        private void menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSplash splash = new FormSplash(); //update to offline when form is created
            splash.ShowDialog();
        }
    }
}
