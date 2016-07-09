﻿namespace RealtimeSimulator
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
            this.outputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.closeLoopButton = new System.Windows.Forms.Button();
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
            this.openLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.setValueTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.stepsSetButton = new System.Windows.Forms.Button();
            this.stepsCurrentValuesTextBox = new System.Windows.Forms.TextBox();
            this.stepsValues = new System.Windows.Forms.TextBox();
            this.stepsCurrentTimesTextBox = new System.Windows.Forms.TextBox();
            this.stepsTimes = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.waveCurrentOffsetTextBox = new System.Windows.Forms.TextBox();
            this.waveCurrentAmplitudeTextBox = new System.Windows.Forms.TextBox();
            this.waveCurrentFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.waveFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.waveSetButton = new System.Windows.Forms.Button();
            this.waveAmplitudeTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.waveOffsetTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inputSetTextBox = new System.Windows.Forms.TextBox();
            this.inputTypeComboBox = new System.Windows.Forms.ComboBox();
            this.setValueTrackBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inputTrackBar = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixedSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setValueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTrackBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputChart
            // 
            this.outputChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.outputChart.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.outputChart.Legends.Add(legend3);
            this.outputChart.Location = new System.Drawing.Point(3, 3);
            this.outputChart.Name = "outputChart";
            this.outputChart.Size = new System.Drawing.Size(704, 282);
            this.outputChart.TabIndex = 2;
            this.outputChart.Text = "chart1";
            // 
            // inputChart
            // 
            this.inputChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.inputChart.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Name = "Legend1";
            this.inputChart.Legends.Add(legend4);
            this.inputChart.Location = new System.Drawing.Point(3, 291);
            this.inputChart.Name = "inputChart";
            this.inputChart.Size = new System.Drawing.Size(704, 283);
            this.inputChart.TabIndex = 3;
            this.inputChart.Text = "regulatorChart";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(235, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 602);
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
            this.tableLayoutPanel1.Controls.Add(this.outputChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputChart, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 40);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // closeLoopButton
            // 
            this.closeLoopButton.Location = new System.Drawing.Point(6, 65);
            this.closeLoopButton.Name = "closeLoopButton";
            this.closeLoopButton.Size = new System.Drawing.Size(100, 40);
            this.closeLoopButton.TabIndex = 7;
            this.closeLoopButton.Text = "Close loop";
            this.closeLoopButton.UseVisualStyleBackColor = true;
            this.closeLoopButton.Click += new System.EventHandler(this.closeLoopButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(6, 111);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(206, 40);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // iterationTextBox
            // 
            this.iterationTextBox.Location = new System.Drawing.Point(66, 19);
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
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Iteration:";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(191, 19);
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
            this.label2.Location = new System.Drawing.Point(152, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Time:";
            // 
            // controlValueTextBox
            // 
            this.controlValueTextBox.Location = new System.Drawing.Point(636, 19);
            this.controlValueTextBox.Name = "controlValueTextBox";
            this.controlValueTextBox.ReadOnly = true;
            this.controlValueTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.controlValueTextBox.Size = new System.Drawing.Size(80, 20);
            this.controlValueTextBox.TabIndex = 15;
            this.controlValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(325, 19);
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
            this.label4.Location = new System.Drawing.Point(558, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Control value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Output:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.openLabel);
            this.groupBox2.Controls.Add(this.startLabel);
            this.groupBox2.Controls.Add(this.startButton);
            this.groupBox2.Controls.Add(this.closeLoopButton);
            this.groupBox2.Controls.Add(this.resetButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 157);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // openLabel
            // 
            this.openLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openLabel.Location = new System.Drawing.Point(112, 65);
            this.openLabel.Name = "openLabel";
            this.openLabel.Size = new System.Drawing.Size(100, 40);
            this.openLabel.TabIndex = 11;
            this.openLabel.Text = "OFF";
            this.openLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLabel
            // 
            this.startLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startLabel.Location = new System.Drawing.Point(112, 19);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(100, 40);
            this.startLabel.TabIndex = 10;
            this.startLabel.Text = "STOPPED";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox3.Location = new System.Drawing.Point(235, 635);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(722, 45);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Set value:";
            // 
            // setValueTextBox
            // 
            this.setValueTextBox.Location = new System.Drawing.Point(472, 19);
            this.setValueTextBox.Name = "setValueTextBox";
            this.setValueTextBox.ReadOnly = true;
            this.setValueTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.setValueTextBox.Size = new System.Drawing.Size(80, 20);
            this.setValueTextBox.TabIndex = 14;
            this.setValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.inputSetTextBox);
            this.groupBox4.Controls.Add(this.inputTypeComboBox);
            this.groupBox4.Controls.Add(this.setValueTrackBar);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.inputTextBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.inputTrackBar);
            this.groupBox4.Location = new System.Drawing.Point(12, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(217, 489);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.stepsSetButton);
            this.groupBox6.Controls.Add(this.stepsCurrentValuesTextBox);
            this.groupBox6.Controls.Add(this.stepsValues);
            this.groupBox6.Controls.Add(this.stepsCurrentTimesTextBox);
            this.groupBox6.Controls.Add(this.stepsTimes);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(6, 333);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(205, 151);
            this.groupBox6.TabIndex = 37;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Steps generator";
            // 
            // stepsSetButton
            // 
            this.stepsSetButton.Location = new System.Drawing.Point(6, 123);
            this.stepsSetButton.Name = "stepsSetButton";
            this.stepsSetButton.Size = new System.Drawing.Size(193, 23);
            this.stepsSetButton.TabIndex = 39;
            this.stepsSetButton.Text = "Set steps parameters";
            this.stepsSetButton.UseVisualStyleBackColor = true;
            this.stepsSetButton.Click += new System.EventHandler(this.stepsSetButton_Click);
            // 
            // stepsCurrentValuesTextBox
            // 
            this.stepsCurrentValuesTextBox.Location = new System.Drawing.Point(73, 97);
            this.stepsCurrentValuesTextBox.Name = "stepsCurrentValuesTextBox";
            this.stepsCurrentValuesTextBox.ReadOnly = true;
            this.stepsCurrentValuesTextBox.Size = new System.Drawing.Size(126, 20);
            this.stepsCurrentValuesTextBox.TabIndex = 42;
            this.stepsCurrentValuesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stepsValues
            // 
            this.stepsValues.Location = new System.Drawing.Point(73, 71);
            this.stepsValues.Name = "stepsValues";
            this.stepsValues.Size = new System.Drawing.Size(126, 20);
            this.stepsValues.TabIndex = 41;
            this.stepsValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stepsCurrentTimesTextBox
            // 
            this.stepsCurrentTimesTextBox.Location = new System.Drawing.Point(73, 45);
            this.stepsCurrentTimesTextBox.Name = "stepsCurrentTimesTextBox";
            this.stepsCurrentTimesTextBox.ReadOnly = true;
            this.stepsCurrentTimesTextBox.Size = new System.Drawing.Size(126, 20);
            this.stepsCurrentTimesTextBox.TabIndex = 40;
            this.stepsCurrentTimesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stepsTimes
            // 
            this.stepsTimes.Location = new System.Drawing.Point(73, 19);
            this.stepsTimes.Name = "stepsTimes";
            this.stepsTimes.Size = new System.Drawing.Size(126, 20);
            this.stepsTimes.TabIndex = 39;
            this.stepsTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Values:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Times:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.waveCurrentOffsetTextBox);
            this.groupBox5.Controls.Add(this.waveCurrentAmplitudeTextBox);
            this.groupBox5.Controls.Add(this.waveCurrentFrequencyTextBox);
            this.groupBox5.Controls.Add(this.waveFrequencyTextBox);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.waveSetButton);
            this.groupBox5.Controls.Add(this.waveAmplitudeTextBox);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.waveOffsetTextBox);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(6, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 127);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Wave generator";
            // 
            // waveCurrentOffsetTextBox
            // 
            this.waveCurrentOffsetTextBox.Location = new System.Drawing.Point(139, 71);
            this.waveCurrentOffsetTextBox.Name = "waveCurrentOffsetTextBox";
            this.waveCurrentOffsetTextBox.ReadOnly = true;
            this.waveCurrentOffsetTextBox.Size = new System.Drawing.Size(60, 20);
            this.waveCurrentOffsetTextBox.TabIndex = 38;
            this.waveCurrentOffsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waveCurrentAmplitudeTextBox
            // 
            this.waveCurrentAmplitudeTextBox.Location = new System.Drawing.Point(139, 45);
            this.waveCurrentAmplitudeTextBox.Name = "waveCurrentAmplitudeTextBox";
            this.waveCurrentAmplitudeTextBox.ReadOnly = true;
            this.waveCurrentAmplitudeTextBox.Size = new System.Drawing.Size(60, 20);
            this.waveCurrentAmplitudeTextBox.TabIndex = 37;
            this.waveCurrentAmplitudeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waveCurrentFrequencyTextBox
            // 
            this.waveCurrentFrequencyTextBox.Location = new System.Drawing.Point(139, 19);
            this.waveCurrentFrequencyTextBox.Name = "waveCurrentFrequencyTextBox";
            this.waveCurrentFrequencyTextBox.ReadOnly = true;
            this.waveCurrentFrequencyTextBox.Size = new System.Drawing.Size(60, 20);
            this.waveCurrentFrequencyTextBox.TabIndex = 36;
            this.waveCurrentFrequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // waveFrequencyTextBox
            // 
            this.waveFrequencyTextBox.Location = new System.Drawing.Point(73, 19);
            this.waveFrequencyTextBox.Name = "waveFrequencyTextBox";
            this.waveFrequencyTextBox.Size = new System.Drawing.Size(60, 20);
            this.waveFrequencyTextBox.TabIndex = 31;
            this.waveFrequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Offset:";
            // 
            // waveSetButton
            // 
            this.waveSetButton.Location = new System.Drawing.Point(6, 97);
            this.waveSetButton.Name = "waveSetButton";
            this.waveSetButton.Size = new System.Drawing.Size(193, 23);
            this.waveSetButton.TabIndex = 14;
            this.waveSetButton.Text = "Set waves parameters";
            this.waveSetButton.UseVisualStyleBackColor = true;
            this.waveSetButton.Click += new System.EventHandler(this.waveSetButton_Click);
            // 
            // waveAmplitudeTextBox
            // 
            this.waveAmplitudeTextBox.Location = new System.Drawing.Point(73, 45);
            this.waveAmplitudeTextBox.Name = "waveAmplitudeTextBox";
            this.waveAmplitudeTextBox.Size = new System.Drawing.Size(60, 20);
            this.waveAmplitudeTextBox.TabIndex = 30;
            this.waveAmplitudeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Amplitude:";
            // 
            // waveOffsetTextBox
            // 
            this.waveOffsetTextBox.Location = new System.Drawing.Point(73, 71);
            this.waveOffsetTextBox.Name = "waveOffsetTextBox";
            this.waveOffsetTextBox.Size = new System.Drawing.Size(60, 20);
            this.waveOffsetTextBox.TabIndex = 32;
            this.waveOffsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Frequency:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 22);
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
            this.inputTypeComboBox.Location = new System.Drawing.Point(132, 19);
            this.inputTypeComboBox.Name = "inputTypeComboBox";
            this.inputTypeComboBox.Size = new System.Drawing.Size(80, 21);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulationToolStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.visualizationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.fixedSimulationToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // fixedSimulationToolStripMenuItem
            // 
            this.fixedSimulationToolStripMenuItem.Name = "fixedSimulationToolStripMenuItem";
            this.fixedSimulationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fixedSimulationToolStripMenuItem.Text = "Fixed simulation";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.saveToFileToolStripMenuItem.Text = "Save to file";
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.visualizationToolStripMenuItem.Text = "Visualization";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 692);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "JTSim - real-time simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.Shown += new System.EventHandler(this.ControlPanel_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlPanel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.outputChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setValueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputTrackBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart outputChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart inputChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button closeLoopButton;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox setValueTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button stepsSetButton;
        private System.Windows.Forms.TextBox stepsCurrentValuesTextBox;
        private System.Windows.Forms.TextBox stepsValues;
        private System.Windows.Forms.TextBox stepsCurrentTimesTextBox;
        private System.Windows.Forms.TextBox stepsTimes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox waveCurrentOffsetTextBox;
        private System.Windows.Forms.TextBox waveCurrentAmplitudeTextBox;
        private System.Windows.Forms.TextBox waveCurrentFrequencyTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixedSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.Label openLabel;
        private System.Windows.Forms.Label startLabel;
    }
}
