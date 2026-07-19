namespace codingfreaks.obscene.Ui.FormsApp.Models
{
    using Logic.Abstracts.Interfaces;

    /// <summary>
    /// Is used as the model in the UI lists of geometries.
    /// </summary>
    internal class GeometryListItem
    {
        #region properties

        /// <summary>
        /// The display label.
        /// </summary>
        public string Label { get; set; } = null!;

        /// <summary>
        /// The actual geometry data.
        /// </summary>
        public IGeometry Data { get; set; } = null!;

        #endregion
    }
}
