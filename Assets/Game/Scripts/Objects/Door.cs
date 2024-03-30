using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Objects
{
    public class Door : InteractiveObject
    {
        [SerializeField] private float _animationDuration = 0.5f;
        private bool _isOpen = false;

        public override void Action(Character.PlayerController player)
        {
            base.Action(player);
            Debug.Log("Door action");
            if (!_isOpen)
            {
                Debug.Log("Open door");
                _isOpen = true;
                if (Vector3.Distance(transform.position+transform.forward, player.transform.position) > Vector3.Distance(transform.position + transform.forward*-1f, player.transform.position))
                {
                    transform.DOLocalRotate(Vector3.up * 90, _animationDuration);
                }
                else
                {
                    transform.DOLocalRotate(Vector3.up*-90, _animationDuration);
                }
            }
            else
            {
                _isOpen = false;
                transform.DOLocalRotate(Vector3.zero, _animationDuration);
            }
        }

        private void FixedUpdate()
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            Debug.DrawRay(transform.position, transform.forward*-1f, Color.green);
        }
    }
}