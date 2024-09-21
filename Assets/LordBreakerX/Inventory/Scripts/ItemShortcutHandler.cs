using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Inventory
{
    [RequireComponent(typeof(ItemSlot))]
    public class ItemShortcutHandler : MonoBehaviour
    {
        [SerializeField]
        private List<ItemShortcut> _shortcuts = new List<ItemShortcut>();

        private ItemSlot _itemSlot;

        public enum ShortcutType
        {
            UsePrimary,
            UseSecondary
        }

        [System.Serializable]
        public struct ItemShortcut
        {
            public ShortcutType shortcutType;
            public string shortcutKeycode;

            public ItemShortcut(ShortcutType type, string keycode)
            {
                shortcutType = type;
                shortcutKeycode = keycode;
            }
        }

        private void Awake()
        {
            _itemSlot = GetComponent<ItemSlot>();
        }

        private void Update()
        {
            foreach (ItemShortcut shortcut in _shortcuts) 
            {
                if (Input.GetKeyDown(shortcut.shortcutKeycode))
                {
                    switch (shortcut.shortcutType)
                    {
                        case ShortcutType.UsePrimary:
                            _itemSlot.UseItem();
                            break;
                        case ShortcutType.UseSecondary:
                            _itemSlot.UseItem(false);
                            break;
                    }
                }
            }
        }
        
    }
}
