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
            RgbGroup = new GroupBox();
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
            AlphaGroup = new GroupBox();
            AlphaTrack = new TrackBar();
            WebGroup = new GroupBox();
            WebValue = new TextBox();
            RgbGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BlueValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GreenValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlphaValue).BeginInit();
            AlphaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlphaTrack).BeginInit();
            WebGroup.SuspendLayout();
            SuspendLayout();
            // 
            // RgbGroup
            // 
            RgbGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RgbGroup.Controls.Add(label3);
            RgbGroup.Controls.Add(label2);
            RgbGroup.Controls.Add(BlueValue);
            RgbGroup.Controls.Add(GreenValue);
            RgbGroup.Controls.Add(label1);
            RgbGroup.Controls.Add(RedValue);
            RgbGroup.Location = new Point(257, 3);
            RgbGroup.Name = "RgbGroup";
            RgbGroup.Size = new Size(94, 111);
            RgbGroup.TabIndex = 1;
            RgbGroup.TabStop = false;
            RgbGroup.Text = "RGB";
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
            NullCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            NullCheckBox.Location = new Point(277, 170);
            NullCheckBox.Name = "NullCheckBox";
            NullCheckBox.Size = new Size(74, 19);
            NullCheckBox.TabIndex = 2;
            NullCheckBox.Text = "No Color";
            NullCheckBox.TextAlign = ContentAlignment.MiddleRight;
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
            // AlphaGroup
            // 
            AlphaGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            AlphaGroup.Controls.Add(AlphaTrack);
            AlphaGroup.Controls.Add(AlphaValue);
            AlphaGroup.Location = new Point(194, 3);
            AlphaGroup.Name = "AlphaGroup";
            AlphaGroup.Size = new Size(57, 184);
            AlphaGroup.TabIndex = 5;
            AlphaGroup.TabStop = false;
            AlphaGroup.Text = "Alpha";
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
            // WebGroup
            // 
            WebGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WebGroup.Controls.Add(WebValue);
            WebGroup.Location = new Point(257, 112);
            WebGroup.Name = "WebGroup";
            WebGroup.Size = new Size(94, 52);
            WebGroup.TabIndex = 7;
            WebGroup.TabStop = false;
            WebGroup.Text = "Web";
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
            Controls.Add(WebGroup);
            Controls.Add(AlphaGroup);
            Controls.Add(ColorCircle);
            Controls.Add(NullCheckBox);
            Controls.Add(RgbGroup);
            MinimumSize = new Size(354, 190);
            Name = "AlphaColorPicker";
            Size = new Size(354, 190);
            RgbGroup.ResumeLayout(false);
            RgbGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BlueValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)GreenValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)RedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlphaValue).EndInit();
            AlphaGroup.ResumeLayout(false);
            AlphaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AlphaTrack).EndInit();
            WebGroup.ResumeLayout(false);
            WebGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private GroupBox RgbGroup;
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
        private GroupBox AlphaGroup;
        private TrackBar AlphaTrack;
        private GroupBox WebGroup;
        private TextBox WebValue;
    }
}
