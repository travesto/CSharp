using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Battleship
{
    //class to make game window
    public partial class MainWindow : Windows
    {
        Grid grid = new Grid();
        private Create create;
        private PlaceShip placeShip;
        private Multiplayer multiplayer;
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            playMusic();
            InitializeGame();
        }
        //start game
        private void InitializeGame()
        {
            //create window
            Content = grid;

            this.MinHeight = 300;
            this.MinWidth = 330;
            this.Height = 300;
            this.Width = 330;

            //start setup
            setup = new Setup();
            grid.Children.Add(setup);

            //create event handler
            setup.play += new EventHandler(shipSetup);
        }
        
        //place ships
        <param name="sender"></param>
        <param name="w"></param>
        private void shipSetup(object sender, EventArgs e)
        {
            //finish setup
            grid.Children.Clear();

            //resize window
            this.MinWidth = 460;
            this.MinHeight = 530;
            this.Width = 460;
            this.Height = 530;

            //enable ship placing
            placeShip = new PlaceShip();
            grid.Children.Add(placeShip);
            placeShip.play += new EventHandler(playGame);
        }

        //multiplayer sockets go here


    }
}