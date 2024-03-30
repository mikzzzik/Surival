using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Objects;
namespace Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _name = "Item-name";
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private DroppedItem _dropedItem;
        [SerializeField] private int _maxInStack;

        public Sprite Icon => _icon;
        public DroppedItem DroppedItem => _dropedItem;
        public string Name => _name;
        public ItemType Type => _itemType;
        public int MaxInStack => _maxInStack;

    }
}
