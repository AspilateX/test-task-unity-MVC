using System;
using UnityEngine;
using Game.Scripts.Models;
using UnityEngine.Serialization;

namespace Game.Scripts.Views
{
    [Serializable]
    public struct MultimeterRotationMap
    {
        [field: SerializeField]
        public MultimeterMode Mode { get; set; }

        [field: SerializeField]
        public float Rotation { get; set; }
    }
}