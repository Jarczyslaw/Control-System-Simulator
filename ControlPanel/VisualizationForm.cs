using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlPanel
{
    public partial class VisualizationForm : Form
    {
        public VisualizationForm()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        public virtual void Start()
        {
            Console.WriteLine("Visualization start");
        }

        public virtual void Stop()
        {
            Console.WriteLine("Visualization stop");
        }

        public virtual void OpenCloseLoop(bool closed)
        {
            Console.WriteLine("Visualization mode: " + closed);
        }

        public virtual void Reset()
        {
            Console.WriteLine("Visualization reset");
        }

        public virtual void Update(double[] data, int iteration)
        {
            Console.WriteLine("Visualization update");
        }
    }
}
