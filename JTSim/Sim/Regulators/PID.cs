using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class PID : GenericRegulator
    {
        float Kp = 1.9f;
        float Ti = 1f;
        float Td = 0.15f;

        float processMax = 100f;
        float processMin = -100f;

        float sumE = 0f;
        float lastE = 0f;

        int iteration = 0;

        public override float Step(float setValue, float processValue)
        {
            float e = setValue - processValue;
            float P = Kp * e;
            sumE += e;
            float I = Kp * h / Ti * sumE;
            float D = 0f;
            if (iteration != 0)
                D = 1f / h * Kp * Td * (e - lastE);
            float u = P + I + D;
            if (u > processMax)
            {
                u = processMax;
                sumE -= e;
            } 
            else if (u < processMin)
            {
                u = processMin;
                sumE -= e;
            }
            lastE = e;
            iteration++;

            return u;
        }

        public override void Init()
        {
            iteration = 0;
            sumE = 0f;
        }
    }
}
