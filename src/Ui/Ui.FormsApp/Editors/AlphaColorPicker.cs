namespace codingfreaks.obscene.Ui.FormsApp.Editors
{
    using System.Windows.Forms.Design;

    public partial class AlphaColorPicker : UserControl
    {
        #region member vars

        private readonly NumericUpDown _a = GetNumericControl(), _r = GetNumericControl(), _g = GetNumericControl(), _b = GetNumericControl();
        private readonly CheckBox? _none;

        #endregion

        #region constructors and destructors

        public AlphaColorPicker(Color? initial, bool nullable, IWindowsFormsEditorService svc)
        {
            InitializeComponent();
            var c = initial ?? Color.FromArgb(255, Color.Black);
            _a.Value = c.A;
            _r.Value = c.R;
            _g.Value = c.G;
            _b.Value = c.B;
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            void AddRow(string t, Control ctl)
            {
                layout.Controls.Add(
                    new Label
                    {
                        Text = t,
                        AutoSize = true
                    });
                layout.Controls.Add(ctl);
            }
            if (nullable)
            {
                _none = new CheckBox
                {
                    Text = "None",
                    Checked = initial is null,
                    AutoSize = true
                };
                _none.CheckedChanged += (_, _) => SetEnabled(!_none.Checked);
                layout.Controls.Add(_none);
                layout.Controls.Add(new Label());
            }
            AddRow("A", _a);
            AddRow("R", _r);
            AddRow("G", _g);
            AddRow("B", _b);
            var ok = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom
            };
            ok.Click += (_, _) => svc.CloseDropDown();
            Controls.Add(layout);
            Controls.Add(ok);
            Size = new Size(160, nullable ? 200 : 175);
            SetEnabled(!(nullable && initial is null));
        }

        #endregion

        #region methods

        private static NumericUpDown GetNumericControl()
        {
            return new NumericUpDown
            {
                Minimum = 0,
                Maximum = 255,
                Width = 60
            };
        }

        private void SetEnabled(bool on)
        {
            _a.Enabled = _r.Enabled = _g.Enabled = _b.Enabled = on;
        }

        #endregion

        #region properties

        public bool IsNull => _none?.Checked == true;

        public Color SelectedColor => Color.FromArgb((int)_a.Value, (int)_r.Value, (int)_g.Value, (int)_b.Value);

        #endregion
    }
}
