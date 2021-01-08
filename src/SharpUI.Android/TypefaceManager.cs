using Android.Content;
using Android.Graphics;
using Android.Graphics.Fonts;
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

                return null;
            }

            if (fontFamily == null)
            {
                return GetGenericTypeface(FontFamily.Default);
            }

            if (s_typefaces.TryGetValue(fontFamily, out var cachedTypeface))
            {
                return cachedTypeface;
            }

            global::Android.Graphics.Fonts.FontFamily LoadFontFamily(FileFontFamily fileFontFamily)
            {
                global::Android.Graphics.Fonts.FontFamily.Builder builder = null;

                foreach (var path in fileFontFamily)
                {
                    try
                    {
                        if (builder == null)
                        {
                            builder = new global::Android.Graphics.Fonts.FontFamily.Builder(new Font.Builder(context.Assets, path).Build());
                        }
                        else
                        {
                            builder.AddFont(new Font.Builder(context.Assets, path).Build());
                        }
                    }
                    catch (Java.IO.IOException ex)
                    {
                        throw new System.IO.IOException("The font file could not be loaded. Make sure it is in the Assets folder.", ex);
                    }
                }

                return builder.Build();
            }

            Typeface typeface = null;

            if (fontFamily is FontFamilyList fontFamilyList)
            {
                Typeface.CustomFallbackBuilder builder = null;

                foreach (var family in fontFamilyList)
                {
                    if (family is FileFontFamily fileFamily)
                    {
                        if (builder == null)
                        {
                            builder = new Typeface.CustomFallbackBuilder(LoadFontFamily(fileFamily));
                        }
                        else
                        {
                            builder.AddCustomFallback(LoadFontFamily(fileFamily));
                        }
                    }
                    else if (family is GenericFontFamily genericFamily)
                    {
                        if (builder == null)
                        {
                            typeface = GetGenericTypeface(genericFamily) ?? GetGenericTypeface(FontFamily.Default);
                            break;
                        }

                        if (genericFamily == FontFamily.SansSerif || genericFamily == FontFamily.Serif || genericFamily == FontFamily.Monospace)
                        {
                            builder.SetSystemFallback(genericFamily.Name);
                        }
                        else
                        {
                            builder.SetSystemFallback(FontFamily.Default.Name);
                        }
                    }
                }

                if (builder == null)
                {
                    if (typeface == null)
                    {
                        typeface = GetGenericTypeface(FontFamily.Default);
                    }
                }
                else
                {
                    if (!fontFamilyList.OfType<GenericFontFamily>().Any())
                    {
                        builder.SetSystemFallback(FontFamily.Default.Name);
                    }

                    typeface = builder.Build();
                }
            }
            else if (fontFamily is FileFontFamily fileFontFamily)
            {
                typeface = new Typeface.CustomFallbackBuilder(LoadFontFamily(fileFontFamily))
                    .SetSystemFallback(FontFamily.Default.Name)
                    .Build();
            }
            else if (fontFamily is GenericFontFamily genericFontFamily)
            {
                typeface = GetGenericTypeface(genericFontFamily) ?? GetGenericTypeface(FontFamily.Default);
            }

            typeface ??= GetGenericTypeface(FontFamily.Default);

            s_typefaces.Add(fontFamily, typeface);

            return typeface;
        }
    }
}
