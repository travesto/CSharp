using System.Media;
namespace battleship3
{
    partial class FormSplash
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_play_offline = new System.Windows.Forms.Button();
            this.read_nickname = new System.Windows.Forms.TextBox();
            this.text_nickname = new System.Windows.Forms.TextBox();
            this.button_play_online = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_play_offline
            // 
            this.button_play_offline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_play_offline.Location = new System.Drawing.Point(361, 413);
            this.button_play_offline.Name = "button_play_offline";
            this.button_play_offline.Size = new System.Drawing.Size(277, 65);
            this.button_play_offline.TabIndex = 0;
            this.button_play_offline.Text = "Play Offline";
            this.button_play_offline.UseVisualStyleBackColor = true;
            this.button_play_offline.Click += new System.EventHandler(this.button1_Click);
            // 
            // read_nickname
            // 
            this.read_nickname.BackColor = System.Drawing.SystemColors.Menu;
            this.read_nickname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.read_nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.read_nickname.Location = new System.Drawing.Point(361, 241);
            this.read_nickname.Name = "read_nickname";
            this.read_nickname.ReadOnly = true;
            this.read_nickname.Size = new System.Drawing.Size(100, 19);
            this.read_nickname.TabIndex = 1;
            this.read_nickname.Text = "Nickname";
            // 
            // text_nickname
            // 
            this.text_nickname.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.text_nickname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_nickname.Location = new System.Drawing.Point(538, 241);
            this.text_nickname.Name = "text_nickname";
            this.text_nickname.Size = new System.Drawing.Size(100, 26);
            this.text_nickname.TabIndex = 2;
            this.text_nickname.TextChanged += new System.EventHandler(this.text_nickname_TextChanged);
            // 
            // button_play_online
            // 
            this.button_play_online.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_play_online.Location = new System.Drawing.Point(361, 325);
            this.button_play_online.Name = "button_play_online";
            this.button_play_online.Size = new System.Drawing.Size(277, 65);
            this.button_play_online.TabIndex = 3;
            this.button_play_online.Text = "Play Online";
            this.button_play_online.UseVisualStyleBackColor = true;
            this.button_play_online.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(361, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 611);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_play_online);
            this.Controls.Add(this.text_nickname);
            this.Controls.Add(this.read_nickname);
            this.Controls.Add(this.button_play_offline);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormSplash";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_play_offline;
        private System.Windows.Forms.TextBox read_nickname;
        private System.Windows.Forms.TextBox text_nickname;
        private System.Windows.Forms.Button button_play_online;
        private System.Windows.Forms.Button button1;
    }

    internal class MediaPlayer
    {
        private object mediaPlayer;

        /// <summary>
        /// Music is played
        /// </summary>
        private void playMusic()
        {
            mediaPlayer.Open(new Uri(Directory.GetCurrentDirectory() + "\\Sounds\\music.mp3"));
            mediaPlayer.Volume = 0.2;
            mediaPlayer.Play();
            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
        }

        /// <summary>
        /// Make the music loop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Media_Ended(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }
    }
}

