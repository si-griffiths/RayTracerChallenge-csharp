using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectileLauncher
{
    internal class Environment
    {
        public RayTracer.Tuple Gravity { get; set; }
        public RayTracer.Tuple Wind { get; set; }

        public Environment(RayTracer.Tuple gravity, RayTracer.Tuple wind)
        {
            this.Gravity = gravity;
            this.Wind = wind;
        }
    }
}
