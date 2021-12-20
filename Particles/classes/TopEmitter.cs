using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class TopEmitter:Emitter
    {
        public int Width=726;
        
        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); 

           
            particle.X = Particle.rnd.Next(Width); // позиция X -- произвольная точка от 0 до Width
            particle.Y = 0;

            particle.SpeedY = 1; // гравитация
            particle.SpeedX = Particle.rnd.Next(-2, 2); // разброс влево и вправо у частиц 
            particle.changeColor(Color.Black);
        }
    }
}
