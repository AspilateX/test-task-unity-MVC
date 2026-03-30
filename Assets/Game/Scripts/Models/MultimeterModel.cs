using System;
using System.Collections.Generic;

namespace Game.Scripts.Models
{
    /// <summary>
    /// Стандартная реализация логики работы мультиметра
    /// </summary>
    public class MultimeterModel : IMultimeterModel
    {
        private MultimeterMode _currentMode;
        private Dictionary<MultimeterMode, double> _deviceData;

        public event Action<MultimeterMode> ModeChanged;

        public void SetDevice(IElectricalDevice device)
        {
            _deviceData = CalculateMultimeterDataForDevice(device);
        }

        public double GetDeviceData(MultimeterMode mode)
        {
            if (_deviceData == null || !_deviceData.ContainsKey(mode))
                return 0;

            return _deviceData[mode];
        }

        public void SelectNextMode() => AddStepsToModeSelector(1);

        public void SelectPreviousMode() => AddStepsToModeSelector(-1);

        public void SwitchMode(MultimeterMode mode)
        {
            if (mode == _currentMode)
                return;

            _currentMode = mode;
            ModeChanged?.Invoke(_currentMode);
        }

        private void AddStepsToModeSelector(int amount)
        {
            if (amount == 0)
                return;

            int modesAmount = Enum.GetValues(typeof(MultimeterMode)).Length;
            int newMode = ((int)_currentMode + amount) % modesAmount;

            if (newMode < 0)
                newMode += modesAmount;

            SwitchMode((MultimeterMode)newMode);
        }

        private Dictionary<MultimeterMode, double> CalculateMultimeterDataForDevice(IElectricalDevice device)
        {
            if (device == null)
                return CreateEmptyDeviceData();

            double resistance = Math.Max(device.Resistance, 0d);
            double power = Math.Max(device.Power, 0d);

            double current = resistance > 0d ? Math.Sqrt(power / resistance) : 0d;      // Сила тока I = sqrt(P/R)
            double dcVoltage = resistance > 0d ? Math.Sqrt(power * resistance) : 0d;    // Напряжение постоянного тока U = sqrt(P*R)

            return new Dictionary<MultimeterMode, double>
            {
                { MultimeterMode.Neutral, 0d },
                { MultimeterMode.Resistance, resistance },
                { MultimeterMode.Current, current },
                { MultimeterMode.DCVoltage, dcVoltage },
                { MultimeterMode.ACVoltage, 0.01d },
            };
        }

        private Dictionary<MultimeterMode, double> CreateEmptyDeviceData()
        {
            return new Dictionary<MultimeterMode, double>
            {
                { MultimeterMode.Neutral, 0d },
                { MultimeterMode.Resistance, 0d },
                { MultimeterMode.Current, 0d },
                { MultimeterMode.DCVoltage, 0d },
                { MultimeterMode.ACVoltage, 0d },
            };
        }
    }
}