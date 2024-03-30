using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject _interactiveText;

    public bool IsShowInteractiveText => _interactiveText.activeSelf;

    public void InteractiveTextShow(bool status)
    {
        _interactiveText.SetActive(status);
    }
}
