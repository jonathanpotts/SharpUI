namespace SharpUI
{
    /// <summary>
    /// A system-provided generic font family.
    /// </summary>
    public class GenericFontFamily : FontFamily
    {
        /// <summary>
        /// Name of the generic font.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Creates a generic font family.
        /// </summary>
        internal GenericFontFamily()
        {
        }
    }
}
