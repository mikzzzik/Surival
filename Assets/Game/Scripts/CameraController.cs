using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Objects;
using PlayerInterface;
namespace Character
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _rayDistance = 5f;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private UIController _controllerUI;
  
        RaycastHit _hit;

        private GameObject _rayObject;

        private void FixedUpdate()
        {
            Debug.DrawRay(transform.position, transform.forward * _rayDistance, Color.red);


            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, _rayDistance))
            {
                
                _rayObject = _hit.collider.gameObject;
 
                if (_rayObject.tag == "InteractiveObject")
                    _controllerUI.InteractiveTextShow(true);
                else _controllerUI.InteractiveTextShow(false);

            } 
            else if (_controllerUI.IsShowInteractiveText)
            {
                _controllerUI.InteractiveTextShow(false);
                _rayObject = null;
            }

        }

        public void Action()
        {
            if (_controllerUI.IsShowInteractiveText)
            {
                
                _rayObject.GetComponent<InteractiveObject>().Action(_playerController);
            }
        }
    }
}