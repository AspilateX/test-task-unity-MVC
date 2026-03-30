using System;

namespace Game.Scripts.Models
{
    /// <summary>
    /// Определяет контракт для модели мультиметра
    /// </summary>
    public interface IMultimeterModel
    {
        event Action<MultimeterMode> ModeChanged;

        double GetDeviceData(MultimeterMode mode);

        void SelectNextMode();

        void SelectPreviousMode();

        void SetDevice(IElectricalDevice device);

        void SwitchMode(MultimeterMode mode);
    }
}