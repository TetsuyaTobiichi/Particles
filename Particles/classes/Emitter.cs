using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class Emitter : PathTrecker
    {
        List<Particle> particles = new List<Particle>();
        //координаты положения мыши
        public int MousePositionX;
        public int MousePositionY;
        //
        //параметры постоянного изменение координат на x или y а-ка "гравитации"
        public float GravitationX = 0;
        public float GravitationY = 1;
        //
        //кол-во частиц на форме
        public int ParticlesCount = 1000;
        //
        //метод для отрисовки наших частиц на форме
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Render(g);
            }
        }
        //метод необходимый для постоянного перемещения частиц в точку эмиттера
        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                //проверка на кол-во "жизней у частицы", если оно меньше или = 0, то
                //пересоздаем частицу,иначе просчитываем ее следующее состояние
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                }
                else
                {
                    //изменение координат частицы
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            //цикл который поддерживает кол-во частиц на форме
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
        //метод для полного пересчета индивидуальных данных частицы
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
        //методы проверяющие взаимодействие частиц и объектов
        public void overlaps(Teleport obj, Graphics g)
        {
            //взаимодействие частиц с телепортом, переносит их в центр второго портала
            foreach (var particle in particles)
            {
                if (obj.Overlaps(particle, g))
                {
                    particle.changeColor(obj.paint);
                    particle.X = obj.Xo;
                    particle.Y = obj.Yo;
                }

            }

        }
        public void overlaps(Zone obj, Graphics g)
        {
            //взаимодейсвие частиц с зоной перекрашивает их в новый цвет
            foreach (var particle in particles)
            {
                if (obj.Overlaps(particle, g))
                {
                    particle.changeColor(obj.paint);
                }
            }
        }
        public void overlaps(Radar obj, Graphics g)
        {
            //взаимодействие с радаром изменяет счетчик внутри радара на кол-во частиц внутри радара,
            //а также перекрашивает их на время нахождения в зоне радара
            obj.countParticles = 0;
            foreach (var particle in particles)
            {
                if (obj.Overlaps(particle, g))
                {
                    particle.changeColor(obj.paint);
                    obj.countParticles++;
                }
                else
                    if (particle.color == obj.paint)
                    particle.changeColor(Color.Black);

            }
        }
    }
}
