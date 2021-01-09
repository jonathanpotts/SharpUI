using System.Drawing;

namespace SharpUI
{
    /// <summary>
    /// An interface that spans must inherit that contains styling methods.
    /// </summary>
    /// <typeparam name="T">Span view type.</typeparam>
    public interface ISpan<T> where T : View, ISpan<T>
    {
        /// <summary>
        /// Sets the font family for text in this view.
        /// </summary>
        /// <remarks>Does nothing on Android 8.1 or older.</remarks>
        /// <param name="fontFamily">Font family to use. If null, then the default font family is used.</param>
        /// <returns>Updated view.</returns>
        T FontFamily(FontFamily fontFamily);

        /// <summary>
        /// Sets the font weight for text in this view.
        /// </summary>
        /// <remarks>Does nothing on Android 8.1 or older.</remarks>
        /// <param name="weight">Font weight to use. If null, then the default font weight is used.</param>
        /// <returns>Updated view.</returns>
        T FontWeight(FontWeight? weight);

        /// <summary>
        /// Sets the foreground color for text in this view.
        /// </summary>
        /// <param name="color">Color to use. If null, then the default foreground color is used.</param>
        /// <returns>Updated view.</returns>
        T ForegroundColor(Color? color);

        /// <summary>
        /// Makes the text bold in this view.
        /// </summary>
        /// <returns>Updated view.</returns>
        T Bold();

        /// <summary>
        /// Makes the text italic in this view.
        /// </summary>
        /// <returns>Updated view.</returns>
        T Italic();

        /// <summary>
        /// Adds a strikethrough to text in this view.
        /// </summary>
        /// <returns>Updated view.</returns>
        T Strikethrough();

        /// <summary>
        /// Adds an underline to text in this view.
        /// </summary>
        /// <returns>Updated view.</returns>
        T Underline();

        /// <summary>
        /// Sets the letter spacing for text in this view.
        /// </summary>
        /// <param name="letterSpacing">Letter spacing.</param>
        /// <returns>Updated view.</returns>
        T LetterSpacing(float letterSpacing);

        /// <summary>
        /// Sets the baseline shift for text in this view.
        /// </summary>
        /// <param name="baselineShift">Baseline shift.</param>
        /// <returns>Updated view.</returns>
        T BaselineShift(int baselineShift);
    }
}
