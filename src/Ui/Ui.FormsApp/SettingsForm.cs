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

        private void SettingsFolderText_TextChanged(object sender, EventArgs e)
        {
            var ok = Directory.Exists(SettingsFolderText.Text);
            SettingsFolderText.ForeColor = ok ? ForeColor : Color.Red;
            OkButton.Enabled = ok;
        }

        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            _config = await Settings.LoadConfigAsync();
            SettingsFolderText.Text = _config.SettingsPath;
        }

        #endregion
    }
}
