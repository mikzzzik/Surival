using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Objects;
namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _inventory;

        public PlayerInventory Inventory => _inventory;

    }
}
