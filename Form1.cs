using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public int speed_left = 4; //speed of the ball
        public int speed_top = 4;
        public int point = 0; //score

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide(); // cacher le curseur
            this.FormBorderStyle = FormBorderStyle.None; // désactive toute autre bordure
            this.TopMost = true; // faire intervenir the form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds; // make it fullscreen

            Rackette.Top = playground.Bottom - (playground.Bottom / 10); // positionner la rackette

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2);
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Rackette.Left = Cursor.Position.X - (Rackette.Width / 2);
            Ball.Left += speed_left; // move the ball
            Ball.Top += speed_top;

            if (Ball.Bottom >= Rackette.Top && Ball.Bottom <= Rackette.Bottom && Ball.Left >= Rackette.Left && Ball.Right <= Rackette.Right) // rackette collision
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top; // changer la direction
                point += 1;
                lbl_points.Text = point.ToString();
                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
            }

            if (Ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (Ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (Ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

            if (Ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false; // ball is out stop the game
                gameover_lbl.Visible = true;
            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } // appuyer sur eshape pour fermer
            if (e.KeyCode == Keys.Enter)
            {
                Ball.Top = 50;
                Ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                point = 4;
                lbl_points.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
                playground.BackColor = Color.White;



            }
        }
    }
}
        
