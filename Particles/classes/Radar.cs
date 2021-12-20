using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class Radar:Zone
    {
        public int countParticles = 0;
        public int size = 0;
        public Radar(Color paint) : base(paint) { }
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(paint), X, Y, size, size);
            g.DrawString(countParticles.ToString(), new Font("Arial", 24, FontStyle.Regular), Brushes.Black, X, Y);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(X, Y, size, size);
            return path;
        }
    }
}
