namespace codingfreaks.obscene.Logic.Core.Extensions
{
    using System.Drawing;

    /// <summary>
    /// Provides extension methods for the type <see cref="Color" />.
    /// </summary>
    internal static class ColorExtensions
    {
        #region methods

        /// <summary>
        /// Creates a new color instance based on the values of the <paramref name="original" />.
        /// </summary>
        /// <param name="original">The instance to take the values from.</param>
        /// <returns>The copy instance or <c>null</c> if the <paramref name="original" /> was <c>null</c>.</returns>
        public static Color? CreateCopy(this Color? original)
        {
            if (original == null)
            {
                return null;
            }
            return Color.FromArgb(original.Value.A, original.Value.R, original.Value.G, original.Value.B);
        }

        /// <summary>
        /// Creates a new color instance based on the values of the <paramref name="original" />.
        /// </summary>
        /// <param name="original">The instance to take the values from.</param>
        /// <returns>The copy instance.</returns>
        public static Color CreateCopy(this Color original)
        {
            return Color.FromArgb(original.A, original.R, original.G, original.B);
        }

        #endregion
    }
}
