using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SharpUI
{
    /// <summary>
    /// Data state store that fires an event on value changes.
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public class State<T> : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Method used to evaluate value.
        /// </summary>
        private readonly Func<T> _evaluator;

        public T Value { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Data state stores found within the evaluator.
        /// </summary>
        private readonly List<INotifyPropertyChanged> _evaluatorStates;

        /// <summary>
        /// Creates a data state store initialized with the provided evaluator method.
        /// </summary>
        /// <param name="evaluator">Method used to evaluate the value</param>
        public State(Func<T> evaluator)
        {
            _evaluator = evaluator ?? throw new ArgumentNullException(nameof(evaluator));
            Value = _evaluator();

            var target = evaluator.Target;
            _evaluatorStates = target.GetType().GetRuntimeFields()
                .Where(f =>
                    f.FieldType.IsGenericType
                    && f.FieldType.GetGenericTypeDefinition() == typeof(State<>)
                    )
                .Select(f => f.GetValue(target))
                .Cast<INotifyPropertyChanged>()
                .Distinct()
                .ToList();

            foreach (var state in _evaluatorStates)
            {
                state.PropertyChanged += OnPropertyChanged;
            }
        }

        /// <summary>
        /// Creates a data state store initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value</param>
        public State(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
            _evaluator = () => value;
        }

        /// <summary>
        /// Handles PropertyChanged events from data state stores in the evaluator.
        /// </summary>
        /// <param name="sender">Object that the event fired from</param>
        /// <param name="args">Event arguments</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        public void Dispose()
        {
            if (_evaluatorStates?.Count > 0)
            {
                foreach (var state in _evaluatorStates)
                {
                    state.PropertyChanged -= OnPropertyChanged;
                }
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator State<T>(Func<T> evaluator)
        {
            return new State<T>(evaluator);
        }

        public static implicit operator State<T>(T value)
        {
            return new State<T>(value);
        }
    }
}
