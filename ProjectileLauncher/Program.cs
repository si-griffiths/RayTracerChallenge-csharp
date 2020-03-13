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
            var velocity = RayTracer.Tuple.Normalize(RayTracer.Tuple.Vector(5, 20, 0));
            var projectile = new Projectile(position, velocity);

            // gravity -0.1 unit/tick
            // wind is -0.01 unit/tick
            var gravity = RayTracer.Tuple.Vector(0, -0.1, 0);
            var wind = RayTracer.Tuple.Vector(-0.01, 0, 0);
            var environment = new Environment(gravity, wind);

            int ticks = 0;
            do
            {
                projectile = Tick(environment, projectile);
                ticks++;
                Console.WriteLine(projectile.Position);
            } while (projectile.Position.Y >= 0);

            Console.WriteLine("Ticks: " + ticks);
        }

        private static Projectile Tick(Environment env, Projectile proj)
        {
            var position = RayTracer.Tuple.Add(proj.Position, proj.Velocity);
            var velocity = RayTracer.Tuple.Add(RayTracer.Tuple.Add(proj.Velocity, env.Gravity), env.Wind); // this is ugly, create overrides in Tuple class for addition
            return new Projectile(position, velocity);
        }

    }
}
