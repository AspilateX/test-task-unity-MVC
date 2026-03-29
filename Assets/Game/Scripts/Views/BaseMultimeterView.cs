using UnityEngine;
using Game.Scripts.Models;

namespace Game.Scripts.Views
{
    /// <summary>
    /// Mono реализация базового класса для представления мультиметра
    /// </summary>
    public abstract class BaseMultimeterView : MonoBehaviour, IMultimeterView
    {
        public abstract void SetMultimeterData(MultimeterMode mode, double value);
    }
}