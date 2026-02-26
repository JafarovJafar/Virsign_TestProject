using System;

namespace Virsign
{
    public class EventField<T>
    {
        public event Action<T> ValueChanged;

        public T Value => _value;

        private T _value;

        public EventField(T initialValue = default)
        {
            _value = initialValue;
        }

        public void SetValue(T newValue)
        {
            if (Equals(_value, newValue))
            {
                return;
            }

            _value = newValue;
            ValueChanged?.Invoke(_value);
        }
    }
}