namespace SharpUI
{
    /// <summary>
    /// A font family installed on the user's system. These are ignored on Android.
    /// </summary>
    public class SystemFontFamily : FontFamily
    {
        /// <summary>
        /// Name of the font. If the system does not have the font installed, it is bypassed.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Creates a system font family.
        /// </summary>
        /// <param name="name">Name of the font.</param>
        public SystemFontFamily(string name)
        {
            Name = name;
        }
    }
}
