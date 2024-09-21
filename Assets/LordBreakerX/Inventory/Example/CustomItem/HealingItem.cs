using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LordBreakerX.Objects;

namespace LordBreakerX.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Healing Item")]
    public class HealingItem : Item
    {
        [SerializeField]
        [Min(0f)]
        private int _healAmount = 5;

        public override void OnPrimaryUse(ItemStack itemStack)
        {
            TestPlayer player = ObjectManager.RegistryObjects["main"].GetComponent<TestPlayer>();
            player.Health += _healAmount;
            player.text.text = player.Health.ToString();
        }
    }
}

