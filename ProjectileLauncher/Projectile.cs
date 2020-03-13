using System;
using System.Collections.Generic;
using System.Text;
using RayTracer;

namespace ProjectileLauncher
{
    internal class Projectile
    {
        public RayTracer.Tuple Position { get; set; }
        public RayTracer.Tuple Velocity { get; set; }

        public Projectile(RayTracer.Tuple position, RayTracer.Tuple velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
        }
    }
}
