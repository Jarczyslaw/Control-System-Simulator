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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lbStart = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbControllerOutput = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbSystemOutput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbIteration = new System.Windows.Forms.Label();
            this.tbIteration = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.tbSetOffset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetWaves = new System.Windows.Forms.Button();
            this.tbAmplitude = new System.Windows.Forms.TextBox();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.tbSetAmplitude = new System.Windows.Forms.TextBox();
            this.tbSetFrequency = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSetSteps = new System.Windows.Forms.Button();
            this.tbStepValues = new System.Windows.Forms.TextBox();
            this.tbStepTimes = new System.Windows.Forms.TextBox();
            this.tbSetStepValues = new System.Windows.Forms.TextBox();
            this.tbSetStepTimes = new System.Windows.Forms.TextBox();
            this.cbSignalType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.trbSetvalue = new System.Windows.Forms.TrackBar();
            this.tbSetpointValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbWavesGenerator = new System.Windows.Forms.RadioButton();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.lbMode = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbError = new System.Windows.Forms.TextBox();
            this.tbInputValue = new System.Windows.Forms.TextBox();
            this.trbInput = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSetvalue)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbInput)).BeginInit();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(3, 16);
            this.mainChart.Name = "mainChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mainChart.Series.Add(series1);
            this.mainChart.Size = new System.Drawing.Size(852, 643);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.lbStart);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control panel";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 55);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(206, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbStart
            // 
            this.lbStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStart.Location = new System.Drawing.Point(112, 19);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(100, 30);
            this.lbStart.TabIndex = 1;
            this.lbStart.Text = "STOPPED";
            this.lbStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.mainChart);
            this.groupBox2.Location = new System.Drawing.Point(237, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(858, 662);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charts";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbError);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.tbControllerOutput);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tbSystemOutput);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbInput);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbTime);
            this.groupBox3.Controls.Add(this.lbTime);
            this.groupBox3.Controls.Add(this.lbIteration);
            this.groupBox3.Controls.Add(this.tbIteration);
            this.groupBox3.Location = new System.Drawing.Point(237, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(858, 49);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // tbControllerOutput
            // 
            this.tbControllerOutput.Location = new System.Drawing.Point(639, 19);
            this.tbControllerOutput.Name = "tbControllerOutput";
            this.tbControllerOutput.ReadOnly = true;
            this.tbControllerOutput.Size = new System.Drawing.Size(75, 20);
            this.tbControllerOutput.TabIndex = 10;
            this.tbControllerOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(546, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Controller output:";
            // 
            // tbSystemOutput
            // 
            this.tbSystemOutput.Location = new System.Drawing.Point(465, 19);
            this.tbSystemOutput.Name = "tbSystemOutput";
            this.tbSystemOutput.ReadOnly = true;
            this.tbSystemOutput.Size = new System.Drawing.Size(75, 20);
            this.tbSystemOutput.TabIndex = 8;
            this.tbSystemOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "System output:";
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(301, 19);
            this.tbInput.Name = "tbInput";
            this.tbInput.ReadOnly = true;
            this.tbInput.Size = new System.Drawing.Size(75, 20);
            this.tbInput.TabIndex = 6;
            this.tbInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Input:";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(180, 19);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(75, 20);
            this.tbTime.TabIndex = 4;
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(141, 22);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(33, 13);
            this.lbTime.TabIndex = 3;
            this.lbTime.Text = "Time:";
            // 
            // lbIteration
            // 
            this.lbIteration.AutoSize = true;
            this.lbIteration.Location = new System.Drawing.Point(6, 22);
            this.lbIteration.Name = "lbIteration";
            this.lbIteration.Size = new System.Drawing.Size(48, 13);
            this.lbIteration.TabIndex = 2;
            this.lbIteration.Text = "Iteration:";
            // 
            // tbIteration
            // 
            this.tbIteration.Location = new System.Drawing.Point(60, 19);
            this.tbIteration.Name = "tbIteration";
            this.tbIteration.ReadOnly = true;
            this.tbIteration.Size = new System.Drawing.Size(75, 20);
            this.tbIteration.TabIndex = 0;
            this.tbIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.rbWavesGenerator);
            this.groupBox4.Controls.Add(this.rbManual);
            this.groupBox4.Location = new System.Drawing.Point(12, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 527);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.cbSignalType);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Location = new System.Drawing.Point(6, 228);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(207, 294);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Settings";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbOffset);
            this.groupBox9.Controls.Add(this.tbSetOffset);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.btnSetWaves);
            this.groupBox9.Controls.Add(this.tbAmplitude);
            this.groupBox9.Controls.Add(this.tbFrequency);
            this.groupBox9.Controls.Add(this.tbSetAmplitude);
            this.groupBox9.Controls.Add(this.tbSetFrequency);
            this.groupBox9.Location = new System.Drawing.Point(6, 161);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(195, 127);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Waves";
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(68, 71);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(55, 20);
            this.tbOffset.TabIndex = 17;
            this.tbOffset.Text = "0";
            this.tbOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSetOffset
            // 
            this.tbSetOffset.Location = new System.Drawing.Point(129, 71);
            this.tbSetOffset.Name = "tbSetOffset";
            this.tbSetOffset.ReadOnly = true;
            this.tbSetOffset.Size = new System.Drawing.Size(60, 20);
            this.tbSetOffset.TabIndex = 16;
            this.tbSetOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Offset:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Amplitude:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Frequency:";
            // 
            // btnSetWaves
            // 
            this.btnSetWaves.Location = new System.Drawing.Point(6, 97);
            this.btnSetWaves.Name = "btnSetWaves";
            this.btnSetWaves.Size = new System.Drawing.Size(183, 23);
            this.btnSetWaves.TabIndex = 5;
            this.btnSetWaves.Text = "Set waves parameters";
            this.btnSetWaves.UseVisualStyleBackColor = true;
            this.btnSetWaves.Click += new System.EventHandler(this.btnSetWaves_Click);
            // 
            // tbAmplitude
            // 
            this.tbAmplitude.Location = new System.Drawing.Point(68, 45);
            this.tbAmplitude.Name = "tbAmplitude";
            this.tbAmplitude.Size = new System.Drawing.Size(55, 20);
            this.tbAmplitude.TabIndex = 4;
            this.tbAmplitude.Text = "1";
            this.tbAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(68, 19);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(55, 20);
            this.tbFrequency.TabIndex = 3;
            this.tbFrequency.Text = "0.2";
            this.tbFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSetAmplitude
            // 
            this.tbSetAmplitude.Location = new System.Drawing.Point(129, 45);
            this.tbSetAmplitude.Name = "tbSetAmplitude";
            this.tbSetAmplitude.ReadOnly = true;
            this.tbSetAmplitude.Size = new System.Drawing.Size(60, 20);
            this.tbSetAmplitude.TabIndex = 2;
            this.tbSetAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSetFrequency
            // 
            this.tbSetFrequency.Location = new System.Drawing.Point(129, 19);
            this.tbSetFrequency.Name = "tbSetFrequency";
            this.tbSetFrequency.ReadOnly = true;
            this.tbSetFrequency.Size = new System.Drawing.Size(60, 20);
            this.tbSetFrequency.TabIndex = 1;
            this.tbSetFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.btnSetSteps);
            this.groupBox8.Controls.Add(this.tbStepValues);
            this.groupBox8.Controls.Add(this.tbStepTimes);
            this.groupBox8.Controls.Add(this.tbSetStepValues);
            this.groupBox8.Controls.Add(this.tbSetStepTimes);
            this.groupBox8.Location = new System.Drawing.Point(6, 54);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(195, 101);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Steps";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Values:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Times:";
            // 
            // btnSetSteps
            // 
            this.btnSetSteps.Location = new System.Drawing.Point(6, 71);
            this.btnSetSteps.Name = "btnSetSteps";
            this.btnSetSteps.Size = new System.Drawing.Size(183, 23);
            this.btnSetSteps.TabIndex = 5;
            this.btnSetSteps.Text = "Set steps parameters";
            this.btnSetSteps.UseVisualStyleBackColor = true;
            this.btnSetSteps.Click += new System.EventHandler(this.btnSetSteps_Click);
            // 
            // tbStepValues
            // 
            this.tbStepValues.Location = new System.Drawing.Point(68, 45);
            this.tbStepValues.Name = "tbStepValues";
            this.tbStepValues.Size = new System.Drawing.Size(55, 20);
            this.tbStepValues.TabIndex = 4;
            this.tbStepValues.Text = "1, 2";
            this.tbStepValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbStepTimes
            // 
            this.tbStepTimes.Location = new System.Drawing.Point(68, 19);
            this.tbStepTimes.Name = "tbStepTimes";
            this.tbStepTimes.Size = new System.Drawing.Size(55, 20);
            this.tbStepTimes.TabIndex = 3;
            this.tbStepTimes.Text = "10, 20";
            this.tbStepTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSetStepValues
            // 
            this.tbSetStepValues.Location = new System.Drawing.Point(129, 45);
            this.tbSetStepValues.Name = "tbSetStepValues";
            this.tbSetStepValues.ReadOnly = true;
            this.tbSetStepValues.Size = new System.Drawing.Size(60, 20);
            this.tbSetStepValues.TabIndex = 2;
            this.tbSetStepValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSetStepTimes
            // 
            this.tbSetStepTimes.Location = new System.Drawing.Point(129, 19);
            this.tbSetStepTimes.Name = "tbSetStepTimes";
            this.tbSetStepTimes.ReadOnly = true;
            this.tbSetStepTimes.Size = new System.Drawing.Size(60, 20);
            this.tbSetStepTimes.TabIndex = 1;
            this.tbSetStepTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSignalType
            // 
            this.cbSignalType.DisplayMember = "Key";
            this.cbSignalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSignalType.FormattingEnabled = true;
            this.cbSignalType.Location = new System.Drawing.Point(76, 27);
            this.cbSignalType.Name = "cbSignalType";
            this.cbSignalType.Size = new System.Drawing.Size(125, 21);
            this.cbSignalType.TabIndex = 2;
            this.cbSignalType.ValueMember = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Signal type:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.trbSetvalue);
            this.groupBox6.Controls.Add(this.tbSetpointValue);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.trbInput);
            this.groupBox6.Controls.Add(this.tbInputValue);
            this.groupBox6.Location = new System.Drawing.Point(6, 42);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(207, 157);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Settings";
            // 
            // trbSetvalue
            // 
            this.trbSetvalue.AutoSize = false;
            this.trbSetvalue.Location = new System.Drawing.Point(6, 112);
            this.trbSetvalue.Maximum = 100;
            this.trbSetvalue.Name = "trbSetvalue";
            this.trbSetvalue.Size = new System.Drawing.Size(195, 35);
            this.trbSetvalue.TabIndex = 9;
            this.trbSetvalue.Value = 50;
            this.trbSetvalue.Scroll += new System.EventHandler(this.trbSetvalue_Scroll);
            // 
            // tbSetpointValue
            // 
            this.tbSetpointValue.Location = new System.Drawing.Point(126, 86);
            this.tbSetpointValue.Name = "tbSetpointValue";
            this.tbSetpointValue.ReadOnly = true;
            this.tbSetpointValue.Size = new System.Drawing.Size(75, 20);
            this.tbSetpointValue.TabIndex = 8;
            this.tbSetpointValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Close loop - set value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Open loop - input:";
            // 
            // rbWavesGenerator
            // 
            this.rbWavesGenerator.AutoSize = true;
            this.rbWavesGenerator.Location = new System.Drawing.Point(9, 205);
            this.rbWavesGenerator.Name = "rbWavesGenerator";
            this.rbWavesGenerator.Size = new System.Drawing.Size(107, 17);
            this.rbWavesGenerator.TabIndex = 1;
            this.rbWavesGenerator.Text = "Waves generator";
            this.rbWavesGenerator.UseVisualStyleBackColor = true;
            this.rbWavesGenerator.CheckedChanged += new System.EventHandler(this.rbWavesGenerator_CheckedChanged);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Checked = true;
            this.rbManual.Location = new System.Drawing.Point(9, 19);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(60, 17);
            this.rbManual.TabIndex = 0;
            this.rbManual.TabStop = true;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbMode);
            this.groupBox5.Controls.Add(this.lbMode);
            this.groupBox5.Location = new System.Drawing.Point(12, 109);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 50);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Control system mode";
            // 
            // cbMode
            // 
            this.cbMode.DisplayMember = "Key";
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(79, 19);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(134, 21);
            this.cbMode.TabIndex = 1;
            this.cbMode.ValueMember = "Value";
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.lbMode.Location = new System.Drawing.Point(6, 22);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(37, 13);
            this.lbMode.TabIndex = 0;
            this.lbMode.Text = "Mode:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(720, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Error:";
            // 
            // tbError
            // 
            this.tbError.Location = new System.Drawing.Point(758, 19);
            this.tbError.Name = "tbError";
            this.tbError.ReadOnly = true;
            this.tbError.Size = new System.Drawing.Size(75, 20);
            this.tbError.TabIndex = 12;
            this.tbError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbInputValue
            // 
            this.tbInputValue.Location = new System.Drawing.Point(126, 19);
            this.tbInputValue.Name = "tbInputValue";
            this.tbInputValue.ReadOnly = true;
            this.tbInputValue.Size = new System.Drawing.Size(75, 20);
            this.tbInputValue.TabIndex = 6;
            this.tbInputValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trbInput
            // 
            this.trbInput.AutoSize = false;
            this.trbInput.Location = new System.Drawing.Point(6, 45);
            this.trbInput.Maximum = 100;
            this.trbInput.Name = "trbInput";
            this.trbInput.Size = new System.Drawing.Size(195, 35);
            this.trbInput.TabIndex = 2;
            this.trbInput.Value = 50;
            this.trbInput.Scroll += new System.EventHandler(this.trbInput_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 741);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "JTControlSystem - Realtime Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSetvalue)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbIteration;
        private System.Windows.Forms.TextBox tbIteration;
        private System.Windows.Forms.RadioButton rbWavesGenerator;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbSetpointValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.TextBox tbSetOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetWaves;
        private System.Windows.Forms.TextBox tbAmplitude;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.TextBox tbSetAmplitude;
        private System.Windows.Forms.TextBox tbSetFrequency;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSetSteps;
        private System.Windows.Forms.TextBox tbStepValues;
        private System.Windows.Forms.TextBox tbStepTimes;
        private System.Windows.Forms.TextBox tbSetStepValues;
        private System.Windows.Forms.TextBox tbSetStepTimes;
        private System.Windows.Forms.ComboBox cbSignalType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trbSetvalue;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbControllerOutput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSystemOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trbInput;
        private System.Windows.Forms.TextBox tbInputValue;
    }
}

