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
        //положение области в пространстве
        public float X = -150;
        public float Y = 0;
        public Color paint = Color.Red;
        public Zone(Color color)
        {
            paint = color;
        }
        //отрисовка области на форме
        public void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(paint),X,150,150,150);
            
        }
        // метод дающий значение положения и формы объекта, для просчета векторного взаимодействия объектов
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(X, 150, 150, 150);
            return path;
        }
        //метод для изменения цвета по нажатию кнопки на форме
        public void changeColor(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        paint = Color.LightGoldenrodYellow;
                        break;
                    }
                case 2:
                    {
                        paint = Color.MediumSeaGreen;
                        break;
                    }
                case 3:
                    {
                        paint = Color.Magenta;
                        break;
                    }
                case 4:
                    {
                        paint = Color.MediumVioletRed;
                        break;
                    }
            }
        }
    }
}
