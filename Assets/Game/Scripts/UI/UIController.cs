using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
namespace PlayerInterface
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private PanelUI _nowPanel;
        [SerializeField] private GameObject _interactiveText;
        [SerializeField] private PlayerInputSystem _inputSystem;
        public bool IsShowInteractiveText => _interactiveText.activeSelf;

        public void InteractiveTextShow(bool status)
        {
            _interactiveText.SetActive(status);
        }
    
      public void SetCursorState(bool newState)
        {
            Debug.Log(Cursor.lockState);
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void SetShowedPanel(PanelUI nowPanel)
        {
            if (_nowPanel != null)
            {
                _nowPanel.Close();
            }

            _nowPanel = nowPanel;

            if (nowPanel != null)
            {
                _inputSystem.cursorInputForLook = false;
            }
            else _inputSystem.cursorInputForLook = true;
        }
    }


}