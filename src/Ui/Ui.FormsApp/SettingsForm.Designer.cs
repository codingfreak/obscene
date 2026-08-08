namespace codingfreaks.obscene.Ui.FormsApp
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            AbortButton = new Button();
            OkButton = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            SettingsFolderButton = new Button();
            SettingsFolderText = new TextBox();
            FolderDialog = new FolderBrowserDialog();
            groupBox2 = new GroupBox();
            ObsPasswordText = new TextBox();
            ObsPortNumeric = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ObsPortNumeric).BeginInit();
            SuspendLayout();
            // 
            // AbortButton
            // 
            AbortButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AbortButton.DialogResult = DialogResult.Cancel;
            AbortButton.Location = new Point(320, 183);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(102, 36);
            AbortButton.TabIndex = 0;
            AbortButton.Text = "&Cancel";
            AbortButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            OkButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Enabled = false;
            OkButton.Location = new Point(212, 183);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(102, 36);
            OkButton.TabIndex = 1;
            OkButton.Text = "&OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(SettingsFolderButton);
            groupBox1.Controls.Add(SettingsFolderText);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 69);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings Directory";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(367, 15);
            label1.TabIndex = 2;
            label1.Text = "Define the directory in which obscene will store its program settings.";
            // 
            // SettingsFolderButton
            // 
            SettingsFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SettingsFolderButton.Location = new Point(372, 39);
            SettingsFolderButton.Name = "SettingsFolderButton";
            SettingsFolderButton.Size = new Size(32, 23);
            SettingsFolderButton.TabIndex = 1;
            SettingsFolderButton.Text = "...";
            SettingsFolderButton.UseVisualStyleBackColor = true;
            SettingsFolderButton.Click += SettingsFolderButton_Click;
            // 
            // SettingsFolderText
            // 
            SettingsFolderText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SettingsFolderText.Location = new Point(6, 39);
            SettingsFolderText.Multiline = true;
            SettingsFolderText.Name = "SettingsFolderText";
            SettingsFolderText.Size = new Size(360, 24);
            SettingsFolderText.TabIndex = 0;
            SettingsFolderText.TextChanged += OnControlValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(ObsPasswordText);
            groupBox2.Controls.Add(ObsPortNumeric);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(410, 89);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "OBS";
            // 
            // ObsPasswordText
            // 
            ObsPasswordText.Location = new Point(78, 46);
            ObsPasswordText.Name = "ObsPasswordText";
            ObsPasswordText.PasswordChar = '*';
            ObsPasswordText.Size = new Size(111, 23);
            ObsPasswordText.TabIndex = 3;
            ObsPasswordText.TextChanged += OnControlValueChanged;
            // 
            // ObsPortNumeric
            // 
            ObsPortNumeric.Location = new Point(78, 17);
            ObsPortNumeric.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            ObsPortNumeric.Name = "ObsPortNumeric";
            ObsPortNumeric.Size = new Size(60, 23);
            ObsPortNumeric.TabIndex = 2;
            ObsPortNumeric.ValueChanged += OnControlValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 49);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 1;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 22);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 0;
            label2.Text = "Port:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = AbortButton;
            ClientSize = new Size(434, 231);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(OkButton);
            Controls.Add(AbortButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(450, 270);
            Name = "SettingsForm";
            Text = "obscene Settings";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ObsPortNumeric).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button AbortButton;
        private Button OkButton;
        private GroupBox groupBox1;
        private FolderBrowserDialog FolderDialog;
        private Label label1;
        private Button SettingsFolderButton;
        private TextBox SettingsFolderText;
        private GroupBox groupBox2;
        private TextBox ObsPasswordText;
        private NumericUpDown ObsPortNumeric;
        private Label label3;
        private Label label2;
    }
}
