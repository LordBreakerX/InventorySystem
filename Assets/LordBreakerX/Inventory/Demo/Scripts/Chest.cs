using LordBreakerX.Inventory;
using UnityEngine;

namespace LordBreakerX
{
    public class Chest : MonoBehaviour
    {
        [SerializeField]
        private LootTable _possibleItems;

        [SerializeField]
        private GameObject _chestUI;

        [SerializeField]
        private ItemContainer _chestContainer;

        public static Chest OpenableChest { get; private set; }

        private bool _itemsAdded;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                
                OpenableChest = this;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && OpenableChest == this)
            {

                OpenableChest = null;
            }
        }

        public void OpenChest()
        {
            _chestUI.SetActive(true);
            if (!_itemsAdded) _chestContainer.AddTableItems(_possibleItems, 0, true);
            _itemsAdded = true;
        }

        public void CloseChest()
        {
            _chestUI.SetActive(false);
        }
    }
}

