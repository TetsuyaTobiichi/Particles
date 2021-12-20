using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class Teleport:Zone
    {
        public float Xi = 0, Yi = 0;
        public float Xo = 0, Yo = 0;
        public Teleport(Color paint) : base(paint) { }
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Blue,10), Xi-50, Yi-50, 100, 100);
            g.DrawEllipse(new Pen(Color.Orange,10), Xo - 50, Yo - 50, 100, 100);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(Xi-50, Yi-50, 100, 100);
            return path;
        }
    }
}
