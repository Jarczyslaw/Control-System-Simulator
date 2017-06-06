namespace JTControlSystem.Examples
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbSignals = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbContinousModels = new System.Windows.Forms.ComboBox();
            this.gbExamples = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gbExamples.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Format = "{0.0}";
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.Title = "Time [s]";
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.Title = "Value";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 16);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(754, 466);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // cbSignals
            // 
            this.cbSignals.FormattingEnabled = true;
            this.cbSignals.Location = new System.Drawing.Point(56, 19);
            this.cbSignals.Name = "cbSignals";
            this.cbSignals.Size = new System.Drawing.Size(121, 21);
            this.cbSignals.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Signals:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Continous models:";
            // 
            // cbContinousModels
            // 
            this.cbContinousModels.FormattingEnabled = true;
            this.cbContinousModels.Location = new System.Drawing.Point(282, 19);
            this.cbContinousModels.Name = "cbContinousModels";
            this.cbContinousModels.Size = new System.Drawing.Size(121, 21);
            this.cbContinousModels.TabIndex = 5;
            // 
            // gbExamples
            // 
            this.gbExamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExamples.Controls.Add(this.cbSignals);
            this.gbExamples.Controls.Add(this.cbContinousModels);
            this.gbExamples.Controls.Add(this.label1);
            this.gbExamples.Controls.Add(this.label2);
            this.gbExamples.Location = new System.Drawing.Point(12, 12);
            this.gbExamples.Name = "gbExamples";
            this.gbExamples.Size = new System.Drawing.Size(760, 47);
            this.gbExamples.TabIndex = 6;
            this.gbExamples.TabStop = false;
            this.gbExamples.Text = "Examples";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 485);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbExamples);
            this.Name = "MainForm";
            this.Text = "JTControlSystem Examples";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gbExamples.ResumeLayout(false);
            this.gbExamples.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cbSignals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbContinousModels;
        private System.Windows.Forms.GroupBox gbExamples;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

