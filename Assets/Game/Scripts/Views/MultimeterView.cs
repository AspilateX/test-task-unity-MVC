using Game.Scripts.Models;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Views
{
    /// <summary>
    /// Представление мультиметра с возможностью отображения текущего режима работы и вывода значения на экран
    /// </summary>
    public class MultimeterView : BaseMultimeterView
    {
        private Dictionary<MultimeterMode, float> _knobModesRotation = new();

        [SerializeField]
        private Transform _rotationTarget;

        [SerializeField]
        private TextMeshProUGUI _screenText;

        [SerializeField]
        [FormerlySerializedAs("_serializableRotationMap")]
        private MultimeterRotationMap[] _knobRotationMap;

        public override void SetMultimeterData(MultimeterMode newMode, double newValue)
        {
            float rotation = 0f;

            if (_knobModesRotation.ContainsKey(newMode))
                rotation = _knobModesRotation[newMode];
    
            SetRotation(rotation);
            UpdateScreenText(newValue);
        }

        private void Awake()
        {
            foreach (var rotationEntry in _knobRotationMap)
                _knobModesRotation.Add(rotationEntry.Mode, rotationEntry.Rotation);
        }

        private void SetRotation(float newRotation) => _rotationTarget.localRotation = Quaternion.Euler(0, 0, newRotation);

        private void UpdateScreenText(double newValue)
        {
            _screenText.text = Math.Round(newValue, 2).ToString();
        }
    }
}