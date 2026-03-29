using UnityEngine;
using Game.Scripts.Controllers;
using Game.Scripts.Models;
using Game.Scripts.Views;
using System;

namespace Game.Scripts.Systems.Infrastructure
{
    /// <summary>
    /// Простая система бинда модели к ее контроллеру и представлению на сцене
    /// </summary>
    public class MultimeterBinder : MonoBehaviour
    {
        [SerializeField]
        private MultimeterController _controller;

        [SerializeField]
        private BaseMultimeterView _view;

        /// <summary>
        /// Биндит модель к контроллеру и предсталению на сцене
        /// </summary>
        /// <param name="model">Целевая модель</param>
        /// <exception cref="MissingReferenceException"></exception>
        public void Bind(IMultimeterModel model)
        {
            if (_controller == null)
                throw new MissingReferenceException("Controller is not set");

            if (_view == null)
                throw new MissingReferenceException("View is not set");

            _controller.Initialize(model, _view);
        }
    }
}