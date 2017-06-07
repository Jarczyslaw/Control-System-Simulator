using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace JTControlSystem.Examples
{
    public partial class MainForm : Form
    {
        private Series serie;

        public MainForm()
        {
            InitializeComponent();
            PopulateComboBoxes();
            InitComboBoxes();
            InitSerie();
        }

        private void PopulateComboBoxes()
        {
            Dictionary<string, IExample> generators = new Dictionary<string, IExample>();
            generators.Add("Steps", new StepsGeneratorExample());
            generators.Add("Saw", new SawGeneratorExample());
            generators.Add("Sine", new SineGeneratorExample());
            generators.Add("Square", new SquareGeneratorExample());
            generators.Add("Triangle", new TriangleGeneratorExample());
            cbSignals.DataSource = new BindingSource(generators, null);

            Dictionary<string, IExample> continousModels = new Dictionary<string, IExample>();
            continousModels.Add("FirstOrder", new ContinousFirstOrderExample());
            cbContinousModels.DataSource = new BindingSource(continousModels, null);

            Dictionary<string, IExample> loops = new Dictionary<string, IExample>();
            loops.Add("BareSystem", new BareSystemExample());
            loops.Add("OpenLoop", new OpenLoopExample());
            loops.Add("CloseLoop", new CloseLoopExample());
            loops.Add("ControlSystem", new ControlSystemExample());
            cbLoops.DataSource = new BindingSource(loops, null);
        }

        private void InitSerie()
        {
            serie = new Series();
            serie.ChartType = SeriesChartType.Line;
            serie.BorderWidth = 3;
            chart1.Series.Add(serie);
        }

        private void InitComboBoxes()
        {
            foreach(Control control in gbExamples.Controls)
            {
                if (control is ComboBox)
                {
                    var comboBox = control as ComboBox;
                    comboBox.ValueMember = "Value";
                    comboBox.DisplayMember = "Key";
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.SelectedIndex = -1;
                    comboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;
                }
            }
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var combobox = (sender as ComboBox);
            var selectedExample = combobox.SelectedValue as IExample;
            selectedExample.Run();

            var time = selectedExample.GetTime();
            var values = selectedExample.GetValues();
            LoadToChart(time, values);
            LoadToGrid(time, values);
        }

        private void LoadToChart(double[] time, double[] values)
        {
            serie.Points.Clear();
            for (int i = 0; i < time.Length; i++)
            {
                var point = new DataPoint(time[i], values[i]);
                serie.Points.Add(point);
            }
        }

        private void LoadToGrid(double[] time, double[] values)
        {
            var samples = new List<DataSample>();
            for (int i = 0;i < time.Length;i++)
            {
                samples.Add(new DataSample()
                {
                    time = time[i],
                    value = values[i]
                });
            }
            dgvData.DataSource = samples;
        }
    }
}
