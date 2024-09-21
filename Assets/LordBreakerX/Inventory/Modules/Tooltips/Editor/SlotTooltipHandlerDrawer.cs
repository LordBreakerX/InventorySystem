using LordBreakerX.Utilities.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Inventory.Tooltips
{
    [CustomPropertyDrawer(typeof(ItemTooltipHandler))]
    public class SlotTooltipHandlerDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            BetterPropertyField tooltipID = new BetterPropertyField(property.FindPropertyRelative("_tooltipID"), Color.black);
            root.Add(tooltipID);
            return root;
        }
    }
}
