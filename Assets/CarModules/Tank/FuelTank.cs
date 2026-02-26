using UnityEngine;

namespace Virsign
{
    /// <summary>
    /// Бак с топливом
    /// </summary>
    public class FuelTank : MonoBehaviour
    {
        public bool IsEmpty => _isEmpty;
        public float CurrentFuelAmount => _currentFuelAmount;

        [SerializeField] private float fuelCapacity = 10f;

        private bool _isEmpty;
        private float _currentFuelAmount;

        /// <summary>
        /// Инициализировать
        /// </summary>
        public void Initialize()
        {
            _currentFuelAmount = fuelCapacity;
        }

        /// <summary>
        /// Попытаться добавить топливо в бак
        /// </summary>
        /// <param name="amount">Желаемое количество топлива на добавление</param>
        /// <param name="passedFuelAmount">Количество топлива, которое удалось залить</param>
        /// <returns>Весь ли объем amount удалось залить в бак?</returns>
        public bool TryAddFuel(float amount, out float passedFuelAmount)
        {
            _isEmpty = false;

            if (_currentFuelAmount + amount <= fuelCapacity)
            {
                passedFuelAmount = amount;
                return true;
            }

            passedFuelAmount = amount - (fuelCapacity - _currentFuelAmount);
            return false;
        }

        /// <summary>
        /// Попытаться вычесть топливо из бака
        /// </summary>
        /// <param name="fuelAmount">Желаемое количество топлива</param>
        /// <param name="availableAmount">Сколько по итогу удалось забрать топлива из бака</param>
        /// <returns>Весь ли объем amount удалось забрать из бака?</returns>
        public bool TryGetFuel(float fuelAmount, out float availableAmount)
        {
            if (fuelAmount >= _currentFuelAmount)
            {
                _isEmpty = true;
            }

            if (_currentFuelAmount < fuelAmount)
            {
                availableAmount = _currentFuelAmount;
                return false;
            }

            availableAmount = fuelAmount;
            return true;
        }
    }
}