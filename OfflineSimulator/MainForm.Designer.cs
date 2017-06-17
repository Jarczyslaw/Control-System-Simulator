namespace OfflineSimulator
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.tbSimulationState = new System.Windows.Forms.TextBox();
            this.lbStepSize = new System.Windows.Forms.Label();
            this.tbStepSize = new System.Windows.Forms.TextBox();
            this.lbTimeHorizon = new System.Windows.Forms.Label();
            this.tbTimeHorizon = new System.Windows.Forms.TextBox();
            this.tbPointsPerSecond = new System.Windows.Forms.TextBox();
            this.lbPointPerSecond = new System.Windows.Forms.Label();
            this.cbInitialMode = new System.Windows.Forms.ComboBox();
            this.lbInitialMode = new System.Windows.Forms.Label();
            this.tbToggleTimes = new System.Windows.Forms.TextBox();
            this.lbToggleTimes = new System.Windows.Forms.Label();
            this.cbInputType = new System.Windows.Forms.ComboBox();
            this.lbInputType = new System.Windows.Forms.Label();
            this.tbStepValues = new System.Windows.Forms.TextBox();
            this.lbStepValues = new System.Windows.Forms.Label();
            this.tbStepTimes = new System.Windows.Forms.TextBox();
            this.lbStepTimes = new System.Windows.Forms.Label();
            this.tbAmplitude = new System.Windows.Forms.TextBox();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.lbAmplitude = new System.Windows.Forms.Label();
            this.lbFrequency = new System.Windows.Forms.Label();
            this.lbOffset = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSimulationState = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chbTogglerEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(673, 568);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(170, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start simulation";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(6, 48);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(170, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop simulation";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProgressBar,
            this.statusProgressLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 608);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(898, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(42, 17);
            this.statusLabel.Text = "Status:";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.AutoSize = false;
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // statusProgressLabel
            // 
            this.statusProgressLabel.Name = "statusProgressLabel";
            this.statusProgressLabel.Size = new System.Drawing.Size(35, 17);
            this.statusProgressLabel.Text = "100%";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(6, 103);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(170, 23);
            this.btnSaveToFile.TabIndex = 5;
            this.btnSaveToFile.Text = "Save data to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // tbSimulationState
            // 
            this.tbSimulationState.Location = new System.Drawing.Point(51, 77);
            this.tbSimulationState.Name = "tbSimulationState";
            this.tbSimulationState.ReadOnly = true;
            this.tbSimulationState.Size = new System.Drawing.Size(125, 20);
            this.tbSimulationState.TabIndex = 6;
            this.tbSimulationState.Text = "STOPPED";
            this.tbSimulationState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbStepSize
            // 
            this.lbStepSize.AutoSize = true;
            this.lbStepSize.Location = new System.Drawing.Point(6, 22);
            this.lbStepSize.Name = "lbStepSize";
            this.lbStepSize.Size = new System.Drawing.Size(53, 13);
            this.lbStepSize.TabIndex = 7;
            this.lbStepSize.Text = "Step size:";
            // 
            // tbStepSize
            // 
            this.tbStepSize.Location = new System.Drawing.Point(102, 19);
            this.tbStepSize.Name = "tbStepSize";
            this.tbStepSize.Size = new System.Drawing.Size(75, 20);
            this.tbStepSize.TabIndex = 8;
            this.tbStepSize.Text = "0.01";
            this.tbStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTimeHorizon
            // 
            this.lbTimeHorizon.AutoSize = true;
            this.lbTimeHorizon.Location = new System.Drawing.Point(6, 48);
            this.lbTimeHorizon.Name = "lbTimeHorizon";
            this.lbTimeHorizon.Size = new System.Drawing.Size(70, 13);
            this.lbTimeHorizon.TabIndex = 9;
            this.lbTimeHorizon.Text = "Time horizon:";
            // 
            // tbTimeHorizon
            // 
            this.tbTimeHorizon.Location = new System.Drawing.Point(102, 45);
            this.tbTimeHorizon.Name = "tbTimeHorizon";
            this.tbTimeHorizon.Size = new System.Drawing.Size(75, 20);
            this.tbTimeHorizon.TabIndex = 10;
            this.tbTimeHorizon.Text = "20";
            this.tbTimeHorizon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbPointsPerSecond
            // 
            this.tbPointsPerSecond.Location = new System.Drawing.Point(102, 71);
            this.tbPointsPerSecond.Name = "tbPointsPerSecond";
            this.tbPointsPerSecond.Size = new System.Drawing.Size(75, 20);
            this.tbPointsPerSecond.TabIndex = 11;
            this.tbPointsPerSecond.Text = "10";
            this.tbPointsPerSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbPointPerSecond
            // 
            this.lbPointPerSecond.AutoSize = true;
            this.lbPointPerSecond.Location = new System.Drawing.Point(6, 74);
            this.lbPointPerSecond.Name = "lbPointPerSecond";
            this.lbPointPerSecond.Size = new System.Drawing.Size(95, 13);
            this.lbPointPerSecond.TabIndex = 12;
            this.lbPointPerSecond.Text = "Points per second:";
            // 
            // cbInitialMode
            // 
            this.cbInitialMode.DisplayMember = "Key";
            this.cbInitialMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInitialMode.FormattingEnabled = true;
            this.cbInitialMode.Location = new System.Drawing.Point(102, 19);
            this.cbInitialMode.Name = "cbInitialMode";
            this.cbInitialMode.Size = new System.Drawing.Size(75, 21);
            this.cbInitialMode.TabIndex = 13;
            this.cbInitialMode.ValueMember = "Value";
            // 
            // lbInitialMode
            // 
            this.lbInitialMode.AutoSize = true;
            this.lbInitialMode.Location = new System.Drawing.Point(6, 22);
            this.lbInitialMode.Name = "lbInitialMode";
            this.lbInitialMode.Size = new System.Drawing.Size(63, 13);
            this.lbInitialMode.TabIndex = 14;
            this.lbInitialMode.Text = "Initial mode:";
            // 
            // tbToggleTimes
            // 
            this.tbToggleTimes.Location = new System.Drawing.Point(101, 69);
            this.tbToggleTimes.Name = "tbToggleTimes";
            this.tbToggleTimes.Size = new System.Drawing.Size(75, 20);
            this.tbToggleTimes.TabIndex = 15;
            this.tbToggleTimes.Text = "10";
            this.tbToggleTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbToggleTimes
            // 
            this.lbToggleTimes.AutoSize = true;
            this.lbToggleTimes.Location = new System.Drawing.Point(6, 72);
            this.lbToggleTimes.Name = "lbToggleTimes";
            this.lbToggleTimes.Size = new System.Drawing.Size(70, 13);
            this.lbToggleTimes.TabIndex = 16;
            this.lbToggleTimes.Text = "Toggle times:";
            // 
            // cbInputType
            // 
            this.cbInputType.DisplayMember = "Key";
            this.cbInputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputType.FormattingEnabled = true;
            this.cbInputType.Location = new System.Drawing.Point(102, 19);
            this.cbInputType.Name = "cbInputType";
            this.cbInputType.Size = new System.Drawing.Size(74, 21);
            this.cbInputType.TabIndex = 17;
            this.cbInputType.ValueMember = "Value";
            // 
            // lbInputType
            // 
            this.lbInputType.AutoSize = true;
            this.lbInputType.Location = new System.Drawing.Point(6, 22);
            this.lbInputType.Name = "lbInputType";
            this.lbInputType.Size = new System.Drawing.Size(57, 13);
            this.lbInputType.TabIndex = 18;
            this.lbInputType.Text = "Input type:";
            // 
            // tbStepValues
            // 
            this.tbStepValues.Location = new System.Drawing.Point(91, 19);
            this.tbStepValues.Name = "tbStepValues";
            this.tbStepValues.Size = new System.Drawing.Size(74, 20);
            this.tbStepValues.TabIndex = 19;
            this.tbStepValues.Text = "1, 2";
            this.tbStepValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbStepValues
            // 
            this.lbStepValues.AutoSize = true;
            this.lbStepValues.Location = new System.Drawing.Point(6, 22);
            this.lbStepValues.Name = "lbStepValues";
            this.lbStepValues.Size = new System.Drawing.Size(66, 13);
            this.lbStepValues.TabIndex = 20;
            this.lbStepValues.Text = "Step values:";
            // 
            // tbStepTimes
            // 
            this.tbStepTimes.Location = new System.Drawing.Point(91, 45);
            this.tbStepTimes.Name = "tbStepTimes";
            this.tbStepTimes.Size = new System.Drawing.Size(74, 20);
            this.tbStepTimes.TabIndex = 21;
            this.tbStepTimes.Text = "5, 10";
            this.tbStepTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbStepTimes
            // 
            this.lbStepTimes.AutoSize = true;
            this.lbStepTimes.Location = new System.Drawing.Point(6, 48);
            this.lbStepTimes.Name = "lbStepTimes";
            this.lbStepTimes.Size = new System.Drawing.Size(59, 13);
            this.lbStepTimes.TabIndex = 22;
            this.lbStepTimes.Text = "Step times:";
            // 
            // tbAmplitude
            // 
            this.tbAmplitude.Location = new System.Drawing.Point(91, 19);
            this.tbAmplitude.Name = "tbAmplitude";
            this.tbAmplitude.Size = new System.Drawing.Size(74, 20);
            this.tbAmplitude.TabIndex = 23;
            this.tbAmplitude.Text = "1";
            this.tbAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(91, 45);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(74, 20);
            this.tbFrequency.TabIndex = 24;
            this.tbFrequency.Text = "0.2";
            this.tbFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(91, 71);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(74, 20);
            this.tbOffset.TabIndex = 25;
            this.tbOffset.Text = "0";
            this.tbOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbAmplitude
            // 
            this.lbAmplitude.AutoSize = true;
            this.lbAmplitude.Location = new System.Drawing.Point(6, 22);
            this.lbAmplitude.Name = "lbAmplitude";
            this.lbAmplitude.Size = new System.Drawing.Size(56, 13);
            this.lbAmplitude.TabIndex = 26;
            this.lbAmplitude.Text = "Amplitude:";
            // 
            // lbFrequency
            // 
            this.lbFrequency.AutoSize = true;
            this.lbFrequency.Location = new System.Drawing.Point(6, 48);
            this.lbFrequency.Name = "lbFrequency";
            this.lbFrequency.Size = new System.Drawing.Size(60, 13);
            this.lbFrequency.TabIndex = 27;
            this.lbFrequency.Text = "Frequency:";
            // 
            // lbOffset
            // 
            this.lbOffset.AutoSize = true;
            this.lbOffset.Location = new System.Drawing.Point(6, 74);
            this.lbOffset.Name = "lbOffset";
            this.lbOffset.Size = new System.Drawing.Size(38, 13);
            this.lbOffset.TabIndex = 28;
            this.lbOffset.Text = "Offset:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbStepSize);
            this.groupBox1.Controls.Add(this.lbStepSize);
            this.groupBox1.Controls.Add(this.lbTimeHorizon);
            this.groupBox1.Controls.Add(this.tbTimeHorizon);
            this.groupBox1.Controls.Add(this.tbPointsPerSecond);
            this.groupBox1.Controls.Add(this.lbPointPerSecond);
            this.groupBox1.Location = new System.Drawing.Point(12, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 97);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSimulationState);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.tbSimulationState);
            this.groupBox2.Controls.Add(this.btnSaveToFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 133);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // lbSimulationState
            // 
            this.lbSimulationState.AutoSize = true;
            this.lbSimulationState.Location = new System.Drawing.Point(10, 80);
            this.lbSimulationState.Name = "lbSimulationState";
            this.lbSimulationState.Size = new System.Drawing.Size(35, 13);
            this.lbSimulationState.TabIndex = 13;
            this.lbSimulationState.Text = "State:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbTogglerEnabled);
            this.groupBox3.Controls.Add(this.cbInitialMode);
            this.groupBox3.Controls.Add(this.lbInitialMode);
            this.groupBox3.Controls.Add(this.tbToggleTimes);
            this.groupBox3.Controls.Add(this.lbToggleTimes);
            this.groupBox3.Location = new System.Drawing.Point(12, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 96);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control system mode";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.cbInputType);
            this.groupBox6.Controls.Add(this.lbInputType);
            this.groupBox6.Location = new System.Drawing.Point(12, 356);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(183, 249);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input settings";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbAmplitude);
            this.groupBox8.Controls.Add(this.lbAmplitude);
            this.groupBox8.Controls.Add(this.tbFrequency);
            this.groupBox8.Controls.Add(this.tbOffset);
            this.groupBox8.Controls.Add(this.lbFrequency);
            this.groupBox8.Controls.Add(this.lbOffset);
            this.groupBox8.Location = new System.Drawing.Point(6, 124);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(171, 98);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Waves parameters";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbStepValues);
            this.groupBox7.Controls.Add(this.tbStepTimes);
            this.groupBox7.Controls.Add(this.lbStepValues);
            this.groupBox7.Controls.Add(this.lbStepTimes);
            this.groupBox7.Location = new System.Drawing.Point(6, 46);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(171, 72);
            this.groupBox7.TabIndex = 19;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Step parameters";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Location = new System.Drawing.Point(201, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(685, 593);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Results";
            // 
            // chbTogglerEnabled
            // 
            this.chbTogglerEnabled.AutoSize = true;
            this.chbTogglerEnabled.Location = new System.Drawing.Point(6, 46);
            this.chbTogglerEnabled.Name = "chbTogglerEnabled";
            this.chbTogglerEnabled.Size = new System.Drawing.Size(134, 17);
            this.chbTogglerEnabled.TabIndex = 17;
            this.chbTogglerEnabled.Text = "Mode toggling enabled";
            this.chbTogglerEnabled.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 630);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "JTControlSystem - Offline Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusProgressLabel;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.TextBox tbSimulationState;
        private System.Windows.Forms.Label lbStepSize;
        private System.Windows.Forms.TextBox tbStepSize;
        private System.Windows.Forms.Label lbTimeHorizon;
        private System.Windows.Forms.TextBox tbTimeHorizon;
        private System.Windows.Forms.TextBox tbPointsPerSecond;
        private System.Windows.Forms.Label lbPointPerSecond;
        private System.Windows.Forms.ComboBox cbInitialMode;
        private System.Windows.Forms.Label lbInitialMode;
        private System.Windows.Forms.TextBox tbToggleTimes;
        private System.Windows.Forms.Label lbToggleTimes;
        private System.Windows.Forms.ComboBox cbInputType;
        private System.Windows.Forms.Label lbInputType;
        private System.Windows.Forms.TextBox tbStepValues;
        private System.Windows.Forms.Label lbStepValues;
        private System.Windows.Forms.TextBox tbStepTimes;
        private System.Windows.Forms.Label lbStepTimes;
        private System.Windows.Forms.TextBox tbAmplitude;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.Label lbAmplitude;
        private System.Windows.Forms.Label lbFrequency;
        private System.Windows.Forms.Label lbOffset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbSimulationState;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chbTogglerEnabled;
    }
}

