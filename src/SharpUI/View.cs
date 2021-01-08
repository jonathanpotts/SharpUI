using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpUI
{
    /// <summary>
    /// A building block used to create a user interface.
    /// </summary>
    public class View : IEnumerable<View>
    {
        /// <summary>
        /// Views contained within this view.
        /// </summary>
        public List<View> Body { get; protected set; } = new List<View>();

        public IEnumerator<View> GetEnumerator() => Body.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Body.GetEnumerator();

        /// <summary>
        /// Adds a view to this view.
        /// </summary>
        /// <param name="view">View to add.</param>
        public void Add(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            Body.Add(view);
        }

        /// <summary>
        /// Gets the view at the requested index.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>View.</returns>
        public View this[int index] => Body[index];

        /// <summary>
        /// Iterates through all views of specified type in the body and performs an action on each.
        /// </summary>
        /// <typeparam name="T">View type.</typeparam>
        /// <param name="action">Action to perform.</param>
        protected void ForEach<T>(Action<T> action) where T : View
        {
            if (action == null)
            {
                return;
            }

            foreach (var view in Body.OfType<T>())
            {
                action.Invoke(view);
            }
        }
    }
}
