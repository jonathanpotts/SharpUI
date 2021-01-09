using System.Collections.Generic;
using System.Drawing;

namespace SharpUI
{
    /// <summary>
    /// A view that displays read-only text.
    /// </summary>
    public class Text : View, ISpan<Text>
    {
        /// <summary>
        /// A model describing settings of a text view.
        /// </summary>
        public class Model
        {
            /// <summary>
            /// Default font family.
            /// </summary>
            public FontFamily FontFamily { get; set; }

            /// <summary>
            /// Default font weight.
            /// </summary>
            public FontWeight? FontWeight { get; set; }

            /// <summary>
            /// Maximum number of lines to display (no limit if null).
            /// </summary>
            public int? MaxLines { get; set; }

            /// <summary>
            /// Amount to multiply line height by.
            /// </summary>
            public float LineHeight { get; set; } = 1.0f;

            /// <summary>
            /// Alignment of text.
            /// </summary>
            public TextAlignment TextAlignment { get; set; } = TextAlignment.TextStart;

            /// <summary>
            /// Determines if right-to-left layout direction is used.
            /// </summary>
            public bool RtlLayoutDirection { get; set; } = false;
        }

        /// <summary>
        /// Settings applied to this text view.
        /// </summary>
        public Model Settings { get; set; }

        /// <summary>
        /// Creates a view that displays read-only text.
        /// </summary>
        public Text()
        {
        }

        /// <summary>
        /// Creates a view that displays read-only text.
        /// </summary>
        /// <param name="text">Text to display.</param>
        public Text(string text)
        {
            Body = new List<View>
            {
                new Span(text)
            };
        }

        public Text FontFamily(FontFamily fontFamily)
        {
            if (Settings == null)
            {
                Settings = new Model();
            }

            Settings.FontFamily = fontFamily;

            return this;
        }

        public Text FontWeight(FontWeight? weight)
        {
            if (Settings == null)
            {
                Settings = new Model();
            }

            Settings.FontWeight = weight;

            return this;
        }

        public Text ForegroundColor(Color? color)
        {
            ForEach<Span>(span => span.ForegroundColor(color));

            return this;
        }

        public Text Bold()
        {
            ForEach<Span>(span => span.Bold());

            return this;
        }

        public Text Italic()
        {
            ForEach<Span>(span => span.Italic());

            return this;
        }

        public Text Strikethrough()
        {
            ForEach<Span>(span => span.Strikethrough());

            return this;
        }

        public Text Underline()
        {
            ForEach<Span>(span => span.Underline());

            return this;
        }

        public Text LetterSpacing(float letterSpacing)
        {
            ForEach<Span>(span => span.LetterSpacing(letterSpacing));

            return this;
        }

        public Text BaselineShift(int baselineShift)
        {
            ForEach<Span>(span => span.BaselineShift(baselineShift));

            return this;
        }

        /// <summary>
        /// Sets the maximum number of lines that can be displayed by this view.
        /// </summary>
        /// <param name="number">Maximum number of lines to display. If null, then no limit is placed.</param>
        /// <returns>Updated view.</returns>
        public Text MaxLines(int? number)
        {
            if (Settings == null)
            {
                Settings = new Model();
            }

            Settings.MaxLines = number;

            return this;
        }

        /// <summary>
        /// Sets the amount to multiply line height by in this view.
        /// </summary>
        /// <param name="lineHeight">Amount to multiply line height by.</param>
        /// <returns></returns>
        public Text LineHeight(float lineHeight)
        {
            if (Settings == null)
            {
                Settings = new Model();
            }

            Settings.LineHeight = lineHeight;

            return this;
        }

        /// <summary>
        /// Sets the alignment for text displayed in this view.
        /// </summary>
        /// <param name="alignment">Alignment to use.</param>
        /// <returns>Updated view.</returns>
        public Text TextAlignment(TextAlignment alignment)
        {
            if (Settings == null)
            {
                Settings = new Model();
            }

            Settings.TextAlignment = alignment;

            return this;
        }

        /// <summary>
        /// Sets if the layout direction should be right-to-left.
        /// </summary>
        /// <returns>Updated view.</returns>
        public Text RtlLayoutDirection()
        {
            if (Settings == null)
            {
                Settings = new Model();
            }

            Settings.RtlLayoutDirection = true;

            return this;
        }
    }
}
