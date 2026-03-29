using System;

namespace Game.Scripts.Models
{
    /// <summary>
    /// Определяет контракт для модели мультиметра
    /// </summary>
    public interface IMultimeterModel
    {
        event Action<MultimeterMode> ModeChanged;

        void SetDevice(IElectricalDevice device);

        double GetDeviceData(MultimeterMode mode);

        void SelectNextMode();

        void SelectPreviousMode();

        void SwitchMode(MultimeterMode mode);
    }
}