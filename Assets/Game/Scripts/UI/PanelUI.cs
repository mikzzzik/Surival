using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayerInterface
{
    public class PanelUI : MonoBehaviour
    {
        [SerializeField] private UIController _UIController;
        [SerializeField] private GameObject _panel;
        
        public bool IsShow => _panel.activeSelf;

        public virtual void Show()
        {
            Debug.Log("Show inventory");
            
            _UIController.SetShowedPanel(this);
            _UIController.SetCursorState(false);

            _panel.SetActive(true);
        }

        public virtual void Hide()
        {
            Debug.Log("Hide inventory");

            _UIController.SetShowedPanel(null);
            _UIController.SetCursorState(true);
        }

        public void Close()
        {
            _panel.SetActive(false);
        }
    }
}