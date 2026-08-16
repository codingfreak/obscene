namespace codingfreaks.obscene.Ui.FormsApp.Controls
{
    partial class AlphaColorPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            BlueValue = new NumericUpDown();
            GreenValue = new NumericUpDown();
            label1 = new Label();
            RedValue = new NumericUpDown();
            NullCheckBox = new CheckBox();
            AlphaValue = new NumericUpDown();
            colorDialog1 = new ColorDialog();
            ColorCircle = new ColorCircle();
            groupBox2 = new GroupBox();
            AlphaTrack = new TrackBar();
            groupBox3 = new GroupBox();
            WebValue = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BlueValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GreenValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlphaValue).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlphaTrack).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(BlueValue);
            groupBox1.Controls.Add(GreenValue);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(RedValue);
            groupBox1.Location = new Point(257, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(94, 111);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "RGB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 4;
            label3.Text = "B";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(15, 15);
            label2.TabIndex = 3;
            label2.Text = "G";
            // 
            // BlueValue
            // 
            BlueValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BlueValue.Location = new Point(44, 80);
            BlueValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            BlueValue.Name = "BlueValue";
            BlueValue.Size = new Size(44, 23);
            BlueValue.TabIndex = 3;
            BlueValue.ValueChanged += NumControl_ValueChanged;
            // 
            // GreenValue
            // 
            GreenValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GreenValue.Location = new Point(44, 51);
            GreenValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            GreenValue.Name = "GreenValue";
            GreenValue.Size = new Size(44, 23);
            GreenValue.TabIndex = 2;
            GreenValue.ValueChanged += NumControl_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 24);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 1;
            label1.Text = "R";
            // 
            // RedValue
            // 
            RedValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RedValue.Location = new Point(44, 22);
            RedValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            RedValue.Name = "RedValue";
            RedValue.Size = new Size(44, 23);
            RedValue.TabIndex = 0;
            RedValue.ValueChanged += NumControl_ValueChanged;
            // 
            // NullCheckBox
            // 
            NullCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NullCheckBox.AutoSize = true;
            NullCheckBox.Location = new Point(336, 170);
            NullCheckBox.Name = "NullCheckBox";
            NullCheckBox.Size = new Size(15, 14);
            NullCheckBox.TabIndex = 2;
            NullCheckBox.UseVisualStyleBackColor = true;
            NullCheckBox.CheckedChanged += NullCheckBox_CheckedChanged;
            // 
            // AlphaValue
            // 
            AlphaValue.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AlphaValue.Location = new Point(6, 152);
            AlphaValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            AlphaValue.Name = "AlphaValue";
            AlphaValue.Size = new Size(45, 23);
            AlphaValue.TabIndex = 5;
            AlphaValue.ValueChanged += NumControl_ValueChanged;
            // 
            // ColorCircle
            // 
            ColorCircle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ColorCircle.Color = Color.White;
            ColorCircle.Location = new Point(3, 3);
            ColorCircle.Name = "ColorCircle";
            ColorCircle.Size = new Size(185, 184);
            ColorCircle.TabIndex = 6;
            ColorCircle.Text = "colorCircle1";
            ColorCircle.OnColorChanged += ColorCircle_OnColorChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(AlphaTrack);
            groupBox2.Controls.Add(AlphaValue);
            groupBox2.Location = new Point(194, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(57, 184);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Alpha";
            // 
            // AlphaTrack
            // 
            AlphaTrack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AlphaTrack.Location = new Point(6, 22);
            AlphaTrack.Maximum = 255;
            AlphaTrack.Name = "AlphaTrack";
            AlphaTrack.Orientation = Orientation.Vertical;
            AlphaTrack.Size = new Size(45, 127);
            AlphaTrack.TabIndex = 6;
            AlphaTrack.ValueChanged += AlphaTrack_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.Controls.Add(WebValue);
            groupBox3.Location = new Point(257, 112);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(94, 52);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Web";
            // 
            // WebValue
            // 
            WebValue.Location = new Point(6, 22);
            WebValue.Name = "WebValue";
            WebValue.Size = new Size(82, 23);
            WebValue.TabIndex = 0;
            // 
            // AlphaColorPicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(ColorCircle);
            Controls.Add(NullCheckBox);
            Controls.Add(groupBox1);
            MinimumSize = new Size(354, 190);
            Name = "AlphaColorPicker";
            Size = new Size(354, 190);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BlueValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)GreenValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)RedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlphaValue).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AlphaTrack).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private GroupBox groupBox1;
        private CheckBox NullCheckBox;
        private Label label1;
        private NumericUpDown RedValue;
        private Label label3;
        private Label label2;
        private NumericUpDown BlueValue;
        private NumericUpDown GreenValue;
        private NumericUpDown AlphaValue;
        private ColorDialog colorDialog1;
        private ColorCircle ColorCircle;
        private GroupBox groupBox2;
        private TrackBar AlphaTrack;
        private GroupBox groupBox3;
        private TextBox WebValue;
    }
}
