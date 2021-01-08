namespace SharpUI
{
    /// <summary>
    /// A font family describes the typeface used for text. If the font family is not available, the default is used.
    /// </summary>
    public abstract class FontFamily
    {
        /// <summary>
        /// Sans-serif generic font family.
        /// </summary>
        public static readonly GenericFontFamily SansSerif = new GenericFontFamily() { Name = "sans-serif" };

        /// <summary>
        /// Serif generic font family.
        /// </summary>
        public static readonly GenericFontFamily Serif = new GenericFontFamily() { Name = "serif" };

        /// <summary>
        /// Monospace (fixed-width character) generic font family.
        /// </summary>
        public static readonly GenericFontFamily Monospace = new GenericFontFamily() { Name = "monospace" };

        /// <summary>
        /// Default font family.
        /// </summary>
        public static readonly GenericFontFamily Default = SansSerif;
    }
}
