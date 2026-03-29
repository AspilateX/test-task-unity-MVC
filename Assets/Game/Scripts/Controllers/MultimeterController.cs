using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    /// <summary>
    /// Базовый контроллер мультиметра, обновляет представление при изменении модели
    /// </summary>
    public class MultimeterController : MonoBehaviour
    {
        protected IMultimeterModel Model { get; private set; }
        protected IMultimeterView View { get; private set; }

        public virtual void Initialize(IMultimeterModel model, IMultimeterView view)
        {
            Model = model;
            View = view;
            Model.ModeChanged += UpdateView;
        }

        protected virtual void OnDestroy()
        {
            if (Model == null)
                return;

            Model.ModeChanged -= UpdateView;
        }

        protected virtual void UpdateView(MultimeterMode mode)
        {
            double value = Model.GetDeviceData(mode);
            View.SetMultimeterData(mode, value);
        }
    }
}
