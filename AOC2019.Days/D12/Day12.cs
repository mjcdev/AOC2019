using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D12
{
    public class Day12
    {
        public int TotalEnergyInSystemAfterSteps(IEnumerable<Moon> moons, int steps)
        {
            var moonsArray = moons.ToArray();

            for (var step = 0; step < steps; step++)
            {
                for (var moonLeft = 0; moonLeft < moonsArray.Length; moonLeft++)
                {
                    for (var moonRight = 0; moonRight < moonsArray.Length; moonRight++)
                    {
                        if (moonLeft != moonRight)
                        {
                            moonsArray[moonLeft].UpdateVelocityForMoon(moonsArray[moonRight]);
                        }                        
                    }
                }

                for(var moon = 0; moon < moonsArray.Length; moon++)
                {
                    moonsArray[moon].UpdatePosition();
                }
            }

            return moonsArray.Sum(m => m.TotalEnergy());
        }
    }
}
