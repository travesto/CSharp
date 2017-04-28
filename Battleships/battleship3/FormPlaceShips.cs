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
    public partial class FormPlaceShips : Form
    {
		string currentShip;

        public FormPlaceShips()
        {
            InitializeComponent();
        }

        private void FormPlaceShips_Load(object sender, EventArgs e)
        {

        }

		//menu and ready buttons
        private void ready_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPlayOnline form = new FormPlayOnline();
            form.ShowDialog();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSplash form = new FormSplash();
            form.ShowDialog();
		}

		//ship placement buttons
		private void random_Click(object sender, EventArgs e)
		{
			this.Hide();
			FormPlaceShips form = new FormPlaceShips();
			form.ShowDialog();
		}

		private void reset_Click(object sender, EventArgs e)
        {
			this.Hide();
			FormPlaceShips form = new FormPlaceShips();
			form.ShowDialog();
        }

		/*private void place_Click(object sender, EventArgs e)
		{
			this.Hide();
			FormPlaceShips form = new FormPlaceShips();
			form.ShowDialog();
		}*/

		//ship buttons
		private void carrier_Click(object sender, EventArgs e)
		{
			currentShip = "carrier";
			this.button3.BackColor = Color.Green;
		}

		private void battleship_Click(object sender, EventArgs e)
		{
			currentShip = "battleship";
			this.button1.BackColor = Color.Green;
		}

		private void destroyer_Click(object sender, EventArgs e)
		{
			currentShip = "destroyer";
			this.button6.BackColor = Color.Green;
		}

		private void cruiser_Click(object sender, EventArgs e)
		{
			currentShip = "cruiser";
			this.button30.BackColor = Color.Green;
		}

		private void sub1_Click(object sender, EventArgs e)
		{
			currentShip = "submarine";
			this.button29.BackColor = Color.Green;
		}

		private void sub2_Click(object sender, EventArgs e)
		{
			currentShip = "submarine";
			this.button2.BackColor = Color.Green;
		}
        private void sub2_unClick(object sender, EventArgs e)
        {
            currentShip = "submarine";
            this.button2.BackColor = Color.Gray;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
