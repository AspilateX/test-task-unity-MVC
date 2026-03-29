using UnityEngine;

namespace Game.Scripts.Systems.Interaction
{
    /// <summary>
    /// Конфигурация подсветки, используется в <see cref="Highlighter"/>
    /// </summary>
    [CreateAssetMenu(fileName = "HighlightConfig", menuName = "Game/Configs/Highlight Config")]
    public class HighlightConfig : ScriptableObject
    {
        [SerializeField]
        private Material _material;

        public Material Material => _material;
    }
}
