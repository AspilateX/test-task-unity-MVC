using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Game.Scripts.Systems.Interaction
{
    /// <summary>
    /// Компонент, предоставляющий возможность вызвать события при входе/выходе курсора с объекта
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private UnityEvent _onPointerEnter;

        [SerializeField]
        private UnityEvent _onPointerExit;

        public void OnPointerEnter(PointerEventData pointerEventData) => _onPointerEnter?.Invoke();

        public void OnPointerExit(PointerEventData pointerEventData) => _onPointerExit?.Invoke();
    }
}