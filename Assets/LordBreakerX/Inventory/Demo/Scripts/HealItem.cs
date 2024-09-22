using LordBreakerX.Inventory;
using UnityEngine;

namespace LordBreakerX
{
    [CreateAssetMenu(menuName = "Inventory/Heal Item")]
    public class HealItem : Item
    {
        [SerializeField]
        private int _healOnUse;

        public override void OnPrimaryUse(ItemStack itemStack)
        {
            if (Player.Instance != null) 
            {
                Player.Instance.Heal(_healOnUse);
            }
        }

        public override bool CanBeDestroyed()
        {
            return false;
        }
    }
}
