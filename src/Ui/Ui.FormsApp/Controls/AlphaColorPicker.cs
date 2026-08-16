namespace codingfreaks.obscene.Ui.FormsApp.Controls
{
    using System.ComponentModel;
    using System.Windows.Forms.Design;

    using Editors;

    using Models;

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

        private bool _stopPropagation;

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
            SelectedColor = initialValue ?? Color.FromArgb(255, Color.Black);
            NullCheckBox.Checked = initialValue is null;
            SetEnabled(!(nullable && initialValue is null));
        }

        #endregion

        #region methods

        private void AlphaTrack_ValueChanged(object sender, EventArgs e)
        {
            if (_stopPropagation)
            {
                return;
            }
            AlphaValue.Value = AlphaTrack.Value;
        }

        private void ColorCircle_OnColorChanged(object sender, ColorClickedEventArgs e)
        {
            if (_stopPropagation)
            {
                return;
            }
            SelectedColor = Color.FromArgb(SelectedColor.A, e.Color.R, e.Color.G, e.Color.B);
        }

        private void NullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled(NullCheckBox.Checked);
        }

        private void NumControl_ValueChanged(object sender, EventArgs e)
        {
            SelectedColor = Color.FromArgb(
                (int)AlphaValue.Value,
                (int)RedValue.Value,
                (int)GreenValue.Value,
                (int)BlueValue.Value);
            _stopPropagation = true;
            AlphaTrack.Value = (int)AlphaValue.Value;
            _stopPropagation = false;
        }

        /// <summary>
        /// Callback for the nullable checkbox.
        /// </summary>
        /// <param name="on"></param>
        private void SetEnabled(bool on)
        {
            //foreach (Control control in _tableLayout.Controls)
            //{
            //    if (control is CheckBox)
            //    {
            //        continue;
            //    }
            //    control.Visible = on;
            //}
        }

        #endregion

        #region properties

        /// <summary>
        /// Indicates of the null-checkbox is checked.
        /// </summary>
        public bool IsNull => NullCheckBox?.Checked == true;

        /// <summary>
        /// The currently selected color.
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        public Color SelectedColor
        {
            get =>
                Color.FromArgb((int)AlphaValue.Value, (int)RedValue.Value, (int)GreenValue.Value, (int)BlueValue.Value);
            set
            {
                AlphaValue.Value = value.A;
                RedValue.Value = value.R;
                GreenValue.Value = value.G;
                BlueValue.Value = value.B;
                _stopPropagation = true;
                ColorCircle.Color = value;
                _stopPropagation = false;
            }
        }

        #endregion

        //private readonly NumericUpDown AlphaValue;
        //private readonly NumericUpDown BlueValue;
        //private readonly NumericUpDown GreenValue;
        //private readonly CheckBox? _noneCheckBox;
        //private readonly NumericUpDown RedValue;
        //private readonly TableLayoutPanel _tableLayout;
    }
}
