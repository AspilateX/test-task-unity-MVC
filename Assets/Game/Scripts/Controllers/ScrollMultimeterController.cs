using Game.Scripts.Models;
using Game.Scripts.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Controllers
{
    /// <summary>
    /// Контроллер мультиметра с возможностью смены режима работы
    /// </summary>
    public class ScrollMultimeterController : MultimeterController
    {
        [SerializeField]
        private InputActionProperty _scrollInputAction;

        public bool InputEnabled { get; private set; }

        public void DisableInput() => InputEnabled = false;

        public void EnableInput() => InputEnabled = true;

        public override void Initialize(IMultimeterModel model, IMultimeterView view)
        {
            base.Initialize(model, view);
            _scrollInputAction.action.performed += OnScrollPerformed;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _scrollInputAction.action.performed -= OnScrollPerformed;
        }

        private void OnScrollPerformed(InputAction.CallbackContext context)
        {
            if (!InputEnabled)
                return;

            float scrollDeltaY = context.ReadValue<Vector2>().y;
            int direction = (int)Mathf.Sign(scrollDeltaY);

            if (direction > 0)
                Model.SelectNextMode();
            else if (direction != 0)
                Model.SelectPreviousMode();
        }
    }
}