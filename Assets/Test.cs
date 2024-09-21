using System.Collections;
using UnityEngine;
using LordBreakerX.Inventory;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    [SerializeField] ItemContainerGroup containerGroup;
    [SerializeField] LootTable _table;

    [SerializeField] private GameObject hotbar;
    [SerializeField] private GameObject inventory;

    bool iventoryOpen = false;

    private void Start()
    {
        //container.AddItem(_item, 10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            inventory.SetActive(!iventoryOpen);
            hotbar.SetActive(iventoryOpen);
            iventoryOpen = !iventoryOpen;
        }
    }

    public void AddItems(bool random)
    {
        containerGroup.AddTableItems(_table, addToRandomSlots: random);
    }

}
