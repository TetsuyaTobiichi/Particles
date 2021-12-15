using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class Zone:PathTrecker
    {
        float X, Y;
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Red),250,150,200,200);
            
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(250, 150, 200, 200);
            return path;
        }
    }
}
