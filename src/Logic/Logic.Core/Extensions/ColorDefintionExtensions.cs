namespace codingfreaks.obscene.Logic.Core.Extensions
{
    using System.Drawing;

    using Abstracts.Models;

    public static class ColorDefintionExtensions
    {
        #region methods

        public static Color ToColor(this ColorDefinition colorDef)
        {
            return Color.FromArgb(colorDef.A, colorDef.R, colorDef.G, colorDef.B);
        }

        #endregion
    }
}
