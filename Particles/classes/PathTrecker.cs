using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class PathTrecker
    {
        public virtual GraphicsPath GetGraphicsPath()
        {
            return new GraphicsPath();
        }
        public virtual bool Overlaps(PathTrecker obj, Graphics g)
        {

            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();


            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }
    }
}
