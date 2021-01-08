using Android.Text;
using Android.Text.Style;
using AndroidX.Annotations;

namespace SharpUI.Android
{
    // Based on: https://stackoverflow.com/a/28605976
    /// <summary>
    /// Span for setting letter spacing.
    /// </summary>
    [RequiresApi(Value = 21)]
    public class LetterSpacingSpan : MetricAffectingSpan
    {
        /// <summary>
        /// Letter spacing to apply to the span.
        /// </summary>
        public float LetterSpacing { get; set; }

        /// <summary>
        /// Creates a letter spacing span.
        /// </summary>
        /// <param name="letterSpacing">Letter spacing to apply to the span.</param>
        public LetterSpacingSpan(float letterSpacing)
        {
            LetterSpacing = letterSpacing;
        }

        public override void UpdateDrawState(TextPaint tp)
        {
            Apply(tp);
        }

        public override void UpdateMeasureState(TextPaint textPaint)
        {
            Apply(textPaint);
        }

        /// <summary>
        /// Applies the letter spacing to the span when updated.
        /// </summary>
        /// <param name="tp"><see cref="TextPaint"/> to apply the letter spacing to.</param>
        private void Apply(TextPaint tp)
        {
            tp.LetterSpacing = LetterSpacing;
        }
    }
}