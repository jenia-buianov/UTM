using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{

    // Декоратор
    class ClockWithArrows : IClockBase
    {
        Point center;
        double R;
        Clock clock;
        Graphics _g;
        Bitmap bm;


        public IClockBase Clone
        {
            get
            {
                return clock;
            }
        }

        public ClockWithArrows(IClockBase clockbase)
        {
            clock = (Clock)clockbase;
            center = new Point(clock.DrawingSize.Width / 2, clock.DrawingSize.Height / 2);
            R =( clock.DrawingSize.Width / 2 < clock.DrawingSize.Height / 2 ? clock.DrawingSize.Width / 2 : clock.DrawingSize.Height / 2)-50;
            bm = new Bitmap(clock.DrawingSize.Width, clock.DrawingSize.Height);
            _g = Graphics.FromImage(bm);
            clock.ParentForm.Resize += new EventHandler(OnResize);
        }
        public void Show()
        {
            double PI = Math.PI;
            int fontsize = (int)(R * PI / 12);

            _g.Clear(SystemColors.Control);


            Rectangle clockrect = new Rectangle((int)(center.X - R-fontsize/2), (int)(center.Y - R-fontsize/2), (int)((R * 2) + fontsize), (int)((R * 2) + fontsize));

            _g.FillEllipse(new SolidBrush(clock.Background), 
                clockrect);
            _g.DrawEllipse(new Pen(clock.Titlecol),
               clockrect);
            
            //Font font = new Font("Times New Roman", fontsize);

            Point pt = new Point();
            Font f = new Font("Arial", fontsize/2);
            for (int i = 1; i < 13; i++)
            {
                pt.X = (int)(center.X + R * Math.Cos((i * Math.PI / 6.0) - Math.PI / 2.0)-7);
                pt.Y = (int)(center.Y + R * Math.Sin((i * Math.PI / 6.0) - Math.PI / 2.0)-7);
                _g.DrawString(i.ToString(), f, Brushes.Black, pt);
            }
            
            //рисуем стрелочки

            //часовая
            double angle = ((clock.Time.Hour / 12.0) * 2 * Math.PI) + ((clock.Time.Minute / (60.0 * 12.0)) * 2 * Math.PI) - Math.PI / 2.0;
            _g.DrawLine(new Pen(clock.Titlecol, fontsize / 5), center.X, center.Y,
                (float)(center.X + R / 2 * Math.Cos(-angle)),//+ 12 * min / 360)), 
                (float)(center.Y - R / 2 * Math.Sin(-angle)));// + 12 * min / 360)));

            //минутная
            angle = ((clock.Time.Minute / 60.0)+ (clock.Time.Second / (60.0*12.0))) * 2 * Math.PI - Math.PI / 2.0;
            _g.DrawLine(new Pen(clock.Titlecol, fontsize / 7), center.X, center.Y,
               (float)(center.X + R * Math.Cos(-angle)), (float)(center.Y - R * Math.Sin(-angle)));

            //секундная
            angle = (clock.Time.Second / 60.0) * 2 * Math.PI - Math.PI / 2.0;
            _g.DrawLine(new Pen(clock.Titlecol, fontsize / 10), center.X, center.Y,
               (float)(center.X + R * Math.Cos(-angle)), (float)(center.Y - R * Math.Sin(-angle)));

            clock.Graphic.DrawImage(bm as Image, clock.Location);
        }

        public void Update()
        {
            ((IClockBase)clock).Update();
        }
        private void OnResize(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            Size size = form.Size;
            bm = new Bitmap(size.Width, size.Height);
            _g = Graphics.FromImage(bm);
            center = new Point(clock.DrawingSize.Width / 2, clock.DrawingSize.Height / 2);
            R =( clock.DrawingSize.Width / 2 < clock.DrawingSize.Height / 2 ? clock.DrawingSize.Width / 2 : clock.DrawingSize.Height / 2)-50;


        }
    }
}
