using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LordBreakerX.Inventory
{
    public class ItemDragHandler : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _dragUI;

        [SerializeField]
        private Image _itemIcon;

        [SerializeField]
        private TMP_Text _quantityText;

        private static ItemDragHandler _instance;

        private static ItemStack _draggingStack;

        private void Update()
        {
            if (_instance != null && _draggingStack != null)
            {
                _instance._dragUI.position = Input.mousePosition;
            }
        }

        private void OnEnable()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogWarning("Only one item drag handler is allowed per scene!");
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        public static bool IsDragging()
        {
            return _draggingStack != null;
        }

        public static void OnRightMouseClicked(ItemSlot clickedSlot)
        {
            if (_instance == null) return;

            if (_draggingStack == null && clickedSlot.ContainedStack != null)
            {
                if (clickedSlot.ContainedStack.Count < 2)
                {
                    _instance.EnableDrag(clickedSlot);
                }
                else
                {
                    ItemStack newStack = clickedSlot.ContainedStack.SplitStack();
                    clickedSlot.UpdateVisuals();
                    _instance.EnableDrag(newStack);
                }
            }
            else if (_draggingStack != null)
            {
                if (!clickedSlot.IsEmpty() && clickedSlot.HasItem(_draggingStack) && _draggingStack.StackItem.IsStackable() && !clickedSlot.IsFull())
                {
                    clickedSlot.Grow(1);
                    clickedSlot.UpdateVisuals();
                    _draggingStack.ShrinkStack(1);
                    _instance.UpdateVisuals();

                    if (_draggingStack.Count < 1) _instance.DisableDrag();
                }
                else if (clickedSlot.IsEmpty() && clickedSlot.CanEnterSlot(_draggingStack))
                {
                    clickedSlot.ChangeStack(new ItemStack(_draggingStack.StackItem, 1));
                    clickedSlot.UpdateVisuals();
                    _draggingStack.ShrinkStack(1);
                    _instance.UpdateVisuals();

                    if (_draggingStack.Count < 1) _instance.DisableDrag();
                }
            }
        }

        public static void OnLeftMouseClicked(ItemSlot clickedSlot)
        {
            if (_instance == null) return;

            if (_draggingStack == null)
            {
                _instance.EnableDrag(clickedSlot);
            }
            else if (_draggingStack != null)
            {
                if (clickedSlot.ContainedStack == _draggingStack)
                {
                    _instance.DisableDrag();
                }
                else if (!clickedSlot.IsEmpty() && clickedSlot.HasItem(_draggingStack) && _draggingStack.StackItem.IsStackable())
                {
                    _instance.CombineStacks(clickedSlot);
                }
                else if (clickedSlot.CanEnterSlot(_draggingStack))
                {
                    _instance.SwitchStack(clickedSlot);
                }
            }
        }

        private bool EnableDrag(ItemStack stack)
        {
            if (stack != null && _draggingStack == null)
            {
                _draggingStack = stack;
                _dragUI.gameObject.SetActive(true);
                UpdateVisuals();
                return true;
            }
            return false;
        }

        private void EnableDrag(ItemSlot clickedSlot) 
        {
            if (clickedSlot != null && EnableDrag(clickedSlot.ContainedStack)) clickedSlot.ChangeStack(null);
        }

        private void DisableDrag()
        {
            _draggingStack = null;
            _dragUI.gameObject.SetActive(false);
        }

        private void CombineStacks(ItemSlot clickedSlot)
        {
            int remains = clickedSlot.ContainedStack.CombineStacks(_draggingStack);
            clickedSlot.UpdateVisuals();

            if (remains > 0)
            {
                _draggingStack = new ItemStack(clickedSlot.ContainedStack.StackItem, remains);
                UpdateVisuals();
            }
            else
            {
                DisableDrag();
            }
        }

        private void SwitchStack(ItemSlot clickedSlot)
        {
            ItemStack oldStack = clickedSlot.ContainedStack;
            clickedSlot.ChangeStack(_draggingStack);
            _draggingStack = oldStack;
            clickedSlot.UpdateVisuals();
            UpdateVisuals();

            if (_draggingStack == null)
            {
                DisableDrag();
            }
        }

        private void UpdateVisuals()
        {
            if (_draggingStack != null && _draggingStack.StackItem != null)
            {
                _itemIcon.sprite = _draggingStack.StackItem.Icon;
                _quantityText.text = _draggingStack.Count.ToString();

                if (_draggingStack.Count > 1)
                {
                    _quantityText.gameObject.SetActive(true);
                }
                else
                {
                    _quantityText.gameObject.SetActive(false);
                }
            }


        }

    }
}
