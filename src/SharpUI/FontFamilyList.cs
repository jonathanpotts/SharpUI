using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpUI
{
    /// <summary>
    /// A list of font families. The first available font family in the list will be chosen. If no font families in the list are available, the default is used.
    /// </summary>
    public class FontFamilyList : FontFamily, IEnumerable<FontFamily>
    {
        /// <summary>
        /// List of font families.
        /// </summary>
        protected List<FontFamily> fontFamilies = new List<FontFamily>();

        public IEnumerator<FontFamily> GetEnumerator() => fontFamilies.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Adds a font family to the list. Once a generic font family has been added, no other font families can be added.
        /// </summary>
        /// <param name="fontFamily">Font family to add.</param>
        public void Add(FontFamily fontFamily)
        {
            if (fontFamily == null)
            {
                throw new ArgumentNullException(nameof(fontFamily));
            }

            if (fontFamily is FontFamilyList)
            {
                throw new ArgumentException($"A {nameof(FontFamilyList)} cannot be added to the list.", nameof(fontFamily));
            }

            if (fontFamilies.LastOrDefault() is GenericFontFamily)
            {
                throw new ArgumentException($"A font family cannot be added after a {nameof(GenericFontFamily)}.", nameof(fontFamily));
            }

            fontFamilies.Add(fontFamily);
        }

        /// <summary>
        /// Gets the font family at the requested index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>Font family.</returns>
        public FontFamily this[int index] => fontFamilies[index];
    }
}
