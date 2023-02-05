using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class GameplayInputReader : Controls.IGameplayActions
    {
        public System.Action ActionEvent;
        public System.Action CancelEvent;
        public System.Action MenuEvent;
        public System.Action<Vector2> MoveChangedEvent;
        public System.Action<bool> SprintChangedEvent;

        public void OnAction(InputAction.CallbackContext context)
        {
            ActionEvent?.Invoke();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            CancelEvent?.Invoke();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            MenuEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveChangedEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            SprintChangedEvent?.Invoke(context.ReadValueAsButton());
        }
    }

    [CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
    public class InputReaderSO : ScriptableObject
    {
        [System.NonSerialized] public GameplayInputReader Gameplay;
        [System.NonSerialized] public Controls Controls;

        public void OnEnable()
        {
            Controls = new Controls();
            Gameplay = new GameplayInputReader();
            Controls.Gameplay.SetCallbacks(Gameplay);
        }
    }
}
