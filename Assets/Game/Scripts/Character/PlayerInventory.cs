using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Objects;
using PlayerInterface;
namespace Character
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private List<InventorySlot> _slots;


        [SerializeField] private PlayerInterface.PlayerInventoryUI _inventoryUI;

        private void OnEnable()
        {
            _inventoryUI.OnDrop += Drop;
            _inventoryUI.OnChangeSlot += ChangeSlot;
        }

        private void Awake()
        {
            _inventoryUI.InitSlots(_slots);
            _inventoryUI.UpdateUI();
        }

        public void TryPickUp(DroppedItem dropedItem)
        {
            FindSlot(dropedItem);

        }

        private void FindSlot(DroppedItem dropedItem)
        {
            Item item = dropedItem.Item;
            int amount = dropedItem.Amount;
            InventorySlot freeSlot = null;

            for(int i = 0; i < _slots.Count; i++)
            {
                if (_slots[i].Item == item)
                {
                    if (_slots[i].Amount + amount < item.MaxInStack)
                    {
                        _slots[i].AddAmount(amount);


                        dropedItem.PickUp(amount);

                        return;
                    }
                    else
                    {
                        int maxValue = item.MaxInStack - _slots[i].Amount;

                        _slots[i].AddAmount(maxValue);

                        dropedItem.PickUp(maxValue);
                    }
                }
                else if (_slots[i].Item == null && freeSlot == null)
                {
                    freeSlot = _slots[i];
                }
            }

           
            
            Debug.Log(_slots.Count);

            Debug.Log(_slots.IndexOf(freeSlot));
            
            freeSlot.SetItem(item, amount);
            dropedItem.PickUp(amount);
        }

        private void ChangeSlot(InventorySlot firstSlot, InventorySlot secondSlot)
        {
            InventorySlot tempSlot = firstSlot;

            firstSlot.SetItem(secondSlot.Item, secondSlot.Amount);

            secondSlot.SetItem(tempSlot.Item, tempSlot.Amount);
        }

        public void Drop(InventorySlot slot)
        {
            DroppedItem dropped = Instantiate(slot.Item.DroppedItem) as DroppedItem;
            dropped.Drop(slot.Item, slot.Amount);

            int index = _slots.IndexOf(slot);

            slot.ClearSlot();

        }
        
        public void Action()
        {
            if (_inventoryUI.IsShow)
                _inventoryUI.Hide();
            else 
                _inventoryUI.Show();
        }

        private void OnDisable()
        {
            _inventoryUI.OnDrop += Drop;
            _inventoryUI.OnChangeSlot += ChangeSlot;
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        [SerializeField] private Item _item;
        [SerializeField] private int _amount;
        [SerializeField] private SlotType _type = SlotType.Inventory;

        private SlotUI _slotUI;

        public SlotUI SlotUI { set { _slotUI = value; } }

        public Item Item { get { return _item; } set { _item = value; } }

        public int Amount { get { return _amount; } set { _amount = value; } }

        public SlotType SlotType { get { return _type; }}

        public void AddAmount(int amount = 1)
        {
            _amount += amount;

            if (amount <= 0)
                _item = null;

            _slotUI.UpdateUI();
        }

        public void ClearSlot()
        {
            _item = null;
            _amount = 0;

            _slotUI.UpdateUI();
        }

        public void SetItem(Item item, int amount)
        {
            _item = item;
            _amount = amount;

            if(_slotUI != null)
                _slotUI.UpdateUI();
        }

    }
    
    public enum SlotType
    {
        Inventory,
        Hotbar,
        Equipment
    }

    public enum ItemType
    {
        Resources,
        Construction,
        Weapon,
        Tools,
        Food,
        Ammunition,
        Clothing,
    }
}