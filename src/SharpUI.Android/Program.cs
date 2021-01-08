using Android.Content;
using System.Linq;

namespace SharpUI.Android
{
    /// <summary>
    /// Handles basic program operations for an Android app.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Gets a native view for the provided view.
        /// </summary>
        /// <param name="context">Android app context.</param>
        /// <param name="view">View.</param>
        /// <returns>Native view.</returns>
        public static global::Android.Views.View GetNativeView(Context context, View view)
        {
            foreach (var contentView in view?.Body ?? Enumerable.Empty<View>())
            {
                return NativeView.Create(context, contentView).View;
            }

            return null;
        }
    }
}
