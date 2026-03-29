using UnityEngine;

namespace Game.Scripts.Models
{
    /// <summary>
    /// Простой электрический прибор
    /// </summary>
    public class ElectricalDevice : MonoBehaviour, IElectricalDevice
    {
        public float Power => _power;
        public float Resistance => _resistance;

        [SerializeField]
        private float _power;

        [SerializeField]
        private float _resistance;
    }
}