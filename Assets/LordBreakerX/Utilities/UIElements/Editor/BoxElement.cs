using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Utilities.UIElements
{
    public class BoxElement : VisualElement
    {
        public BoxElement(StyleLength height, Color boxColor)
        {
            style.width = new StyleLength(StyleKeyword.Auto);
            ConfigureBox(height, boxColor);
        }

        public BoxElement(StyleLength height) : this(height, Color.clear)
        {

        }

        public void ConfigureBox(StyleLength height, Color boxColor)
        {
            ConfigureBox(boxColor);
            ConfigureBox(height);
        }

        public void ConfigureBox(StyleLength height)
        {
            style.height = height;
        }

        public void ConfigureBox(Color boxColor)
        {
            style.backgroundColor = boxColor;
        }

        public void AddBorder(StyleFloat borderThickness, Color borderColor)
        {
            AddBottomBorder(borderThickness, borderColor);
            AddTopBorder(borderThickness, borderColor);
            AddRightBorder(borderThickness, borderColor);
            AddLeftBorder(borderThickness, borderColor);
        }

        public void AddBottomBorder(StyleFloat borderThickness, Color borderColor) 
        {
            style.borderBottomWidth = borderThickness;
            style.borderBottomColor = borderColor;
        }

        public void AddTopBorder(StyleFloat borderThickness, Color borderColor)
        {
            style.borderTopWidth = borderThickness;
            style.borderTopColor = borderColor;
        }

        public void AddLeftBorder(StyleFloat borderThickness, Color borderColor) 
        {
            style.borderLeftWidth = borderThickness;
            style.borderLeftColor = borderColor;
        }

        public void AddRightBorder(StyleFloat borderThickness, Color borderColor)
        {
            style.borderRightWidth = borderThickness;
            style.borderRightColor = borderColor;
        }
    }
}
