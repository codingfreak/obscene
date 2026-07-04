namespace codingfreaks.obscene.Ui.FormsApp.Models
{
    using Logic.Abstracts.Interfaces;
    using Logic.WinApi.Models;

    internal class GeometryListItem
    {
        #region properties

        public string Label { get; set; } = null!;

        public IGeometry Data { get; set; } = null!;

        #endregion
    }
}
