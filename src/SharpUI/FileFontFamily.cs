namespace SharpUI
{
    /// <summary>
    /// A font family loaded from a font file.
    /// </summary>
    public class FileFontFamily : FontFamily
    {
        /// <summary>
        /// Font file used for this font family.
        /// </summary>
        public string File { get; protected set; }

        /// <summary>
        /// Creates a file font family.
        /// </summary>
        /// <param name="file">Font file to use.</param>
        public FileFontFamily(string file)
        {
            File = file;
        }
    }
}
