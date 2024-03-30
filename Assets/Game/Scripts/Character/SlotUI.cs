using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Character;
using UnityEngine.EventSystems;
using System;
namespace PlayerInterface
{
    public class SlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _iconImage;

        [SerializeField] private TextMeshProUGUI _textAmount;

        private PlayerInventoryUI _inventoryUI;

        private InventorySlot _slot;

        private bool _isDragging;

        public Items.Item Item { get { return _slot.Item; } }
        public Sprite Icon { get { return _iconImage.sprite; } }

        public void Init(PlayerInventoryUI inventoryUI, InventorySlot slot)
        {
            _inventoryUI = inventoryUI;

            _slot = slot;

        }

        public void OnBeginDrag(PointerEventData data)
        {
            Debug.Log("OnBeginDrag: " + data.position);
         
            if (_slot.Item != null)
            {
                _inventoryUI.BeginDrag(_slot);
                _isDragging = true;
            }
        }

        public void OnDrag(PointerEventData data)
        {
            if (_isDragging)
            {
                _inventoryUI.DragIcon();
            }
        }

        public void OnEndDrag(PointerEventData data)
        {
            if(_slot.Item != null)
            {
                _inventoryUI.EndDrag();
                _isDragging = false;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Pointer enter: " + gameObject.name);
            if (_isDragging)
            {
                _inventoryUI.EnterSlot(_slot);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Pointer exit: " + gameObject.name);
            if (_isDragging)
            {
                _inventoryUI.ExitSlot(_slot);
            }
        }

        public void UpdateUI()
        {
            Sprite sprite = _slot.Item == null ? null : _slot.Item.Icon;
            int amount = 0;
            if (sprite != null)
             amount = _slot.Amount;

            if (_iconImage == null)
            {
                _iconImage.enabled = false;
                _textAmount.enabled = false;
            }
            else
            {
                _iconImage.enabled = true;
                _textAmount.enabled = true;

                _iconImage.sprite = sprite;
                _textAmount.text = amount.ToString();

                if (amount <= 1) _textAmount.enabled = false;
                else _textAmount.enabled = true;
            }
        }
    }
}