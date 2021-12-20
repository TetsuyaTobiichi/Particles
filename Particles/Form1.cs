using Particles.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particles
{
    public partial class Form1 : Form
    {
        Radar radar = new Radar(Color.Green);
        Emitter emitter = new TopEmitter();
        Teleport zone = new Teleport(Color.Red);
        Zone colors = new Zone(Color.Blue);
        public Form1()
        {
            InitializeComponent();
            picDisplay.MouseWheel += picDisplay_MouseWheel;
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                // рисую на изображении
                g.Clear(Color.White);
                emitter.Render(g);
                zone.Render(g);
                colors.Render(g);
                radar.Render(g);
                emitter.overlaps(zone, g);
                emitter.overlaps(colors, g);
                emitter.overlaps(radar, g);
            }
            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            radar.X = e.X;
            radar.Y = e.Y;
        }
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            radar.Radius += e.Delta/20; 
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            colors.X = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            zone.changeColor((rnd.Next() % 4)+1);
            colors.changeColor((rnd.Next() % 4) + 1);
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                zone.Xi = e.X;
                zone.Yi = e.Y;
            }
            else {
                zone.Xo = e.X;
                zone.Yo = e.Y;
            }
        }
    }
}
