using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D12
{
    public class Moon
    {
        public Moon(int x, int y, int z)
        {
            XPosition = x;
            YPosition = y;
            ZPosition = z;
        }


        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public int ZPosition { get; set; }

        public int XVelocity { get; set; } = 0;

        public int YVelocity { get; set; } = 0;

        public int ZVelocity { get; set; } = 0;


        public void UpdatePosition()
        {
            XPosition += XVelocity;
            YPosition += YVelocity;
            ZPosition += ZVelocity;
        }

        public void UpdateVelocityForMoon(Moon moon)
        {
            if (XPosition < moon.XPosition)
            {
                XVelocity++;
            }
            if (XPosition > moon.XPosition)
            {
                XVelocity--;
            }

            if (YPosition < moon.YPosition)
            {
                YVelocity++;
            }
            if (YPosition > moon.YPosition)
            {
                YVelocity--;
            }

            if (ZPosition < moon.ZPosition)
            {
                ZVelocity++;
            }
            if (ZPosition > moon.ZPosition)
            {
                ZVelocity--;
            }
        }

        public int TotalEnergy()
        {
            return TotalPotentialEnergy() * TotalKineticEnergy();
        }

        private int TotalPotentialEnergy()
        {
            return Math.Abs(XPosition) + Math.Abs(YPosition) + Math.Abs(ZPosition);
        }

        private int TotalKineticEnergy()
        {
            return Math.Abs(XVelocity) + Math.Abs(YVelocity) + Math.Abs(ZVelocity);
        }
    }
}
