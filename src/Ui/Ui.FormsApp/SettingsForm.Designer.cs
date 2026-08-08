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
            AbortButton = new Button();
            OkButton = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            SettingsFolderButton = new Button();
            SettingsFolderText = new TextBox();
            FolderDialog = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // AbortButton
            // 
            AbortButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AbortButton.DialogResult = DialogResult.Cancel;
            AbortButton.Location = new Point(318, 115);
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
            OkButton.Location = new Point(210, 115);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(102, 36);
            OkButton.TabIndex = 1;
            OkButton.Text = "&OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(SettingsFolderButton);
            groupBox1.Controls.Add(SettingsFolderText);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 98);
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
            SettingsFolderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SettingsFolderButton.Location = new Point(370, 44);
            SettingsFolderButton.Name = "SettingsFolderButton";
            SettingsFolderButton.Size = new Size(32, 23);
            SettingsFolderButton.TabIndex = 1;
            SettingsFolderButton.Text = "...";
            SettingsFolderButton.UseVisualStyleBackColor = true;
            SettingsFolderButton.Click += SettingsFolderButton_Click;
            // 
            // SettingsFolderText
            // 
            SettingsFolderText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SettingsFolderText.Location = new Point(6, 44);
            SettingsFolderText.Multiline = true;
            SettingsFolderText.Name = "SettingsFolderText";
            SettingsFolderText.Size = new Size(358, 48);
            SettingsFolderText.TabIndex = 0;
            SettingsFolderText.TextChanged += SettingsFolderText_TextChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = AbortButton;
            ClientSize = new Size(432, 163);
            Controls.Add(groupBox1);
            Controls.Add(OkButton);
            Controls.Add(AbortButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}
