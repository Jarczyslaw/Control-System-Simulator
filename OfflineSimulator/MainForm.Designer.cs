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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.outputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.percentageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stepSizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timeHorizonTextBox = new System.Windows.Forms.TextBox();
            this.pointsPerSecondTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stepsRadioButton = new System.Windows.Forms.RadioButton();
            this.wavesRadioButton = new System.Windows.Forms.RadioButton();
            this.wavesComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.amplitudeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.offsetTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stepsTimesTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stepsValuesTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.inputChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.outputChart, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 584);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputChart
            // 
            this.inputChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.Name = "ChartArea1";
            this.inputChart.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.inputChart.Legends.Add(legend3);
            this.inputChart.Location = new System.Drawing.Point(3, 295);
            this.inputChart.Name = "inputChart";
            this.inputChart.Size = new System.Drawing.Size(1051, 286);
            this.inputChart.TabIndex = 1;
            this.inputChart.Text = "chart1";
            // 
            // outputChart
            // 
            this.outputChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.CursorY.IsUserEnabled = true;
            chartArea4.CursorY.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartArea1";
            this.outputChart.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Name = "Legend1";
            this.outputChart.Legends.Add(legend4);
            this.outputChart.Location = new System.Drawing.Point(3, 3);
            this.outputChart.Name = "outputChart";
            this.outputChart.Size = new System.Drawing.Size(1051, 286);
            this.outputChart.TabIndex = 0;
            this.outputChart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1069, 609);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveToFileButton);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Location = new System.Drawing.Point(6, 48);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(205, 23);
            this.saveToFileButton.TabIndex = 6;
            this.saveToFileButton.Text = "Save to file";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(112, 19);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStatusLabel,
            this.progressProgressBar,
            this.percentageStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(1096, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStatusLabel
            // 
            this.statusStatusLabel.Name = "statusStatusLabel";
            this.statusStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.statusStatusLabel.Text = "Status:";
            // 
            // progressProgressBar
            // 
            this.progressProgressBar.Name = "progressProgressBar";
            this.progressProgressBar.Size = new System.Drawing.Size(1000, 16);
            // 
            // percentageStatusLabel
            // 
            this.percentageStatusLabel.Name = "percentageStatusLabel";
            this.percentageStatusLabel.Size = new System.Drawing.Size(35, 17);
            this.percentageStatusLabel.Text = "100%";
            // 
            // stepSizeTextBox
            // 
            this.stepSizeTextBox.Location = new System.Drawing.Point(66, 46);
            this.stepSizeTextBox.Name = "stepSizeTextBox";
            this.stepSizeTextBox.Size = new System.Drawing.Size(60, 20);
            this.stepSizeTextBox.TabIndex = 2;
            this.stepSizeTextBox.Text = "0.01";
            this.stepSizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time horizon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Step size:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.modeComboBox);
            this.groupBox3.Controls.Add(this.timeHorizonTextBox);
            this.groupBox3.Controls.Add(this.pointsPerSecondTextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.stepSizeTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(235, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 77);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            // 
            // timeHorizonTextBox
            // 
            this.timeHorizonTextBox.Location = new System.Drawing.Point(229, 20);
            this.timeHorizonTextBox.Name = "timeHorizonTextBox";
            this.timeHorizonTextBox.Size = new System.Drawing.Size(50, 20);
            this.timeHorizonTextBox.TabIndex = 8;
            this.timeHorizonTextBox.Text = "20";
            this.timeHorizonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pointsPerSecondTextBox
            // 
            this.pointsPerSecondTextBox.Location = new System.Drawing.Point(229, 46);
            this.pointsPerSecondTextBox.Name = "pointsPerSecondTextBox";
            this.pointsPerSecondTextBox.Size = new System.Drawing.Size(50, 20);
            this.pointsPerSecondTextBox.TabIndex = 7;
            this.pointsPerSecondTextBox.Text = "10";
            this.pointsPerSecondTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Points per second:";
            // 
            // stepsRadioButton
            // 
            this.stepsRadioButton.AutoSize = true;
            this.stepsRadioButton.Checked = true;
            this.stepsRadioButton.Location = new System.Drawing.Point(6, 20);
            this.stepsRadioButton.Name = "stepsRadioButton";
            this.stepsRadioButton.Size = new System.Drawing.Size(52, 17);
            this.stepsRadioButton.TabIndex = 8;
            this.stepsRadioButton.TabStop = true;
            this.stepsRadioButton.Text = "Steps";
            this.stepsRadioButton.UseVisualStyleBackColor = true;
            // 
            // wavesRadioButton
            // 
            this.wavesRadioButton.AutoSize = true;
            this.wavesRadioButton.Location = new System.Drawing.Point(6, 46);
            this.wavesRadioButton.Name = "wavesRadioButton";
            this.wavesRadioButton.Size = new System.Drawing.Size(59, 17);
            this.wavesRadioButton.TabIndex = 9;
            this.wavesRadioButton.Text = "Waves";
            this.wavesRadioButton.UseVisualStyleBackColor = true;
            // 
            // wavesComboBox
            // 
            this.wavesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wavesComboBox.FormattingEnabled = true;
            this.wavesComboBox.Items.AddRange(new object[] {
            "Sine",
            "Square",
            "Triangle",
            "Saw"});
            this.wavesComboBox.Location = new System.Drawing.Point(129, 45);
            this.wavesComboBox.Name = "wavesComboBox";
            this.wavesComboBox.Size = new System.Drawing.Size(100, 21);
            this.wavesComboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Amplitude:";
            // 
            // amplitudeTextBox
            // 
            this.amplitudeTextBox.Location = new System.Drawing.Point(307, 45);
            this.amplitudeTextBox.Name = "amplitudeTextBox";
            this.amplitudeTextBox.Size = new System.Drawing.Size(40, 20);
            this.amplitudeTextBox.TabIndex = 12;
            this.amplitudeTextBox.Text = "1";
            this.amplitudeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Frequency:";
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Location = new System.Drawing.Point(419, 45);
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.Size = new System.Drawing.Size(40, 20);
            this.frequencyTextBox.TabIndex = 14;
            this.frequencyTextBox.Text = "0.5";
            this.frequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Offset:";
            // 
            // offsetTextBox
            // 
            this.offsetTextBox.Location = new System.Drawing.Point(509, 45);
            this.offsetTextBox.Name = "offsetTextBox";
            this.offsetTextBox.Size = new System.Drawing.Size(40, 20);
            this.offsetTextBox.TabIndex = 16;
            this.offsetTextBox.Text = "0";
            this.offsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Step times:";
            // 
            // stepsTimesTextBox
            // 
            this.stepsTimesTextBox.Location = new System.Drawing.Point(129, 19);
            this.stepsTimesTextBox.Name = "stepsTimesTextBox";
            this.stepsTimesTextBox.Size = new System.Drawing.Size(100, 20);
            this.stepsTimesTextBox.TabIndex = 18;
            this.stepsTimesTextBox.Text = "5,10";
            this.stepsTimesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Step values:";
            // 
            // stepsValuesTextBox
            // 
            this.stepsValuesTextBox.Location = new System.Drawing.Point(307, 20);
            this.stepsValuesTextBox.Name = "stepsValuesTextBox";
            this.stepsValuesTextBox.Size = new System.Drawing.Size(100, 20);
            this.stepsValuesTextBox.TabIndex = 20;
            this.stepsValuesTextBox.Text = "1,2";
            this.stepsValuesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.offsetTextBox);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.stepsValuesTextBox);
            this.groupBox5.Controls.Add(this.frequencyTextBox);
            this.groupBox5.Controls.Add(this.stepsRadioButton);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.amplitudeTextBox);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.stepsTimesTextBox);
            this.groupBox5.Controls.Add(this.wavesRadioButton);
            this.groupBox5.Controls.Add(this.wavesComboBox);
            this.groupBox5.Location = new System.Drawing.Point(527, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(554, 76);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Type:";
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            "Open",
            "Close"});
            this.modeComboBox.Location = new System.Drawing.Point(66, 21);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(60, 21);
            this.modeComboBox.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Mode:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 729);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "JTSim - Offline simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart outputChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart inputChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel percentageStatusLabel;
        private System.Windows.Forms.TextBox stepSizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox pointsPerSecondTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton wavesRadioButton;
        private System.Windows.Forms.RadioButton stepsRadioButton;
        private System.Windows.Forms.ComboBox wavesComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amplitudeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox frequencyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox offsetTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox stepsTimesTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox stepsValuesTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox timeHorizonTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox modeComboBox;
    }
}

