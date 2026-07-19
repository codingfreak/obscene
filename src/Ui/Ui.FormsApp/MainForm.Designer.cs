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
            ObsSceneListSummaryLabel = new Label();
            ObsProfileSelect = new ComboBox();
            label1 = new Label();
            ObsSceneListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            TrayIcon = new NotifyIcon(components);
            TrayContextMenu = new ContextMenuStrip(components);
            OpenObsceneContextCommand = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ExitObsenceContextCommand = new ToolStripMenuItem();
            StatusBar = new StatusStrip();
            StatusBarLabel = new ToolStripStatusLabel();
            CurrentSceneBarLabel = new ToolStripStatusLabel();
            ColorModeContextMenu = new ContextMenuStrip(components);
            ColorModeDarkItem = new ToolStripMenuItem();
            ColorModeLightItem = new ToolStripMenuItem();
            ColorModeToolStripDropDown = new ToolStripDropDownButton();
            groupBox2 = new GroupBox();
            DesignAreaSplitContainer = new SplitContainer();
            ConfigSceneTree = new TreeView();
            GeometryHintLabel = new Label();
            GeometryProperties = new PropertyGrid();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItem2 = new ToolStripMenuItem();
            MainToolStrip = new ToolStrip();
            LoadToolStripButton = new ToolStripButton();
            SaveToolStripButton = new ToolStripButton();
            ToolStripSep1 = new ToolStripSeparator();
            ExitToolStripButton = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            TopMostToolStripCheck = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            SettingsToolStripDropDown = new ToolStripButton();
            groupBox1.SuspendLayout();
            TrayContextMenu.SuspendLayout();
            StatusBar.SuspendLayout();
            ColorModeContextMenu.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DesignAreaSplitContainer).BeginInit();
            DesignAreaSplitContainer.Panel1.SuspendLayout();
            DesignAreaSplitContainer.Panel2.SuspendLayout();
            DesignAreaSplitContainer.SuspendLayout();
            MainToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(ObsSceneListSummaryLabel);
            groupBox1.Controls.Add(ObsProfileSelect);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ObsSceneListView);
            groupBox1.Location = new Point(12, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(466, 165);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "OBS Info";
            // 
            // ObsSceneListSummaryLabel
            // 
            ObsSceneListSummaryLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ObsSceneListSummaryLabel.AutoSize = true;
            ObsSceneListSummaryLabel.Location = new Point(6, 142);
            ObsSceneListSummaryLabel.Name = "ObsSceneListSummaryLabel";
            ObsSceneListSummaryLabel.Size = new Size(10, 15);
            ObsSceneListSummaryLabel.TabIndex = 3;
            ObsSceneListSummaryLabel.Text = ".";
            // 
            // ObsProfileSelect
            // 
            ObsProfileSelect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ObsProfileSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            ObsProfileSelect.FormattingEnabled = true;
            ObsProfileSelect.Location = new Point(56, 16);
            ObsProfileSelect.Name = "ObsProfileSelect";
            ObsProfileSelect.Size = new Size(404, 23);
            ObsProfileSelect.TabIndex = 2;
            ObsProfileSelect.Visible = false;
            ObsProfileSelect.SelectedIndexChanged += ObsProfileSelect_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Profile:";
            // 
            // ObsSceneListView
            // 
            ObsSceneListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ObsSceneListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            ObsSceneListView.Enabled = false;
            ObsSceneListView.FullRowSelect = true;
            ObsSceneListView.Location = new Point(6, 45);
            ObsSceneListView.Name = "ObsSceneListView";
            ObsSceneListView.Size = new Size(454, 94);
            ObsSceneListView.TabIndex = 0;
            ObsSceneListView.UseCompatibleStateImageBehavior = false;
            ObsSceneListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Scene name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Scene Id";
            columnHeader2.Width = 200;
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
            StatusBar.Size = new Size(490, 22);
            StatusBar.TabIndex = 1;
            StatusBar.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            StatusBarLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            StatusBarLabel.Name = "StatusBarLabel";
            StatusBarLabel.Size = new Size(471, 17);
            StatusBarLabel.Spring = true;
            StatusBarLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CurrentSceneBarLabel
            // 
            CurrentSceneBarLabel.AutoToolTip = true;
            CurrentSceneBarLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            CurrentSceneBarLabel.Name = "CurrentSceneBarLabel";
            CurrentSceneBarLabel.Size = new Size(4, 17);
            CurrentSceneBarLabel.ToolTipText = "Current selected OBS scene";
            // 
            // ColorModeContextMenu
            // 
            ColorModeContextMenu.Items.AddRange(new ToolStripItem[] { ColorModeDarkItem, ColorModeLightItem });
            ColorModeContextMenu.Name = "ColorModeContextMenu";
            ColorModeContextMenu.Size = new Size(102, 48);
            // 
            // ColorModeDarkItem
            // 
            ColorModeDarkItem.Name = "ColorModeDarkItem";
            ColorModeDarkItem.Size = new Size(101, 22);
            ColorModeDarkItem.Tag = "dark";
            ColorModeDarkItem.Text = "Dark";
            ColorModeDarkItem.Click += SetColorMode;
            // 
            // ColorModeLightItem
            // 
            ColorModeLightItem.Name = "ColorModeLightItem";
            ColorModeLightItem.Size = new Size(101, 22);
            ColorModeLightItem.Tag = "classic";
            ColorModeLightItem.Text = "Light";
            ColorModeLightItem.Click += SetColorMode;
            // 
            // ColorModeToolStripDropDown
            // 
            ColorModeToolStripDropDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ColorModeToolStripDropDown.DropDown = ColorModeContextMenu;
            ColorModeToolStripDropDown.Image = (Image)resources.GetObject("ColorModeToolStripDropDown.Image");
            ColorModeToolStripDropDown.ImageTransparentColor = Color.Magenta;
            ColorModeToolStripDropDown.Name = "ColorModeToolStripDropDown";
            ColorModeToolStripDropDown.Size = new Size(29, 22);
            ColorModeToolStripDropDown.Text = "Color mode";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(DesignAreaSplitContainer);
            groupBox2.Location = new Point(12, 199);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(466, 337);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Masks";
            // 
            // DesignAreaSplitContainer
            // 
            DesignAreaSplitContainer.Dock = DockStyle.Fill;
            DesignAreaSplitContainer.Location = new Point(3, 19);
            DesignAreaSplitContainer.Name = "DesignAreaSplitContainer";
            // 
            // DesignAreaSplitContainer.Panel1
            // 
            DesignAreaSplitContainer.Panel1.Controls.Add(ConfigSceneTree);
            // 
            // DesignAreaSplitContainer.Panel2
            // 
            DesignAreaSplitContainer.Panel2.Controls.Add(GeometryHintLabel);
            DesignAreaSplitContainer.Panel2.Controls.Add(GeometryProperties);
            DesignAreaSplitContainer.Size = new Size(460, 315);
            DesignAreaSplitContainer.SplitterDistance = 153;
            DesignAreaSplitContainer.TabIndex = 4;
            // 
            // ConfigSceneTree
            // 
            ConfigSceneTree.Dock = DockStyle.Fill;
            ConfigSceneTree.Location = new Point(0, 0);
            ConfigSceneTree.Name = "ConfigSceneTree";
            ConfigSceneTree.Size = new Size(153, 315);
            ConfigSceneTree.TabIndex = 3;
            ConfigSceneTree.AfterSelect += ConfigSceneTree_AfterSelect;
            // 
            // GeometryHintLabel
            // 
            GeometryHintLabel.Location = new Point(63, 96);
            GeometryHintLabel.Name = "GeometryHintLabel";
            GeometryHintLabel.Size = new Size(185, 129);
            GeometryHintLabel.TabIndex = 3;
            GeometryHintLabel.Text = "Select a geometry first.";
            GeometryHintLabel.TextAlign = ContentAlignment.MiddleCenter;
            GeometryHintLabel.Visible = false;
            // 
            // GeometryProperties
            // 
            GeometryProperties.BackColor = SystemColors.Control;
            GeometryProperties.Dock = DockStyle.Fill;
            GeometryProperties.Location = new Point(0, 0);
            GeometryProperties.Name = "GeometryProperties";
            GeometryProperties.Size = new Size(303, 315);
            GeometryProperties.TabIndex = 2;
            GeometryProperties.Visible = false;
            GeometryProperties.PropertyValueChanged += GeometryProperties_PropertyValueChanged;
            GeometryProperties.SelectedObjectsChanged += GeometryProperties_SelectedObjectsChanged;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(103, 22);
            toolStripMenuItem1.Text = "&Open";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(100, 6);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(103, 22);
            toolStripMenuItem2.Text = "E&xit";
            // 
            // MainToolStrip
            // 
            MainToolStrip.Items.AddRange(new ToolStripItem[] { LoadToolStripButton, SaveToolStripButton, ToolStripSep1, ExitToolStripButton, toolStripSeparator3, TopMostToolStripCheck, ColorModeToolStripDropDown, toolStripSeparator4, SettingsToolStripDropDown });
            MainToolStrip.Location = new Point(0, 0);
            MainToolStrip.Name = "MainToolStrip";
            MainToolStrip.Size = new Size(490, 25);
            MainToolStrip.TabIndex = 3;
            // 
            // LoadToolStripButton
            // 
            LoadToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            LoadToolStripButton.Image = (Image)resources.GetObject("LoadToolStripButton.Image");
            LoadToolStripButton.ImageTransparentColor = Color.Magenta;
            LoadToolStripButton.Name = "LoadToolStripButton";
            LoadToolStripButton.Size = new Size(23, 22);
            LoadToolStripButton.Text = "Load";
            LoadToolStripButton.ToolTipText = "Load settings";
            // 
            // SaveToolStripButton
            // 
            SaveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SaveToolStripButton.Image = (Image)resources.GetObject("SaveToolStripButton.Image");
            SaveToolStripButton.ImageTransparentColor = Color.Magenta;
            SaveToolStripButton.Name = "SaveToolStripButton";
            SaveToolStripButton.Size = new Size(23, 22);
            SaveToolStripButton.Text = "toolStripButton1";
            SaveToolStripButton.ToolTipText = "Save Settings";
            SaveToolStripButton.Click += SaveToolStripButton_Click;
            // 
            // ToolStripSep1
            // 
            ToolStripSep1.Name = "ToolStripSep1";
            ToolStripSep1.Size = new Size(6, 25);
            // 
            // ExitToolStripButton
            // 
            ExitToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ExitToolStripButton.Image = (Image)resources.GetObject("ExitToolStripButton.Image");
            ExitToolStripButton.ImageTransparentColor = Color.Magenta;
            ExitToolStripButton.Name = "ExitToolStripButton";
            ExitToolStripButton.Size = new Size(23, 22);
            ExitToolStripButton.Text = "toolStripButton1";
            ExitToolStripButton.ToolTipText = "Exit application";
            ExitToolStripButton.Click += ExitToolStripButton_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // TopMostToolStripCheck
            // 
            TopMostToolStripCheck.CheckOnClick = true;
            TopMostToolStripCheck.Image = (Image)resources.GetObject("TopMostToolStripCheck.Image");
            TopMostToolStripCheck.ImageTransparentColor = Color.Magenta;
            TopMostToolStripCheck.Name = "TopMostToolStripCheck";
            TopMostToolStripCheck.Size = new Size(77, 22);
            TopMostToolStripCheck.Text = "Top most";
            TopMostToolStripCheck.ToolTipText = "Stay on top";
            TopMostToolStripCheck.CheckStateChanged += TopMostToolStripCheck_CheckStateChanged;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // SettingsToolStripDropDown
            // 
            SettingsToolStripDropDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SettingsToolStripDropDown.Image = (Image)resources.GetObject("SettingsToolStripDropDown.Image");
            SettingsToolStripDropDown.ImageTransparentColor = Color.Magenta;
            SettingsToolStripDropDown.Name = "SettingsToolStripDropDown";
            SettingsToolStripDropDown.Size = new Size(23, 22);
            SettingsToolStripDropDown.Text = "Settings";
            SettingsToolStripDropDown.Click += SettingsToolStripDropDown_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 561);
            Controls.Add(MainToolStrip);
            Controls.Add(groupBox2);
            Controls.Add(StatusBar);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(500, 600);
            Name = "MainForm";
            Text = "obscene";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            TrayContextMenu.ResumeLayout(false);
            StatusBar.ResumeLayout(false);
            StatusBar.PerformLayout();
            ColorModeContextMenu.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            DesignAreaSplitContainer.Panel1.ResumeLayout(false);
            DesignAreaSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DesignAreaSplitContainer).EndInit();
            DesignAreaSplitContainer.ResumeLayout(false);
            MainToolStrip.ResumeLayout(false);
            MainToolStrip.PerformLayout();
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
        private ListView ObsSceneListView;
        private ColumnHeader columnHeader1;
        private ComboBox ObsProfileSelect;
        private Label label1;
        private ColumnHeader columnHeader2;
        private Label ObsSceneListSummaryLabel;
        private GroupBox groupBox2;
        private PropertyGrid GeometryProperties;
        private ContextMenuStrip ColorModeContextMenu;
        private ToolStripMenuItem ColorModeDarkItem;
        private ToolStripMenuItem ColorModeLightItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStrip MainToolStrip;
        private ToolStripButton TopMostToolStripCheck;
        private ToolStripDropDownButton ColorModeToolStripDropDown;
        private ToolStripButton SaveToolStripButton;
        private ToolStripSeparator ToolStripSep1;
        private ToolStripButton ExitToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton LoadToolStripButton;
        private TreeView ConfigSceneTree;
        private SplitContainer DesignAreaSplitContainer;
        private Label GeometryHintLabel;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton SettingsToolStripDropDown;
    }
}
