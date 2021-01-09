using Android.Content;
using Android.Graphics;
using AndroidX.Core.Content.Resources;
using Java.Lang;
using System.Collections.Generic;
using System.Linq;

namespace SharpUI.Android
{
    /// <summary>
    /// Provides an efficient way to reference typefaces created from font families.
    /// </summary>
    public static class TypefaceManager
    {
        /// <summary>
        /// A cache of generated typefaces.
        /// </summary>
        private static readonly Dictionary<FontFamily, Typeface> s_typefaces = new Dictionary<FontFamily, Typeface>();

        /// <summary>
        /// Gets a typeface from a font family.
        /// </summary>
        /// <param name="fontFamily">Font family.</param>
        /// <returns>Typeface.</returns>
        public static Typeface Get(Context context, FontFamily fontFamily)
        {
            if (fontFamily == null)
            {
                return GetGenericTypeface(FontFamily.Default);
            }

            if (s_typefaces.TryGetValue(fontFamily, out var cachedTypeface))
            {
                return cachedTypeface;
            }

            static Typeface GetGenericTypeface(GenericFontFamily genericFontFamily)
            {
                if (genericFontFamily == FontFamily.SansSerif)
                {
                    return Typeface.SansSerif;
                }
                else if (genericFontFamily == FontFamily.Serif)
                {
                    return Typeface.Serif;
                }
                else if (genericFontFamily == FontFamily.Monospace)
                {
                    return Typeface.Monospace;
                }
                else
                {
                    return Typeface.Default;
                }
            }

            Typeface LoadFileFontFamilyTypeface(FileFontFamily fileFontFamily)
            {
                try
                {
                    var fontId = context.Resources.GetIdentifier(
                        System.IO.Path.GetFileNameWithoutExtension(fileFontFamily.File).Replace('.', '_').ToLower(),
                        "font", context.PackageName);

                    return ResourcesCompat.GetFont(context, fontId);
                }
                catch (Exception ex)
                {
                    throw new System.IO.IOException("Failed to load the file font family. Ensure that it is provided in the package's resources.", ex);
                }
            }

            Typeface typeface = null;

            if (fontFamily is FontFamilyList fontFamilyList)
            {
                fontFamily = fontFamilyList.FirstOrDefault(x => x is FileFontFamily || x is GenericFontFamily);
            }

            if (fontFamily == null)
            {
                typeface = GetGenericTypeface(FontFamily.Default);
            }
            else if (fontFamily is FileFontFamily fileFontFamily)
            {
                typeface = LoadFileFontFamilyTypeface(fileFontFamily);
            }
            else if (fontFamily is GenericFontFamily genericFontFamily)
            {
                typeface = GetGenericTypeface(genericFontFamily);
            }

            s_typefaces.Add(fontFamily, typeface);
            return typeface;
        }
    }
}
