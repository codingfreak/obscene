namespace codingfreaks.obscene.Ui.FormsApp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new GroupBox();
            TrayIcon = new NotifyIcon(components);
            TrayContextMenu = new ContextMenuStrip(components);
            OpenObsceneContextCommand = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ExitObsenceContextCommand = new ToolStripMenuItem();
            StatusBar = new StatusStrip();
            StatusBarLabel = new ToolStripStatusLabel();
            CurrentSceneBarLabel = new ToolStripStatusLabel();
            TrayContextMenu.SuspendLayout();
            StatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 181);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // TrayIcon
            // 
            TrayIcon.BalloonTipText = "Open Settings";
            TrayIcon.BalloonTipTitle = "obsence";
            TrayIcon.ContextMenuStrip = TrayContextMenu;
            TrayIcon.Icon = (Icon)resources.GetObject("TrayIcon.Icon");
            TrayIcon.Text = "obscene";
            TrayIcon.Visible = true;
            TrayIcon.DoubleClick += OpenObsceneContextCommand_Click;
            // 
            // TrayContextMenu
            // 
            TrayContextMenu.Items.AddRange(new ToolStripItem[] { OpenObsceneContextCommand, toolStripSeparator1, ExitObsenceContextCommand });
            TrayContextMenu.Name = "TrayContextMenu";
            TrayContextMenu.Size = new Size(104, 54);
            // 
            // OpenObsceneContextCommand
            // 
            OpenObsceneContextCommand.Name = "OpenObsceneContextCommand";
            OpenObsceneContextCommand.Size = new Size(103, 22);
            OpenObsceneContextCommand.Text = "&Open";
            OpenObsceneContextCommand.Click += OpenObsceneContextCommand_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(100, 6);
            // 
            // ExitObsenceContextCommand
            // 
            ExitObsenceContextCommand.Name = "ExitObsenceContextCommand";
            ExitObsenceContextCommand.Size = new Size(103, 22);
            ExitObsenceContextCommand.Text = "E&xit";
            ExitObsenceContextCommand.Click += ExitObsenceContextCommand_Click;
            // 
            // StatusBar
            // 
            StatusBar.Items.AddRange(new ToolStripItem[] { StatusBarLabel, CurrentSceneBarLabel });
            StatusBar.Location = new Point(0, 539);
            StatusBar.Name = "StatusBar";
            StatusBar.Size = new Size(484, 22);
            StatusBar.TabIndex = 1;
            StatusBar.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            StatusBarLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            StatusBarLabel.Name = "StatusBarLabel";
            StatusBarLabel.Size = new Size(434, 17);
            StatusBarLabel.Spring = true;
            StatusBarLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CurrentSceneBarLabel
            // 
            CurrentSceneBarLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            CurrentSceneBarLabel.Name = "CurrentSceneBarLabel";
            CurrentSceneBarLabel.Size = new Size(4, 17);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 561);
            Controls.Add(StatusBar);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(500, 600);
            Name = "MainForm";
            Text = "obscene";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            TrayContextMenu.ResumeLayout(false);
            StatusBar.ResumeLayout(false);
            StatusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayContextMenu;
        private ToolStripMenuItem OpenObsceneContextCommand;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ExitObsenceContextCommand;
        private StatusStrip StatusBar;
        private ToolStripStatusLabel StatusBarLabel;
        private ToolStripStatusLabel CurrentSceneBarLabel;
    }
}
