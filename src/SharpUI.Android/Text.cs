using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using System;
using System.Linq;

namespace SharpUI.Android
{
    /// <summary>
    /// A native view for a text view.
    /// </summary>
    public class Text : NativeView<SharpUI.Text>
    {
        protected override void Configure(Context context, SharpUI.Text view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            using var builder = new SpannableStringBuilder();

            static void SetSpan(ISpannable spannable, Java.Lang.Object what) => spannable.SetSpan(what, 0, spannable.Length(), SpanTypes.ExclusiveExclusive);

            foreach (var span in view.Body?.OfType<Span>() ?? Enumerable.Empty<Span>())
            {
                using var spannableString = new SpannableString(span.Model.Text);

                // Set font family and weight (only supported on Android 9 or newer)
                if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                {
                    Typeface typeface = null;

                    if (span.Model.FontFamily != null)
                    {
                        typeface = TypefaceManager.Get(context, span.Model.FontFamily);
                    }

                    if (span.Model.FontWeight.HasValue)
                    {
                        if (typeface == null)
                        {
                            typeface = TypefaceManager.Get(context, view.Settings.FontFamily);
                        }

                        typeface = Typeface.Create(typeface, (int)span.Model.FontWeight, false);
                    }

                    if (typeface != null)
                    {
                        SetSpan(spannableString, new TypefaceSpan(typeface));
                    }
                }

                // Set foreground color
                if (span.Model.ForegroundColor.HasValue)
                {
                    var color = new Color(span.Model.ForegroundColor.Value.ToArgb());
                    SetSpan(spannableString, new ForegroundColorSpan(color));
                }

                // Set bold, italic, or both
                if (span.Model.Bold && span.Model.Italic)
                {
                    SetSpan(spannableString, new StyleSpan(TypefaceStyle.BoldItalic));
                }
                else if (span.Model.Bold)
                {
                    SetSpan(spannableString, new StyleSpan(TypefaceStyle.Bold));
                }
                else if (span.Model.Italic)
                {
                    SetSpan(spannableString, new StyleSpan(TypefaceStyle.Italic));
                }

                // Set strikethrough
                if (span.Model.Strikethrough)
                {
                    SetSpan(spannableString, new StrikethroughSpan());
                }

                // Set underline
                if (span.Model.Underline)
                {
                    SetSpan(spannableString, new UnderlineSpan());
                }

                // Set letter spacing
                SetSpan(spannableString, new LetterSpacingSpan(span.Model.LetterSpacing));

                // Set baseline offset
                SetSpan(spannableString, new BaselineShiftSpan(span.Model.BaselineShift));

                builder.Append(spannableString);
            }

            var textView = new TextView(context);
            textView.SetText(builder, TextView.BufferType.Spannable);

            if (view.Settings != null)
            {
                Typeface typeface = null;

                if (view.Settings.FontFamily != null)
                {
                    typeface = TypefaceManager.Get(context, view.Settings.FontFamily);
                }

                if (view.Settings.FontWeight.HasValue)
                {
                    if (typeface == null)
                    {
                        typeface = TypefaceManager.Get(context, null);
                    }

                    typeface = Typeface.Create(typeface, (int)view.Settings.FontWeight, false);
                }

                if (typeface != null)
                {
                    textView.Typeface = typeface;
                }

                // Set max lines
                if (view.Settings.MaxLines.HasValue)
                {
                    textView.SetMaxLines(view.Settings.MaxLines.Value);
                }

                // Set line height
                textView.SetLineSpacing(0, view.Settings.LineHeight);

                // Set text alignment
                textView.TextAlignment = view.Settings.TextAlignment switch
                {
                    TextAlignment.Center => global::Android.Views.TextAlignment.Center,
                    TextAlignment.TextStart => global::Android.Views.TextAlignment.TextStart,
                    TextAlignment.TextEnd => global::Android.Views.TextAlignment.TextEnd,
                    _ => throw new NotImplementedException()
                };

                // Set right-to-left layout direction
                if (view.Settings.RtlLayoutDirection)
                {
                    textView.LayoutDirection = LayoutDirection.Rtl;
                }
            }

            View = textView;
        }
    }
}
