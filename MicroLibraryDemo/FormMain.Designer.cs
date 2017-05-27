namespace MicroLibraryDemo
{
    partial class FormMain
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.TextBoxInterval = new System.Windows.Forms.TextBox();
            this.LabelIntervalText = new System.Windows.Forms.Label();
            this.LabelElapsedTimeText = new System.Windows.Forms.Label();
            this.TextBoxElapsedTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(27, 88);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(102, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(158, 87);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(102, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // TextBoxInterval
            // 
            this.TextBoxInterval.Location = new System.Drawing.Point(158, 20);
            this.TextBoxInterval.Name = "TextBoxInterval";
            this.TextBoxInterval.Size = new System.Drawing.Size(102, 20);
            this.TextBoxInterval.TabIndex = 2;
            this.TextBoxInterval.Text = "1111";
            // 
            // LabelIntervalText
            // 
            this.LabelIntervalText.AutoSize = true;
            this.LabelIntervalText.Location = new System.Drawing.Point(24, 23);
            this.LabelIntervalText.Name = "LabelIntervalText";
            this.LabelIntervalText.Size = new System.Drawing.Size(128, 13);
            this.LabelIntervalText.TabIndex = 3;
            this.LabelIntervalText.Text = "Timer Interval (micro sec):";
            // 
            // LabelElapsedTimeText
            // 
            this.LabelElapsedTimeText.AutoSize = true;
            this.LabelElapsedTimeText.Location = new System.Drawing.Point(24, 55);
            this.LabelElapsedTimeText.Name = "LabelElapsedTimeText";
            this.LabelElapsedTimeText.Size = new System.Drawing.Size(128, 13);
            this.LabelElapsedTimeText.TabIndex = 5;
            this.LabelElapsedTimeText.Text = "Elapsed Time (micro sec):";
            // 
            // TextBoxElapsedTime
            // 
            this.TextBoxElapsedTime.Location = new System.Drawing.Point(158, 52);
            this.TextBoxElapsedTime.Name = "TextBoxElapsedTime";
            this.TextBoxElapsedTime.ReadOnly = true;
            this.TextBoxElapsedTime.Size = new System.Drawing.Size(102, 20);
            this.TextBoxElapsedTime.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 132);
            this.Controls.Add(this.TextBoxElapsedTime);
            this.Controls.Add(this.LabelElapsedTimeText);
            this.Controls.Add(this.LabelIntervalText);
            this.Controls.Add(this.TextBoxInterval);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MicroTimer WinForms Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox TextBoxInterval;
        private System.Windows.Forms.Label LabelIntervalText;
        private System.Windows.Forms.Label LabelElapsedTimeText;
        private System.Windows.Forms.TextBox TextBoxElapsedTime;
    }
}

