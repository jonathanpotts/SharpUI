using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpUI
{
    /// <summary>
    /// A font family loaded from font files.
    /// </summary>
    public class FileFontFamily : FontFamily, IEnumerable<string>
    {
        /// <summary>
        /// Paths to font files used for this font family.
        /// </summary>
        protected HashSet<string> paths = new HashSet<string>();

        public IEnumerator<string> GetEnumerator() => paths.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Creates an empty file font family.
        /// </summary>
        public FileFontFamily()
        {
        }

        /// <summary>
        /// Creates a file font family with a single font file.
        /// </summary>
        /// <param name="path">Path to font file. Use forward slash ("/") for the path separator.</param>
        public FileFontFamily(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            paths = new HashSet<string>
            {
                path
            };
        }

        /// <summary>
        /// Adds a font file to the font family.
        /// </summary>
        /// <param name="path">Path to font file. Use forward slash ("/") for the path separator.</param>
        public void Add(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            paths.Add(path);
        }
    }
}
