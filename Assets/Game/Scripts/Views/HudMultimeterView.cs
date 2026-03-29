using TMPro;
using UnityEngine;
using Game.Scripts.Models;
using System;

namespace Game.Scripts.Views
{
    /// <summary>
    /// Представление мультиметра в пользовательском интерфейсе
    /// </summary>
    public class HudMultimeterView : BaseMultimeterView
    {
        [SerializeField]
        private TextMeshProUGUI _valuesText;

        public override void SetMultimeterData(MultimeterMode mode, double value)
        {
            value = Math.Round(value, 2);

            double dcVoltage = mode == MultimeterMode.DCVoltage ? value : 0;
            double current = mode == MultimeterMode.Current ? value : 0;
            double acVoltage = mode == MultimeterMode.ACVoltage ? value : 0;
            double resistance = mode == MultimeterMode.Resistance ? value : 0;

            string text =
                $"V {dcVoltage}\n" +
                $"A {current}\n" +
                $"~ {acVoltage}\n" +
                $"Ω {resistance}";

            _valuesText.text = text;
        }
    }
}