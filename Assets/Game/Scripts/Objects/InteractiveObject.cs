using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class InteractiveObject : MonoBehaviour
    {
        public virtual void Action(Character.PlayerController player) { }
    }
}
