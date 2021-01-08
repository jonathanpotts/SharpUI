using System.Drawing;

namespace SharpUI
{
    /// <summary>
    /// A view with text and styling.
    /// </summary>
    public class Span : View, ISpan<Span>
    {
        /// <summary>
        /// A model representing metadata used by a view.
        /// </summary>
        public class ViewModel
        {
            /// <summary>
            /// Text to display.
            /// </summary>
            public string Text { get; set; }

            /// <summary>
            /// Font family to use (uses default value if null).
            /// </summary>
            public FontFamily FontFamily { get; set; }

            /// <summary>
            /// Font weight to use (uses default value if null).
            /// </summary>
            public FontWeight? FontWeight { get; set; }

            /// <summary>
            /// Color to use (uses default value if null).
            /// </summary>
            public Color? ForegroundColor { get; set; }

            /// <summary>
            /// Determines if the text is bold.
            /// </summary>
            public bool Bold { get; set; }

            /// <summary>
            /// Determines if the text is italic.
            /// </summary>
            public bool Italic { get; set; }

            /// <summary>
            /// Determines if there is a strikethrough.
            /// </summary>
            public bool Strikethrough { get; set; }

            /// <summary>
            /// Determines if there is an underline.
            /// </summary>
            public bool Underline { get; set; }

            /// <summary>
            /// Letter spacing.
            /// </summary>
            public float LetterSpacing { get; set; }

            /// <summary>
            /// Baseline shift.
            /// </summary>
            public int BaselineShift { get; set; }
        }

        /// <summary>
        /// A model containing metadata used by the view.
        /// </summary>
        public ViewModel Model { get; protected set; }

        /// <summary>
        /// Creates a new span view.
        /// </summary>
        /// <param name="text"></param>
        public Span(string text)
        {
            Model = new ViewModel()
            {
                Text = text
            };
        }

        public Span FontFamily(FontFamily fontFamily)
        {
            Model.FontFamily = fontFamily;

            return this;
        }

        public Span FontWeight(FontWeight? weight)
        {
            Model.FontWeight = weight;

            return this;
        }

        public Span ForegroundColor(Color? color)
        {
            Model.ForegroundColor = color;

            return this;
        }

        public Span Bold()
        {
            Model.Bold = true;

            return this;
        }

        public Span Italic()
        {
            Model.Italic = true;

            return this;
        }

        public Span Strikethrough()
        {
            Model.Strikethrough = true;

            return this;
        }

        public Span Underline()
        {
            Model.Underline = true;

            return this;
        }

        public Span LetterSpacing(float letterSpacing)
        {
            Model.LetterSpacing = letterSpacing;

            return this;
        }

        public Span BaselineShift(int baselineShift)
        {
            Model.BaselineShift = baselineShift;

            return this;
        }
    }
}
