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
	public struct ship
	{
		public string name;
		public int length;
		public string[] cells;
		public ship(string a, int b, string[] c)
		{
			name = a;
			length = b;
			cells = c;
		}
	}

	public partial class FormPlaceShips : Form
	{
		//ship logic
		public string currentShip;
		public ship[] storage;
		public string[] placed;
		public int numPlaced;
		public string orientation;
		public int storageCount;

		//functions
		public FormPlaceShips()
		{
			InitializeComponent();
			placed = new string[6];
			numPlaced = 0;
			orientation = "right";
			currentShip = "";
			storage = new ship[6];
			storageCount = 0;
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
			if (placed == null | !placed.Contains("carrier"))
			{
				if (currentShip != "")
				{
					var old = this.Controls.Find(currentShip, true);
					if (old != null)
						old[0].BackColor = Color.White;
				}
				currentShip = "carrier";
				this.carrier.BackColor = Color.Green;
			}
		}
		private void battleship_Click(object sender, EventArgs e)
		{
			if (placed == null | !placed.Contains("battleship"))
			{
				if (currentShip != "")
				{
					var old = this.Controls.Find(currentShip, true);
					if (old != null)
						old[0].BackColor = Color.White;
				}
				currentShip = "battleship";
				this.battleship.BackColor = Color.Green;
			}
		}
		private void destroyer_Click(object sender, EventArgs e)
		{
			if (placed == null | !placed.Contains("destroyer"))
			{
				if (currentShip != "")
				{
					var old = this.Controls.Find(currentShip, true);
					if (old != null)
						old[0].BackColor = Color.White;
				}
				currentShip = "destroyer";
				this.destroyer.BackColor = Color.Green;
			}
		}
		private void cruiser_Click(object sender, EventArgs e)
		{
			if (placed == null | !placed.Contains("cruiser"))
			{
				if (currentShip != "")
				{
					var old = this.Controls.Find(currentShip, true);
					if (old != null)
						old[0].BackColor = Color.White;
				}
				currentShip = "cruiser";
				this.cruiser.BackColor = Color.Green;
			}
		}
		private void sub1_Click(object sender, EventArgs e)
		{
			if (placed == null | !placed.Contains("submarine1"))
			{
				if (currentShip != "")
				{
					var old = this.Controls.Find(currentShip, true);
					if (old != null)
						old[0].BackColor = Color.White;
				}
				currentShip = "submarine1";
				this.submarine1.BackColor = Color.Green;
			}
		}
		private void sub2_Click(object sender, EventArgs e)
		{
			if (placed == null | !placed.Contains("submarine2"))
			{
				if (currentShip != "")
				{
					var old = this.Controls.Find(currentShip, true);
					if (old != null)
						old[0].BackColor = Color.White;
				}
				currentShip = "submarine2";
				this.submarine2.BackColor = Color.Green;
			}
		}

		//orientation buttons
		private void up_Click(object sender, EventArgs e)
		{
			var old = this.Controls.Find(orientation, true);
			old[0].BackColor = Color.Snow;
			orientation = "up";
			this.up.BackColor = Color.Green;
		}
		private void right_Click(object sender, EventArgs e)
		{
			var old = this.Controls.Find(orientation, true);
			old[0].BackColor = Color.Snow;
			orientation = "right";
			this.right.BackColor = Color.Green;
		}
		private void left_Click(object sender, EventArgs e)
		{
			var old = this.Controls.Find(orientation, true);
			old[0].BackColor = Color.Snow;
			orientation = "left";
			this.left.BackColor = Color.Green;
		}
		private void down_Click(object sender, EventArgs e)
		{
			var old = this.Controls.Find(orientation, true);
			old[0].BackColor = Color.Snow;
			orientation = "down";
			this.down.BackColor = Color.Green;
		}

		//placement click function
		private void place_Click(object sender, EventArgs e)
		{
			if (currentShip != "" && !placed.Contains(currentShip))
			{
				int cellsToFill = 0;
				switch (currentShip)
				{
					case "carrier":
						cellsToFill = 5;
						break;
					case "battleship":
						cellsToFill = 4;
						break;
					case "destroyer":
						cellsToFill = 3;
						break;
					case "cruiser":
						cellsToFill = 3;
						break;
					case "submarine1":
						cellsToFill = 2;
						break;
					case "submarine2":
						cellsToFill = 2;
						break;
				}
				char letter = (sender as Button).Name[0];
				char number = (sender as Button).Name[1];
				string[] cells = new string[cellsToFill];
				List<string> filled = new List<string>();
				Console.WriteLine("Storage Count: {0}", storage[0].ToString());
				if (storageCount != 0)
				{
					for(int x=0; x<storageCount; x++)
					{
						foreach (var c in storage[x].cells)
						{
							Console.WriteLine("Cell List: {0}", c);
							filled.Add(c);
						}
					}
				}

				for (int i=0; i<cellsToFill; i++)
				{
					string cell = letter.ToString() + number.ToString();
					if (letter > 'J' | letter < 'A' | number < '0' | number > '9')
					{
						throw new Exception("Ship won't fit, try again");
					}
					if (filled.Count > 0 && filled.Contains(cell))
					{
						throw new Exception("Can't overlap with another ship");
					}
					switch (orientation)
					{
						case "right":
							letter++;
							break;
						case "left":
							letter--;
							break;
						case "down":
							number++;
							break;
						case "up":
							number--;
							break;
					}
					cells[i] = cell;
				}
				Console.Write("Cells:");
				foreach(var obj in cells)
				{
					var fill = this.Controls.Find(obj, true);
					fill[0].BackColor = Color.Green;
					Console.Write("{0},", obj);
				}
				Console.WriteLine();
				placed[numPlaced] = currentShip;
				numPlaced++;
				storage[storageCount] = new ship(currentShip, cellsToFill, cells);
				storageCount++;
				var thing = this.Controls.Find(currentShip,true);
				thing[0].BackColor = default(Color);
				currentShip = "";
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
