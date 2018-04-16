using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDP_Lab._5
{
    public partial class Form1 : Form
    {
        private Object obj;
        private Racket racket;
        private List<Obstacle> obstacles;
        private Obstacle obstacle_detected;
        private int dimensionX;
        private int dimensionY;
        private int racket_dimensionX;
        private int racket_dimensionY;
        private int obstacle_dimensionX;
        private int obstacle_dimensionY;
        private int counter_score;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            dimensionX = 40;
            dimensionY = 40;
            racket_dimensionX = 100;
            racket_dimensionY = 20;
            obstacle_dimensionX = 100;
            obstacle_dimensionY = 20;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (obj != null)
            {
                e.Graphics.FillEllipse(obj.brush, obj.PositionX, obj.PositionY, obj.DimensionX, obj.DimensionY);
            }
            if(racket != null)
            {
                e.Graphics.FillRectangle(racket.brush, racket.PositionX, racket.PositionY, racket.DimensionX, racket.DimensionY);
            }
            if(obstacles != null)
            {
                foreach(var obstacle in obstacles)
                {
                    e.Graphics.FillRectangle(obstacle.brush, obstacle.PositionX, obstacle.PositionY, obstacle.DimensionX, obstacle.DimensionY);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (obj != null)
            {
                obj.MoveObject();
                CollisionObjectRacket(obj, racket, obstacles);
            }
            Invalidate();
        }


        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int speedX = 2, speedY = 2;

            if (this.timer1.Enabled == false)
            {
                this.timer1.Enabled = true;
            }

            obj = new Object(100, 100, speedX, speedY, dimensionX, dimensionY);
            racket = new Racket(200, 220, racket_dimensionX, racket_dimensionY);
            obstacles = new List<Obstacle>();
            obstacles.Add(new Obstacle(0, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(110, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(220, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(330, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(440, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(550, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(660, this.menuStrip1.Height, obstacle_dimensionX, obstacle_dimensionY));
            obstacles.Add(new Obstacle(45, this.menuStrip1.Height + 30, 120, obstacle_dimensionY));
            obstacles.Add(new Obstacle(265, this.menuStrip1.Height + 30, 220, obstacle_dimensionY));
            obstacles.Add(new Obstacle(595, this.menuStrip1.Height + 30, 120, obstacle_dimensionY));
            obstacles.Add(new Obstacle(45, this.menuStrip1.Height + 50, 120, obstacle_dimensionY));
            obstacles.Add(new Obstacle(265, this.menuStrip1.Height + 50, 220, obstacle_dimensionY));
            obstacles.Add(new Obstacle(595, this.menuStrip1.Height + 50, 120, obstacle_dimensionY));
            obstacles.Add(new Obstacle(265, this.menuStrip1.Height + 70, 220, obstacle_dimensionY));
        }

        public void CollisionObjectRacket(Object obj, Racket racket, List<Obstacle> obstacles)
        {
            bool collision = false;
            bool wrong_collision = false;

            if (obj.PositionY + obj.DimensionY >= racket.PositionY && obj.CenterX <= racket.PositionX + racket.DimensionX && obj.CenterX >= racket.PositionX)
            {
                collision = true;
                obj.MoveY = -obj.MoveY;
            }

            if(obj.PositionY <= 0 + this.menuStrip1.Height)
            {
                collision = true;
                obj.MoveY = -obj.MoveY;
            }

            if (obj.PositionY + obj.DimensionY >= this.ClientSize.Height)
            {
                wrong_collision = true;
                obj.MoveY = -obj.MoveY;
            }

            if(obj.PositionX <= 0)
            {
                collision = true;
                obj.MoveX = -obj.MoveX;
            }

            if(obj.PositionX + obj.DimensionX >= this.ClientSize.Width)
            {
                collision = true;
                obj.MoveX = -obj.MoveX;
            }

            foreach(var obstacle in obstacles)
            {
                if (obj.PositionY <= obstacle.PositionY + obstacle.DimensionY && obj.CenterX <= obstacle.PositionX + obstacle.DimensionX && obj.CenterX >= obstacle.PositionX)
                {
                    collision = true;
                    obstacle_detected = obstacle;
                    counter_score++;
                    obj.MoveY = -obj.MoveY;
                }
            }

            obstacles.Remove(obstacle_detected);

            Checker_Score();
            Checker_ListObstacles();

            if(collision)
            {
                return;
            }

            if(wrong_collision)
            {
                this.timer1.Enabled = false;
                MessageBox.Show("Game Over! Try more!");
            }
        }

        public void Checker_ListObstacles()
        {
            if(obstacles.Count == 0)
            {
                Invalidate();
                this.timer1.Enabled = false;
                MessageBox.Show("Good job, go to the next level!");
            }
        }

        public void Checker_Score()
        {
            this.label1.Text = "Score : " + counter_score;
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                racket.MoveToLeft();
            }

            if(e.KeyCode == Keys.Right)
            {
                racket.MoveToRight();
            }

            if(e.KeyCode == Keys.P)
            {
                this.timer1.Enabled = false;
            }

            if(e.KeyCode == Keys.R)
            {
                this.timer1.Enabled = true;
            }

            if(e.KeyCode == Keys.L)
            {
                this.timer1.Interval = 41;
            }

            if(e.KeyCode == Keys.M)
            {
                this.timer1.Interval = 21;
            }

            if(e.KeyCode == Keys.H)
            {
                this.timer1.Interval = 1;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if(this.timer1.Enabled == true)
            {
                this.timer1.Enabled = false;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if(this.timer1.Enabled == false)
            {
                this.timer1.Enabled = true;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 41;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 21;
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 1;
        }
    }
}
