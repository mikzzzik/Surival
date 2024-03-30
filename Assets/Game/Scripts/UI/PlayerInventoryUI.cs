using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;
using System;

namespace PlayerInterface
{
    public class PlayerInventoryUI : PanelUI
    {
        [SerializeField] private Transform _slotsHolder;

        [SerializeField] private List<SlotUI> _slotUIList;

        [SerializeField] private Image _draggingIcon;

        private InventorySlot _draggingSlot;
        private InventorySlot _selectedSlot;

        public Action<InventorySlot> OnDrop;
        public Action<InventorySlot, InventorySlot> OnChangeSlot;
        public void InitSlots(List<InventorySlot> slots)
        { 
            for(int i = 0; i < slots.Count; i++)
            {
                _slotUIList[i].Init(this,slots[i]);

                slots[i].SlotUI = _slotUIList[i];
            }
        }

        public void UpdateUI()
        {

            for (int i = 0; i < _slotUIList.Count; i++)
            {
                _slotUIList[i].UpdateUI();
            }
        }

        public void BeginDrag(InventorySlot slot)
        {
            _draggingSlot = slot;
            _draggingIcon.sprite = _draggingSlot.Item.Icon;
            _draggingIcon.enabled = true;
        }

        public void EnterSlot(InventorySlot slot)
        {
            _selectedSlot = slot;
        }

        public void ExitSlot(InventorySlot slot)
        {
            if(_selectedSlot == slot)
            {
                _selectedSlot = null;
                return;
            }
        }

        public void DragIcon()
        {
            _draggingIcon.transform.position = Input.mousePosition;
        }

        public void EndDrag()
        {
            _draggingIcon.enabled = false;

            if(_selectedSlot != null && _selectedSlot != _draggingSlot)
            {
                OnChangeSlot?.Invoke(_draggingSlot, _selectedSlot);
            }
            else
            {

            }
        }
    }
}