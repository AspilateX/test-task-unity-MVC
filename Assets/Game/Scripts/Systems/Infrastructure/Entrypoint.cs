using UnityEngine;
using UnityEngine.Serialization;
using Game.Scripts.Models;
using Game.Scripts.Views;
using Game.Scripts.Controllers;

namespace Game.Scripts.Systems.Infrastructure
{
    /// <summary>
    /// Точка входа в игровой цикл
    /// </summary>
    public class Entrypoint : MonoBehaviour
    {
        [SerializeField]
        private ElectricalDevice _targetDevice;

        [SerializeField]
        private MultimeterBinder[] _binders;

        private void Awake()
        {
            // Создаем и внедряем нашу модель, простая реализация DI
            var model = new MultimeterModel();

            foreach (var binder in _binders) 
                binder.Bind(model);

            // Устанавливаем тестовый девайс
            model.SetDevice(_targetDevice);
        }
    }
}
