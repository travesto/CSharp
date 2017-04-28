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
        private PlayVSComp playVSComp;
        // private Multiplayer multiplayer;
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
        //<param name="sender"></param>
        //<param name="w"></param>
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
        
        /// <summary>
        /// Phase 3: PlayVSComp 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playGame(object sender, EventArgs e)
        {
            //Close shipPlacement
            grid.Children.Clear();

            //Resize window
            this.MinWidth = 953.286;
            this.MinHeight = 480;
            this.Width = 953.286;
            this.Height = 480;

            //Initialize game
            playVSComp = new PlayVSComp(setup.difficulty, shipPlacement.playerGrid, setup.name);

            //Add grid
            grid.Children.Add(playVSComp);
            playVSComp.replay += new EventHandler(replayGame);

        }
       // music player
        private void playMusic()
        {
            mediaPlayer.Open(new Uri(Directory.GetCurrentDirectory() + "\\music.mp3"));
            mediaPlayer.Volume = 0.20;
            mediaPlayer.Play();
            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
        }

        //loop music
        // <param name="sender"></param>
        // <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }
    }
}