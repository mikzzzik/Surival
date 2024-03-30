using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
namespace Objects
{
    public class DroppedItem : InteractiveObject
    {
        [SerializeField] private Item _item;

        [SerializeField] private int _amount;

        public int Amount => _amount;
        public Item Item => _item;

        public void Drop(Item item, int amount)
        {
            _item = item;
            _amount = amount;
        }

        public override void Action(PlayerController player)
        {
            base.Action(player);

            player.Inventory.TryPickUp(this);
        }

        public void PickUp(int amount)
        {
                _amount -= amount;

                if (_amount <= 0)
                Destroy(this.gameObject);
        }
    }
}