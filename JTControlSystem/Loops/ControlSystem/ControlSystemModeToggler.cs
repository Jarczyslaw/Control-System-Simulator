using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTControlSystem
{
    public class ControlSystemModeToggler
    {
        private ControlSystemMode mode;
        private List<double> toggles;

        public ControlSystemModeToggler() { }

        public ControlSystemModeToggler(ControlSystemMode initialMode, params double[] times)
        {
            SetParameters(initialMode, times);
        }

        public void SetParameters(ControlSystemMode initialMode, params double[] times)
        {
            if (times.Length == 0 || times.Any(t => t < 0d))
                throw new Exception("Times should be more than 0 and not empty");

            mode = initialMode;
            toggles = times.ToList();
        }

        public ControlSystemMode GetMode(double time)
        {
            for(int i = 0;i < toggles.Count;i++)
            {
                if (time >= toggles[i])
                {
                    Toggle();
                    toggles.RemoveAt(i);
                }
            }
            return mode;
        }

        private void Toggle()
        {
            if (mode == ControlSystemMode.OpenLoop)
                mode = ControlSystemMode.CloseLoop;
            else
                mode = ControlSystemMode.OpenLoop;
        }
    }
}
