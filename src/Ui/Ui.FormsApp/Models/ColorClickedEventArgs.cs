namespace codingfreaks.obscene.Ui.FormsApp.Models
{
    public class ColorClickedEventArgs
    {
        #region constructors and destructors

        public ColorClickedEventArgs(Color color)
        {
            Color = color;
        }

        #endregion

        #region properties

        public Color Color { get; }

        #endregion
    }
}
