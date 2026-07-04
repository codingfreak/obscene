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
            ColorModeSelector = new ToolStripDropDownButton();
            ColorModeContextMenu = new ContextMenuStrip(components);
            ColorModeDarkItem = new ToolStripMenuItem();
            ColorModeLightItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            GeometryProperties = new PropertyGrid();
            ConfigGeometriesList = new ListBox();
            ConfigSceneList = new ListBox();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItem2 = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            TrayContextMenu.SuspendLayout();
            StatusBar.SuspendLayout();
            ColorModeContextMenu.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(ObsSceneListSummaryLabel);
            groupBox1.Controls.Add(ObsProfileSelect);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ObsSceneListView);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(560, 181);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "OBS Info";
            // 
            // ObsSceneListSummaryLabel
            // 
            ObsSceneListSummaryLabel.AutoSize = true;
            ObsSceneListSummaryLabel.Location = new Point(6, 158);
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
            ObsProfileSelect.Size = new Size(498, 23);
            ObsProfileSelect.TabIndex = 2;
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
            ObsSceneListView.Size = new Size(548, 110);
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
            StatusBar.Items.AddRange(new ToolStripItem[] { StatusBarLabel, CurrentSceneBarLabel, ColorModeSelector });
            StatusBar.Location = new Point(0, 629);
            StatusBar.Name = "StatusBar";
            StatusBar.Size = new Size(584, 22);
            StatusBar.TabIndex = 1;
            StatusBar.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            StatusBarLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            StatusBarLabel.Name = "StatusBarLabel";
            StatusBarLabel.Size = new Size(536, 17);
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
            // ColorModeSelector
            // 
            ColorModeSelector.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ColorModeSelector.DropDown = ColorModeContextMenu;
            ColorModeSelector.Image = (Image)resources.GetObject("ColorModeSelector.Image");
            ColorModeSelector.ImageTransparentColor = Color.Magenta;
            ColorModeSelector.Name = "ColorModeSelector";
            ColorModeSelector.Size = new Size(29, 20);
            ColorModeSelector.Text = "Dark";
            // 
            // ColorModeContextMenu
            // 
            ColorModeContextMenu.Items.AddRange(new ToolStripItem[] { ColorModeDarkItem, ColorModeLightItem });
            ColorModeContextMenu.Name = "ColorModeContextMenu";
            ColorModeContextMenu.Size = new Size(181, 70);
            // 
            // ColorModeDarkItem
            // 
            ColorModeDarkItem.Name = "ColorModeDarkItem";
            ColorModeDarkItem.Size = new Size(180, 22);
            ColorModeDarkItem.Tag = "dark";
            ColorModeDarkItem.Text = "Dark";
            ColorModeDarkItem.Click += ColorModeItem_Click;
            // 
            // ColorModeLightItem
            // 
            ColorModeLightItem.Name = "ColorModeLightItem";
            ColorModeLightItem.Size = new Size(180, 22);
            ColorModeLightItem.Tag = "classic";
            ColorModeLightItem.Text = "Light";
            ColorModeLightItem.Click += ColorModeItem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(GeometryProperties);
            groupBox2.Controls.Add(ConfigGeometriesList);
            groupBox2.Controls.Add(ConfigSceneList);
            groupBox2.Location = new Point(12, 199);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(560, 427);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Masks";
            // 
            // GeometryProperties
            // 
            GeometryProperties.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GeometryProperties.BackColor = SystemColors.Control;
            GeometryProperties.Location = new Point(242, 22);
            GeometryProperties.Name = "GeometryProperties";
            GeometryProperties.Size = new Size(312, 364);
            GeometryProperties.TabIndex = 2;
            GeometryProperties.PropertyValueChanged += GeometryProperties_PropertyValueChanged;
            // 
            // ConfigGeometriesList
            // 
            ConfigGeometriesList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ConfigGeometriesList.DisplayMember = "Label";
            ConfigGeometriesList.FormattingEnabled = true;
            ConfigGeometriesList.Location = new Point(142, 22);
            ConfigGeometriesList.Name = "ConfigGeometriesList";
            ConfigGeometriesList.Size = new Size(94, 364);
            ConfigGeometriesList.TabIndex = 1;
            ConfigGeometriesList.ValueMember = "Instance";
            ConfigGeometriesList.SelectedValueChanged += ConfigGeometriesList_SelectedValueChanged;
            // 
            // ConfigSceneList
            // 
            ConfigSceneList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ConfigSceneList.FormattingEnabled = true;
            ConfigSceneList.Location = new Point(6, 22);
            ConfigSceneList.Name = "ConfigSceneList";
            ConfigSceneList.Size = new Size(130, 364);
            ConfigSceneList.TabIndex = 0;
            ConfigSceneList.SelectedValueChanged += ConfigSceneList_SelectedValueChanged;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 651);
            Controls.Add(groupBox2);
            Controls.Add(StatusBar);
            Controls.Add(groupBox1);
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
        private ListBox ConfigSceneList;
        private ListBox ConfigGeometriesList;
        private PropertyGrid GeometryProperties;
        private ToolStripDropDownButton ColorModeSelector;
        private ContextMenuStrip ColorModeContextMenu;
        private ToolStripMenuItem ColorModeDarkItem;
        private ToolStripMenuItem ColorModeLightItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}
