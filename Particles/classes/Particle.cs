using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.classes
{
    class Particle:PathTrecker
    {
        public int Radius; // радуис частицы
        public float X, Y; //координаты положения частицы в пространстве
        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y
        public float Life; //время нахождения частицы на форме
        public static Random rnd = new Random();
        public Color color = Color.Black;
        public Particle()
        {
            var direction = (double)rnd.Next(360);
            var speed = 1 + rnd.Next(10);
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);
            Radius = 2 + rnd.Next(10);
            Life = 20 + rnd.Next(100);
        }
        //появление частицы на форме 
        public void Render(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);
            var color = Color.FromArgb(alpha, this.color);
            var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }
        // метод дающий значение положения и формы частицы, для просчета векторного взаимодействия объектов
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(X - Radius, Y - Radius, Radius * 2, Radius * 2);
            return path;
        }
        //изменение цвета
        public  void changeColor(Color color)
        {
                this.color = color;
        }

    }
}
