using Android.Content;
using System;
using System.Linq;
using System.Reflection;

namespace SharpUI.Android
{
    /// <summary>
    /// A native view.
    /// </summary>
    public abstract class NativeView
    {
        /// <summary>
        /// The Android view configured from the view.
        /// </summary>
        public global::Android.Views.View View { get; protected set; }

        /// <summary>
        /// Creates a view runtime for the provided view.
        /// </summary>
        /// <param name="context">Android app context.</param>
        /// <param name="view">View to use.</param>
        /// <returns></returns>
        public static NativeView Create(Context context, View view)
        {
            var baseType = typeof(NativeView<>).MakeGenericType(view.GetType());

            var runtimeType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => baseType.IsAssignableFrom(t))
                .FirstOrDefault();

            if (runtimeType == null)
            {
                throw new NotImplementedException();
            }

            var runtime = (NativeView)Activator.CreateInstance(runtimeType, true);
            runtime.Configure(context, view);

            return runtime;
        }

        /// <summary>
        /// Configures the view runtime with the provided view.
        /// </summary>
        /// <param name="context">Android app context.</param>
        /// <param name="view">View to use.</param>
        protected abstract void Configure(Context context, View view);
    }

    /// <summary>
    /// A native view for the specified view type.
    /// </summary>
    /// <typeparam name="T">View type.</typeparam>
    public abstract class NativeView<T> : NativeView where T : View
    {
        /// <summary>
        /// Creates an un-configured view runtime.
        /// </summary>
        protected NativeView()
        {
        }

        protected override void Configure(Context context, View view)
        {
            Configure(context, (T)view);
        }

        /// <summary>
        /// Configures the view runtime with the provided view.
        /// </summary>
        /// <param name="context">Android app context.</param>
        /// <param name="view">View to use.</param>
        protected abstract void Configure(Context context, T view);
    }
}
