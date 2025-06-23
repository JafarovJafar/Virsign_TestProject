using System;

namespace Virsign
{
    public class EventField<T>
    {
        private T _value;

        public event Action<T> OnValueChanged;

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
            OnValueChanged?.Invoke(_value);
        }

        public T GetValue()
        {
            return _value;
        }
    }
}