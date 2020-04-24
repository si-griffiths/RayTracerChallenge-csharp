using RayTracer;
using System;

namespace ProjectileLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            // projectile starts one unit above the origin
            // velocity is normalized to one unit/tick
            var position = RayTracer.Tuple.Point(0, 1, 0);
            var velocity = RayTracer.Tuple.Normalize(RayTracer.Tuple.Vector(1, 1.8, 0)) * 11.25;
            var projectile = new Projectile(position, velocity);

            // gravity -0.1 unit/tick
            // wind is -0.01 unit/tick
            var gravity = RayTracer.Tuple.Vector(0, -0.1, 0);
            var wind = RayTracer.Tuple.Vector(-0.01, 0, 0);
            var environment = new Environment(gravity, wind);

            Canvas canvas = new Canvas(900, 550);
            Color color = new Color(255, 255, 255);

            int ticks = 0;
            do
            {
                projectile = Tick(environment, projectile);
                ticks++;
                Console.WriteLine(projectile.Position);
                int x = (int)projectile.Position.X;
                int y = canvas.Height - (int)projectile.Position.Y;
                canvas.WritePixel(x, y, color);
            } while (projectile.Position.Y >= 0);

            Console.WriteLine("Ticks: " + ticks);
            System.IO.File.WriteAllText(@"C:\Temp\launcher.ppm", canvas.CanvasToPpm());
        }

        private static Projectile Tick(Environment env, Projectile proj)
        {
            var position = proj.Position + proj.Velocity;
            var velocity = proj.Velocity + env.Gravity + env.Wind;
            return new Projectile(position, velocity);
        }

    }
}
