using System;
using UnityEngine;

namespace Game.Scripts.Systems.Interaction
{
    /// <summary>
    /// Компонент, реализующий эффект подсветки предмета
    /// </summary>
    [RequireComponent(typeof(Renderer))]
    public class Highlighter : MonoBehaviour
    {
        [SerializeField]
        private HighlightConfig _highlightConfig;

        private Renderer _renderer;
        private Material[] _originalMaterials;
        private Material[] _highlightMaterials;
        private bool _isHighlighted;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _originalMaterials = _renderer.materials;
        }

        public void EnableHighlight()
        {
            if (_isHighlighted)
                return;

            if (_highlightConfig == null || _highlightConfig.Material == null)
                return;

            // Создаем новые материалы. Используем заполнение, чтобы заменить все материалы объекта
            // на случай если их у него несколько
            _highlightMaterials = new Material[_originalMaterials.Length];
            Array.Fill(_highlightMaterials, _highlightConfig.Material);

            _renderer.materials = _highlightMaterials;
            _isHighlighted = true;
        }

        public void DisableHighlight()
        {
            if (!_isHighlighted)
                return;

            _renderer.materials = _originalMaterials;
            _isHighlighted = false;
        }
    }
}
