using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class GameplayInputReader : Controls.IGameplayActions
    {
        public System.Action ActionEvent;
        public System.Action CancelEvent;
        public System.Action MenuEvent;
        public System.Action<Vector2Int> MoveChangedEvent;
        public System.Action<bool> SprintChangedEvent;

        Vector2 lastMove = Vector2.zero;

        public void OnAction(InputAction.CallbackContext context)
        {
            if(context.performed) ActionEvent?.Invoke();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if (context.performed) CancelEvent?.Invoke();
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (context.performed) MenuEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!(context.performed || context.canceled)) return;
            Vector2 v = context.ReadValue<Vector2>();
            // if input is in two directions, the one that ISNT the last one
            // is the new direction
            if(v.x != 0 && v.y != 0)
            {
                if(lastMove != Vector2.zero)
                {
                    if (lastMove.x != 0)
                    {
                        v = Vector2.up * Mathf.Sign(v.y);
                    }
                    else
                    {
                        v = Vector2.right * Mathf.Sign(v.x);
                    }
                }
                else
                {
                    v = Vector2.right * Mathf.Sign(v.x);
                }
            }
            // store the modified last move
            //INVARIANT: v has max one direction
            lastMove = v;
            MoveChangedEvent?.Invoke(Vector2Int.FloorToInt(v));
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.performed || context.canceled) SprintChangedEvent?.Invoke(context.ReadValueAsButton());
        }
    }

    public class MenuInputReader : Controls.IMenuActions
    {
        public System.Action SubmitEvent;
        public System.Action CancelEvent;
        public System.Action<Vector2> MoveChangedEvent;

        public void OnSubmit(InputAction.CallbackContext context)
        {
            if (context.performed) SubmitEvent?.Invoke();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            if (context.performed) CancelEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed) MoveChangedEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }

    [CreateAssetMenu(fileName = "InputReader", menuName = "Input/Input Reader")]
    public class InputReaderSO : ScriptableObject
    {
        [System.NonSerialized] public GameplayInputReader Gameplay;
        [System.NonSerialized] public MenuInputReader Menu;

        [System.NonSerialized] public Controls Controls;

        public static InputReaderSO FindInputReaderSO()
            => SOUtil.Find<InputReaderSO>();

        public void OnEnable()
        {
            Controls = new Controls();

            Gameplay = new GameplayInputReader();
            Controls.Gameplay.SetCallbacks(Gameplay);

            Menu = new MenuInputReader();
            Controls.Menu.SetCallbacks(Menu);

            EnableGameplay();
        }

        public void DisableAll()
        {
            Controls.Gameplay.Disable();
            Controls.Menu.Disable();
        }

        public void EnableMenu()
        {
            DisableAll();
            Controls.Menu.Enable();
        }

        public void EnableGameplay()
        {
            DisableAll();
            Controls.Gameplay.Enable();
        }
    }
}
