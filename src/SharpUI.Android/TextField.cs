using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SharpUI.Android
{
    public class TextField : NativeView<SharpUI.TextField>
    {
        protected override void Configure(Context context, SharpUI.TextField view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            var textFieldView = new EditText(context);

            View = textFieldView;
        }
    }
}
