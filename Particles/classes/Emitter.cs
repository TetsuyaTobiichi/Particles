using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class Emitter:PathTrecker
    {
        List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 1; 
        public int ParticlesCount = 500;
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Render(g);
            }
        }
        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                }
                else
                {
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = new Particle();
                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.rnd.Next(100);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = (double)Particle.rnd.Next(360);
            var speed = 1 + Particle.rnd.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rnd.Next(10);
        }
        public void overlaps(Zone obj,Graphics g)
        {
            foreach (var particle in particles)
            {
                if(obj.Overlaps(particle,g))
                particle.changeColor(true);

            }

        }
    }
}
