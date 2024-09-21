using LordBreakerX.Utilities.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    public class ItemContainerGroup : MonoBehaviour
    {
        [SerializeField]
        private List<ItemContainer> _groupContainers;

        public void AddItem(Item item, int amount = 1, bool addToRandomSlots = false)
        {
            ItemContainer[] containers = _groupContainers.ToArray();
            
            if (addToRandomSlots) containers.Shuffle();

            int amountToAdd = amount;

            foreach(ItemContainer container in containers)
            {
                if (amountToAdd > 0)
                {
                    amountToAdd = container.AddItem(item, amountToAdd, addToRandomSlots);
                }
                else
                {
                    break;
                }
            }
        }

        public void AddTableItems(LootTable table, int bonusModifer = 0, bool addToRandomSlots = false)
        {
            LootItem[] items = table.GetLoot(bonusModifer).ToArray();
            foreach (LootItem lootItem in items) 
            {
                AddItem(lootItem.Item, lootItem.Count, addToRandomSlots);
            }
        }
 
    }
}
