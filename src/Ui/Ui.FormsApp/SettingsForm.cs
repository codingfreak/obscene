namespace codingfreaks.obscene.Ui.FormsApp
{
    using Logic.Abstracts.Models;
    using Logic.Core;

    public partial class SettingsForm : Form
    {
        #region member vars

        private AppConfig? _config;

        #endregion

        #region constructors and destructors

        public SettingsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        private async void OkButton_Click(object sender, EventArgs e)
        {
            _config!.SettingsPath = SettingsFolderText.Text;
            _config.ObsPort = (int)ObsPortNumeric.Value;
            _config.ObsPassword = ObsPasswordText.Text;
            await Settings.SaveConfigAsync(_config);
        }

        private void SettingsFolderButton_Click(object sender, EventArgs e)
        {
            FolderDialog.InitialDirectory = SettingsFolderText.Text;
            var result = FolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SettingsFolderText.Text = FolderDialog.SelectedPath;
            }
        }

        private void OnControlValueChanged(object sender, EventArgs e)
        {
            var pathOk = Directory.Exists(SettingsFolderText.Text);
            var ok = pathOk  && ObsPasswordText.TextLength > 0;
            SettingsFolderText.ForeColor = pathOk ? ForeColor : Color.Red;
            OkButton.Enabled = ok;
        }

        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            _config = await Settings.LoadConfigAsync();
            SettingsFolderText.Text = _config.SettingsPath;
            ObsPortNumeric.Value = _config.ObsPort;
            ObsPasswordText.Text = _config.ObsPassword;
        }

        #endregion
    }
}
