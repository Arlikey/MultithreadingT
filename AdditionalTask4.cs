using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultithreadingT
{
    public partial class AdditionalTask4 : Form
    {
        private const int BallCount = 5;
        private const int BallSize = 20;
        private readonly List<Ball> balls = new List<Ball>();
        private readonly List<Thread> threads = new List<Thread>();
        private readonly Random random = new Random();

        public AdditionalTask4()
        {
            InitializeComponent();
            InitializeBalls();
        }

        private void InitializeBalls()
        {
            for (int i = 0; i < BallCount; i++)
            {
                var ball = new Ball
                {
                    Position = new Point(random.Next(panel1.Width - BallSize), random.Next(panel1.Height - BallSize)),
                    Velocity = new Point(random.Next(-5, 5), random.Next(-5, 5)),
                    Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))
                };
                balls.Add(ball);
            }
        }

        private void MoveBall(Ball ball)
        {
            while (true)
            {
                    var newX = ball.Position.X + ball.Velocity.X;
                    var newY = ball.Position.Y + ball.Velocity.Y;

                    if (newX < 0 || newX > panel1.Width - BallSize)
                        ball.Velocity = new Point(-ball.Velocity.X, ball.Velocity.Y);

                    if (newY < 0 || newY > panel1.Height - BallSize)
                        ball.Velocity = new Point(ball.Velocity.X, -ball.Velocity.Y);

                    ball.Position = new Point(
                        Math.Max(0, Math.Min(panel1.Width - BallSize, newX)),
                        Math.Max(0, Math.Min(panel1.Height - BallSize, newY))
                    );

                Thread.Sleep(50);
            }
        }

        private void RefreshPanel()
        {
            while (true)
            {
                panel1.Invoke(new Action(() => panel1.Invalidate()));
                Thread.Sleep(30);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                foreach (var ball in balls)
                {
                    using (var brush = new SolidBrush(ball.Color))
                    {
                        e.Graphics.FillEllipse(brush, new Rectangle(ball.Position, new Size(BallSize, BallSize)));
                    }
            }
        }

        private void AdditionalTask4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < BallCount; i++)
            {
                int index = i;
                Thread thread = new Thread(() => MoveBall(balls[index]));
                threads.Add(thread);
                thread.Start();
            }

            var refreshThread = new Thread(RefreshPanel);
            refreshThread.Start();
        }
    }

    public class Ball
    {
        public Point Position { get; set; }
        public Point Velocity { get; set; }
        public Color Color { get; set; }
    }
}
