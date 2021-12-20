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
        public int Radius = 0;
        public Radar(Color paint) : base(paint) { }
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(paint), X-Radius, Y-Radius, Radius*2, Radius*2);
            g.DrawString(countParticles.ToString(), new Font("Arial", 24, FontStyle.Regular), Brushes.Black, X, Y);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = new GraphicsPath();
            path.AddEllipse(X - Radius, Y - Radius, Radius * 2, Radius * 2);
            return path;
        }
       
    }
}
