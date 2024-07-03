using System;
using System.Drawing;
using System.Windows.Forms;

namespace KochFractalTriangle
{
    public partial class Form1 : Form
    {
        private int depth = 4;  // Порядок фракталу
        private PointF P1 = new PointF(100, 100);
        private PointF P2 = new PointF(400, 100);
        private PointF P3 = new PointF(250, 400);

        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            // Малювання кривих Коха на сторонах трикутника
            DrawKochCurve(g, P1, P2, depth);
            DrawKochCurve(g, P2, P3, depth);
            DrawKochCurve(g, P3, P1, depth);
        }

        private void DrawKochCurve(Graphics g, PointF p1, PointF p2, int depth)
        {
            if (depth == 0)
            {
                g.DrawLine(Pens.Black, p1, p2);
            }
            else
            {
                float deltaX = p2.X - p1.X;
                float deltaY = p2.Y - p1.Y;

                PointF p3 = new PointF(p1.X + deltaX / 3, p1.Y + deltaY / 3);
                PointF p4 = new PointF(
                    (float)(0.5 * (p1.X + p2.X) + Math.Sqrt(3) * (p1.Y - p2.Y) / 6),
                    (float)(0.5 * (p1.Y + p2.Y) + Math.Sqrt(3) * (p2.X - p1.X) / 6)
                );
                PointF p5 = new PointF(p1.X + 2 * deltaX / 3, p1.Y + 2 * deltaY / 3);

                DrawKochCurve(g, p1, p3, depth - 1);
                DrawKochCurve(g, p3, p4, depth - 1);
                DrawKochCurve(g, p4, p5, depth - 1);
                DrawKochCurve(g, p5, p2, depth - 1);
            }
        }
    }
}
