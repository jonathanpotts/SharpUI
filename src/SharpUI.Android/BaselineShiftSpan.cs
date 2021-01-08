using Android.Text;
using Android.Text.Style;

namespace SharpUI.Android
{
    /// <summary>
    /// Span for setting baseline shift.
    /// </summary>
    public class BaselineShiftSpan : MetricAffectingSpan
    {
        /// <summary>
        /// Amount to shift text from the baseline.
        /// </summary>
        public int BaselineShift { get; set; }

        /// <summary>
        /// Creates a baseline shift span.
        /// </summary>
        /// <param name="baselineShift">Amount to shift text from the baseline.</param>
        public BaselineShiftSpan(int baselineShift)
        {
            BaselineShift = baselineShift;
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
        /// Applies the baseline shift to the span when updated.
        /// </summary>
        /// <param name="tp"><see cref="TextPaint"/> to apply the baseline shift to.</param>
        private void Apply(TextPaint tp)
        {
            tp.BaselineShift = BaselineShift;
        }
    }
}