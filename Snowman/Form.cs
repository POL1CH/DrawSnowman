namespace Snowman
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Get the Graphics object for drawing on the form
            Graphics g = e.Graphics;

            // Draw three colored balls
            SolidBrush snowmanBrush = new SolidBrush(Color.White);
            g.FillEllipse(snowmanBrush, 250, 400, 200, 200); // Lower balloon
            g.FillEllipse(snowmanBrush, 275, 275, 150, 150); // Middle ball
            g.FillEllipse(snowmanBrush, 300, 190, 100, 100); // Top balloon

            // Draw a nose with a carrot
            SolidBrush carrotBrush = new SolidBrush(Color.OrangeRed);
            Point[] nosePoints = new Point[] { new Point(340, 235), new Point(360, 235), new Point(350, 260) };
            g.FillPolygon(carrotBrush, nosePoints);

            // Let's draw the eyes
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            g.FillEllipse(blackBrush, 330, 215, 10, 10);
            g.FillEllipse(blackBrush, 362, 215, 10, 10);

            g.FillEllipse(blackBrush, 345, 300, 12, 12);
            g.FillEllipse(blackBrush, 345, 340, 12, 12);
            g.FillEllipse(blackBrush, 345, 380, 12, 12);

            // Draw a hood in the form of a wind
            SolidBrush hatBrush = new SolidBrush(Color.Black);
            g.FillEllipse(hatBrush, 285, 175, 130, 30);

            // Draw the sail of the cap
            Point[] windmillPoints = new Point[] { new Point(320, 178), new Point(350, 98), new Point(380, 178) };
            g.FillPolygon(hatBrush, windmillPoints);

            // Let's draw hands
            Pen armPen = new Pen(blackBrush, 5); // Hand lines
            g.DrawLine(armPen, 295, 300, 225, 360); // Left hand
            g.DrawLine(armPen, 405, 300, 470, 360); // The Right Hand

            DrawSnowflakes(g, Brushes.White, 100); // Determine the desired number of snowflakes
        }

        private void DrawSnowflakes(Graphics g, Brush brush, int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int x = random.Next(this.Width);
                int y = random.Next(this.Height);

                // Check if the snowflake is not overlapping with the snowman
                if (!IsPointInsideSnowman(x, y))
                {
                    g.DrawLine(new Pen(brush, 1), x - 5, y, x + 5, y);
                    g.DrawLine(new Pen(brush, 1), x, y - 5, x, y + 5);
                }
            }
        }

        private bool IsPointInsideSnowman(int x, int y)
        {
            Rectangle body1 = new Rectangle(250, 400, 200, 200);
            Rectangle body2 = new Rectangle(275, 275, 150, 150);
            Rectangle body3 = new Rectangle(300, 190, 100, 100);

            return body1.Contains(x, y) || body2.Contains(x, y) || body3.Contains(x, y);
        }
    }

}