namespace codingfreaks.obscene.Ui.FormsApp.Editors
{
    using System.ComponentModel;
    using System.Windows.Forms.Design;

    /// <summary>
    /// Custom control for color picking from the property grid.
    /// </summary>
    /// <remarks>
    /// Is called if a color property is decorated with the <see cref="EditorAttribute" />  using the
    /// <see cref="AlphaColorUiTypeEditor" />.
    /// </remarks>
    public partial class AlphaColorPicker : UserControl
    {
        #region member vars

        private readonly NumericUpDown _alphaEditor = GetNumericControl();
        private readonly NumericUpDown _blueNumericUpDown = GetNumericControl();
        private readonly NumericUpDown _greenNumericUpDown = GetNumericControl();
        private readonly CheckBox? _noneCheckBox;
        private readonly NumericUpDown _redNumericUpDown = GetNumericControl();
        private readonly TableLayoutPanel _tableLayout;

        #endregion

        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// This gets called by the property grid.
        /// </remarks>
        /// <param name="initialValue">The color which is currently selected.</param>
        /// <param name="nullable">Indicates if the data type is nullable or not.</param>
        /// <param name="editorService">The service to communicate with the property grid.</param>
        public AlphaColorPicker(Color? initialValue, bool nullable, IWindowsFormsEditorService editorService)
        {
            InitializeComponent();
            var initializeColor = initialValue ?? Color.FromArgb(255, Color.Black);
            _alphaEditor.Value = initializeColor.A;
            _redNumericUpDown.Value = initializeColor.R;
            _greenNumericUpDown.Value = initializeColor.G;
            _blueNumericUpDown.Value = initializeColor.B;
            _tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            if (nullable)
            {
                // Add the checkbox to allow the color to be null
                _noneCheckBox = new CheckBox
                {
                    Text = "None",
                    Checked = initialValue is null,
                    AutoSize = true
                };
                _noneCheckBox.CheckedChanged += (_, _) => SetEnabled(!_noneCheckBox.Checked);
                _tableLayout.Controls.Add(_noneCheckBox);
                _tableLayout.Controls.Add(new Label());
            }
            AddRow("A", _alphaEditor);
            AddRow("R", _redNumericUpDown);
            AddRow("G", _greenNumericUpDown);
            AddRow("B", _blueNumericUpDown);
            // Add the ok button
            var okButton = new Button
            {
                Text = "&OK",
                Dock = DockStyle.Bottom
            };
            okButton.Click += (_, _) => editorService.CloseDropDown();
            Controls.Add(_tableLayout);
            Controls.Add(okButton);
            // Finalize the state
            Size = new Size(160, nullable ? 200 : 175);
            SetEnabled(!(nullable && initialValue is null));
        }

        #endregion

        #region methods

        /// <summary>
        /// Adds a row to the table layout using a label with the <paramref name="text" /> and the provided
        /// <paramref name="control" /> in the second column.
        /// </summary>
        /// <param name="text">The text of the label.</param>
        /// <param name="control">The control.</param>
        private void AddRow(string text, Control control)
        {
            _tableLayout.Controls.Add(
                new Label
                {
                    Text = text,
                    AutoSize = true
                });
            _tableLayout.Controls.Add(control);
        }

        /// <summary>
        /// Retrieves a fresh numeric up-down-control.
        /// </summary>
        /// <returns>The control to use.</returns>
        private static NumericUpDown GetNumericControl()
        {
            return new NumericUpDown
            {
                Minimum = 0,
                Maximum = 255,
                Width = 60
            };
        }

        /// <summary>
        /// Callback for the nullable checkbox.
        /// </summary>
        /// <param name="on"></param>
        private void SetEnabled(bool on)
        {
            foreach (Control control in _tableLayout.Controls)
            {
                if (control is CheckBox)
                {
                    continue;
                }
                control.Visible = on;
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// Indicates of the null-checkbox is checked.
        /// </summary>
        public bool IsNull => _noneCheckBox?.Checked == true;

        /// <summary>
        /// The currently selected color.
        /// </summary>
        public Color SelectedColor =>
            Color.FromArgb(
                (int)_alphaEditor.Value,
                (int)_redNumericUpDown.Value,
                (int)_greenNumericUpDown.Value,
                (int)_blueNumericUpDown.Value);

        #endregion
    }
}
