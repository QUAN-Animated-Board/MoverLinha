using static System.Windows.Forms.LinkLabel;

namespace MoverLinha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = 950;
            this.Height = 700;
            bm = new Bitmap(LineMover.Width, LineMover.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            LineMover.Image = bm;

            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(LineMover_Paint_1);
            this.MouseMove += new MouseEventHandler(LineMover_MouseMove_1);
            this.MouseDown += new MouseEventHandler(LineMover_MouseDown_1);
            this.MouseUp += new MouseEventHandler(LineMover_MouseUp_1);

            this.Lines = new List<GraphLine>()
            {
              new GraphLine (10, 10, 100, 200),
              new GraphLine (10, 150, 120, 40),
              new GraphLine (100, 200, 120, 40),
            };

        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen pe = new Pen(Color.Black, 2);
        Pen erase = new Pen(Color.White, 10);
        int index;

        int x, y, sX, sY, cX, cY;

        private void LineMover_MouseUp_1(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(pe, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                g.DrawRectangle(pe, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                var size = 10;
                var buffer = new Bitmap(size * 2, size * 2);

                using (var g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.Black);
                    g.DrawLine(new Pen(Color.Green, 3), cX, cY, sX, sY);
                }

                List<GraphLine> du = new List<GraphLine>()
                {
                    new GraphLine (cX, cY, x, y),
                };
                // Add List using AddRange
                System.Diagnostics.Debug.WriteLine(du);
                Lines.AddRange(du);

            }

            if (Moving != null)
            {
                this.Capture = false;
                Moving = null;
            }
            RefreshLineSelection(e.Location);

            index = 0;
        }

        private void LineMover_MouseDown_1(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;

            RefreshLineSelection(e.Location);
            if (this.SelectedLine != null && Moving == null)
            {
                this.Capture = true;
                Moving = new MoveInfo
                {
                    Line = this.SelectedLine,
                    StartLinePoint = SelectedLine.StartPoint,
                    EndLinePoint = SelectedLine.EndPoint,
                    StartMoveMousePoint = e.Location
                };
            }
            RefreshLineSelection(e.Location);
        }

        private void LineMover_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Graphics g = e.Graphics;

            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(pe, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(pe, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(pe, cX, cY, x, y);
                }
            }

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (var line in Lines)
            {
                var color = line == SelectedLine ? Color.Red : Color.Black;
                var pen = new Pen(color, 2);
                e.Graphics.DrawLine(pen, line.StartPoint, line.EndPoint);
            }
        }

        private void LineMover_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (Moving != null)
            {
                Moving.Line.StartPoint = new PointF(Moving.StartLinePoint.X + e.X - Moving.StartMoveMousePoint.X, Moving.StartLinePoint.Y + e.Y - Moving.StartMoveMousePoint.Y);
                Moving.Line.EndPoint = new PointF(Moving.EndLinePoint.X + e.X - Moving.StartMoveMousePoint.X, Moving.EndLinePoint.Y + e.Y - Moving.StartMoveMousePoint.Y);
            }
            RefreshLineSelection(e.Location);

            LineMover.Refresh();
            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            index = 5;
            //for (int i = 0; i < Lines.Count; i++)
            //{
            //    System.Diagnostics.Debug.WriteLine(Lines[i]);
            //}
        }

        private void RefreshLineSelection(Point point)
        {
            var selectedLine = FindLineByPoint(Lines, point);
            if (selectedLine != this.SelectedLine)
            {
                this.SelectedLine = selectedLine;
                this.Invalidate();
            }
            if (Moving != null)
                this.Invalidate();

            this.Cursor =
                Moving != null ? Cursors.Hand :
                SelectedLine != null ? Cursors.SizeAll :
                  Cursors.Default;

            LineMover.Refresh();
        }



        public List<GraphLine> Lines = new List<GraphLine>();
        GraphLine SelectedLine = null;
        MoveInfo Moving = null;


        static GraphLine FindLineByPoint(List<GraphLine> lines, Point p)
        {
            var size = 10;
            var buffer = new Bitmap(size * 2, size * 2);
            foreach (var line in lines)
            {
                //draw each line on small region around current point p and check pixel in point p 

                using (var g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.Black);
                    g.DrawLine(new Pen(Color.Green, 3), line.StartPoint.X - p.X + size, line.StartPoint.Y - p.Y + size, line.EndPoint.X - p.X + size, line.EndPoint.Y - p.Y + size);
                }

                if (buffer.GetPixel(size, size).ToArgb() != Color.Black.ToArgb())
                    return line;
            }
            return null;
        }

        private void LineMover_Click(object sender, EventArgs e)
        {

        }
    }

    public class MoveInfo
    {
        public GraphLine Line;
        public PointF StartLinePoint;
        public PointF EndLinePoint;
        public Point StartMoveMousePoint;
    }
    public class GraphLine
    {
        public GraphLine(float x1, float y1, float x2, float y2)
        {
            this.StartPoint = new PointF(x1, y1);
            this.EndPoint = new PointF(x2, y2);
        }
        public PointF StartPoint;
        public PointF EndPoint;
    }
}