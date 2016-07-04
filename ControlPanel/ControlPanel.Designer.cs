namespace ControlPanel
{
    partial class ControlPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.outputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.controlChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startButton = new System.Windows.Forms.Button();
            this.startTextBox = new System.Windows.Forms.TextBox();
            this.closeLoopButton = new System.Windows.Forms.Button();
            this.closeLoopTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.iterationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.controlValueTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.timeHorizonTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.setValueTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.waveSetButton = new System.Windows.Forms.Button();
            this.waveOffsetTextBox = new System.Windows.Forms.TextBox();
            this.waveFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.waveAmplitudeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.inputSetTextBox = new System.Windows.Forms.TextBox();
            this.inputTypeComboBox = new System.Windows.Forms.ComboBox();
            this.setValueTrackBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inputTrackBar = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setValueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // outputChart
            // 
            this.outputChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.outputChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.outputChart.Legends.Add(legend1);
            this.outputChart.Location = new System.Drawing.Point(3, 3);
            this.outputChart.Name = "outputChart";
            this.outputChart.Size = new System.Drawing.Size(762, 196);
            this.outputChart.TabIndex = 2;
            this.outputChart.Text = "chart1";
            // 
            // inputChart
            // 
            this.inputChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.inputChart.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.inputChart.Legends.Add(legend2);
            this.inputChart.Location = new System.Drawing.Point(3, 205);
            this.inputChart.Name = "inputChart";
            this.inputChart.Size = new System.Drawing.Size(762, 191);
            this.inputChart.TabIndex = 3;
            this.inputChart.Text = "regulatorChart";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(235, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 622);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charts";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.controlChart, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.outputChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputChart, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // controlChart
            // 
            this.controlChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.controlChart.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.controlChart.Legends.Add(legend3);
            this.controlChart.Location = new System.Drawing.Point(3, 402);
            this.controlChart.Name = "controlChart";
            this.controlChart.Size = new System.Drawing.Size(762, 192);
            this.controlChart.TabIndex = 4;
            this.controlChart.Text = "chart1";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startTextBox
            // 
            this.startTextBox.BackColor = System.Drawing.Color.OrangeRed;
            this.startTextBox.Location = new System.Drawing.Point(112, 21);
            this.startTextBox.Name = "startTextBox";
            this.startTextBox.ReadOnly = true;
            this.startTextBox.Size = new System.Drawing.Size(100, 20);
            this.startTextBox.TabIndex = 6;
            this.startTextBox.Text = "STOPPED";
            this.startTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // closeLoopButton
            // 
            this.closeLoopButton.Location = new System.Drawing.Point(6, 48);
            this.closeLoopButton.Name = "closeLoopButton";
            this.closeLoopButton.Size = new System.Drawing.Size(100, 23);
            this.closeLoopButton.TabIndex = 7;
            this.closeLoopButton.Text = "Close loop";
            this.closeLoopButton.UseVisualStyleBackColor = true;
            this.closeLoopButton.Click += new System.EventHandler(this.closeLoopButton_Click);
            // 
            // closeLoopTextBox
            // 
            this.closeLoopTextBox.BackColor = System.Drawing.Color.OrangeRed;
            this.closeLoopTextBox.Location = new System.Drawing.Point(112, 50);
            this.closeLoopTextBox.Name = "closeLoopTextBox";
            this.closeLoopTextBox.ReadOnly = true;
            this.closeLoopTextBox.Size = new System.Drawing.Size(100, 20);
            this.closeLoopTextBox.TabIndex = 8;
            this.closeLoopTextBox.Text = "OFF";
            this.closeLoopTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(6, 76);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(206, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // iterationTextBox
            // 
            this.iterationTextBox.Location = new System.Drawing.Point(132, 19);
            this.iterationTextBox.Name = "iterationTextBox";
            this.iterationTextBox.ReadOnly = true;
            this.iterationTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iterationTextBox.Size = new System.Drawing.Size(80, 20);
            this.iterationTextBox.TabIndex = 10;
            this.iterationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Iteration:";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(132, 45);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeTextBox.Size = new System.Drawing.Size(80, 20);
            this.timeTextBox.TabIndex = 12;
            this.timeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Time:";
            // 
            // controlValueTextBox
            // 
            this.controlValueTextBox.Location = new System.Drawing.Point(132, 97);
            this.controlValueTextBox.Name = "controlValueTextBox";
            this.controlValueTextBox.ReadOnly = true;
            this.controlValueTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.controlValueTextBox.Size = new System.Drawing.Size(80, 20);
            this.controlValueTextBox.TabIndex = 15;
            this.controlValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(132, 123);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.outputTextBox.Size = new System.Drawing.Size(80, 20);
            this.outputTextBox.TabIndex = 16;
            this.outputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Control value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Output:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.timeHorizonTextBox);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.startTextBox);
            this.groupBox2.Controls.Add(this.closeLoopButton);
            this.groupBox2.Controls.Add(this.closeLoopTextBox);
            this.groupBox2.Controls.Add(this.resetButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 164);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Simulate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Time horizon:";
            // 
            // timeHorizonTextBox
            // 
            this.timeHorizonTextBox.Location = new System.Drawing.Point(111, 105);
            this.timeHorizonTextBox.Name = "timeHorizonTextBox";
            this.timeHorizonTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeHorizonTextBox.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.controlValueTextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.timeTextBox);
            this.groupBox3.Controls.Add(this.setValueTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.iterationTextBox);
            this.groupBox3.Controls.Add(this.outputTextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 485);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 149);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Set value:";
            // 
            // setValueTextBox
            // 
            this.setValueTextBox.Location = new System.Drawing.Point(132, 71);
            this.setValueTextBox.Name = "setValueTextBox";
            this.setValueTextBox.ReadOnly = true;
            this.setValueTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.setValueTextBox.Size = new System.Drawing.Size(80, 20);
            this.setValueTextBox.TabIndex = 14;
            this.setValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.waveSetButton);
            this.groupBox4.Controls.Add(this.waveOffsetTextBox);
            this.groupBox4.Controls.Add(this.waveFrequencyTextBox);
            this.groupBox4.Controls.Add(this.waveAmplitudeTextBox);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.inputSetTextBox);
            this.groupBox4.Controls.Add(this.inputTypeComboBox);
            this.groupBox4.Controls.Add(this.setValueTrackBar);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.inputTextBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.inputTrackBar);
            this.groupBox4.Location = new System.Drawing.Point(12, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 297);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(88, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Offset:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Amplitude:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(66, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Frequency:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Waves parameters:";
            // 
            // waveSetButton
            // 
            this.waveSetButton.Location = new System.Drawing.Point(9, 219);
            this.waveSetButton.Name = "waveSetButton";
            this.waveSetButton.Size = new System.Drawing.Size(51, 72);
            this.waveSetButton.TabIndex = 14;
            this.waveSetButton.Text = "Set waves parameters";
            this.waveSetButton.UseVisualStyleBackColor = true;
            // 
            // waveOffsetTextBox
            // 
            this.waveOffsetTextBox.Location = new System.Drawing.Point(132, 270);
            this.waveOffsetTextBox.Name = "waveOffsetTextBox";
            this.waveOffsetTextBox.Size = new System.Drawing.Size(80, 20);
            this.waveOffsetTextBox.TabIndex = 32;
            this.waveOffsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waveFrequencyTextBox
            // 
            this.waveFrequencyTextBox.Location = new System.Drawing.Point(132, 218);
            this.waveFrequencyTextBox.Name = "waveFrequencyTextBox";
            this.waveFrequencyTextBox.Size = new System.Drawing.Size(80, 20);
            this.waveFrequencyTextBox.TabIndex = 31;
            this.waveFrequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waveAmplitudeTextBox
            // 
            this.waveAmplitudeTextBox.Location = new System.Drawing.Point(132, 244);
            this.waveAmplitudeTextBox.Name = "waveAmplitudeTextBox";
            this.waveAmplitudeTextBox.Size = new System.Drawing.Size(80, 20);
            this.waveAmplitudeTextBox.TabIndex = 30;
            this.waveAmplitudeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Input type:";
            // 
            // inputSetTextBox
            // 
            this.inputSetTextBox.Location = new System.Drawing.Point(132, 123);
            this.inputSetTextBox.Name = "inputSetTextBox";
            this.inputSetTextBox.ReadOnly = true;
            this.inputSetTextBox.Size = new System.Drawing.Size(80, 20);
            this.inputSetTextBox.TabIndex = 27;
            this.inputSetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inputTypeComboBox
            // 
            this.inputTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputTypeComboBox.FormattingEnabled = true;
            this.inputTypeComboBox.Items.AddRange(new object[] {
            "Slider",
            "Sine wave",
            "Square wave",
            "Triangle wave",
            "Saw wave"});
            this.inputTypeComboBox.Location = new System.Drawing.Point(112, 19);
            this.inputTypeComboBox.Name = "inputTypeComboBox";
            this.inputTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.inputTypeComboBox.TabIndex = 28;
            this.inputTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.inputTypeComboBox_SelectedIndexChanged);
            // 
            // setValueTrackBar
            // 
            this.setValueTrackBar.Location = new System.Drawing.Point(6, 149);
            this.setValueTrackBar.Maximum = 100;
            this.setValueTrackBar.Name = "setValueTrackBar";
            this.setValueTrackBar.Size = new System.Drawing.Size(206, 45);
            this.setValueTrackBar.TabIndex = 26;
            this.setValueTrackBar.Scroll += new System.EventHandler(this.setValueTrackBar_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Close loop - set value:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(132, 46);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ReadOnly = true;
            this.inputTextBox.Size = new System.Drawing.Size(80, 20);
            this.inputTextBox.TabIndex = 23;
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Open loop - input:";
            // 
            // inputTrackBar
            // 
            this.inputTrackBar.Location = new System.Drawing.Point(6, 72);
            this.inputTrackBar.Maximum = 100;
            this.inputTrackBar.Name = "inputTrackBar";
            this.inputTrackBar.Size = new System.Drawing.Size(206, 45);
            this.inputTrackBar.TabIndex = 23;
            this.inputTrackBar.Scroll += new System.EventHandler(this.inputTrackBar_Scroll);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(545, 653);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 694);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "ControlPanel";
            this.Text = "JTSim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.controlChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setValueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart outputChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart inputChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox startTextBox;
        private System.Windows.Forms.Button closeLoopButton;
        private System.Windows.Forms.TextBox closeLoopTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox iterationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox controlValueTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar inputTrackBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart controlChart;
        private System.Windows.Forms.TrackBar setValueTrackBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox inputTypeComboBox;
        private System.Windows.Forms.TextBox inputSetTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox waveOffsetTextBox;
        private System.Windows.Forms.TextBox waveFrequencyTextBox;
        private System.Windows.Forms.TextBox waveAmplitudeTextBox;
        private System.Windows.Forms.Button waveSetButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox setValueTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox timeHorizonTextBox;
        private System.Windows.Forms.Button button2;
    }
}

