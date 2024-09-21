using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Utilities.UIElements
{
    public static class VisualElementUtility
    {
        public static void AddRange(this VisualElement parent, params VisualElement[] elements)
        {
            foreach (VisualElement element in elements) 
            { 
                parent.Add(element);
            }
        }

        public static void AddBorder(this VisualElement element, Color borderColor, float thickness, float radius)
        {
            element.style.borderBottomColor = borderColor;
            element.style.borderBottomWidth = thickness;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderBottomRightRadius = radius;
            element.style.borderTopColor = borderColor;
            element.style.borderTopWidth = thickness;
            element.style.borderTopRightRadius = radius;
            element.style.borderTopLeftRadius = radius;
            element.style.borderLeftColor = borderColor;
            element.style.borderLeftWidth = thickness;
            element.style.borderRightColor = borderColor;
            element.style.borderRightWidth = thickness;
        }
    }
}
