using LordBreakerX.TooltipSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LordBreakerX.Inventory.Tooltips
{

    [RequireComponent(typeof(ItemSlot))]
    public class ItemTooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {
        [SerializeField]
        private string tooltipID = "Inv";

        private ItemSlot slot;

        private bool _overArea;

        private void Awake()
        {
            slot = GetComponent<ItemSlot>();
        }

        private void OnDisable()
        {
            TooltipManager.Instance.HideTooltip(tooltipID);
            _overArea = false;
        }

        private void Update()
        {
            if (ItemDragHandler.IsDragging())
            {
                TooltipManager.Instance.HideTooltip(tooltipID);
            }
            else if (_overArea && slot.ContainedStack != null)
            {
                TooltipManager.Instance.ShowTooltip(tooltipID, slot.ContainedStack.StackItem.Description, slot.ContainedStack.StackItem.DisplayName);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _overArea = true;

            if (slot.ContainedStack == null) return;

            if (!ItemDragHandler.IsDragging()) 
            {
                TooltipManager.Instance.ShowTooltip(tooltipID, slot.ContainedStack.StackItem.Description, slot.ContainedStack.StackItem.DisplayName);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _overArea = false;
            TooltipManager.Instance.HideTooltip(tooltipID);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (slot.ContainedStack == null) return;

            if (_overArea && !ItemDragHandler.IsDragging()) 
            {
                TooltipManager.Instance.MoveTooltip(tooltipID);
            }
        }
    }
}
