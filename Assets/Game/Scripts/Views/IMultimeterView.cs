using Game.Scripts.Models;

namespace Game.Scripts.Views
{
    /// <summary>
    /// Определяет контракт представления мультиметра
    /// </summary>
    public interface IMultimeterView
    {
        void SetMultimeterData(MultimeterMode mode, double value);
    }
}