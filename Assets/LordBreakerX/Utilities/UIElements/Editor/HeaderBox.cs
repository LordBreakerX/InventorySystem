using System.Drawing.Printing;
using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Utilities.UIElements
{
    public class HeaderBox : BoxElement
    {
        public Label Label { get; private set; }

        public HeaderBox(string text, float fontSize, Color fontColor, Color boxColor) : base(fontSize + 20, boxColor) 
        {
            Label = new Label(text);
            style.alignItems = Align.Center;
            style.justifyContent = Justify.Center;
            Label.style.color = fontColor;
            Label.style.unityFontStyleAndWeight = FontStyle.Bold;
            Label.style.fontSize = new StyleLength(fontSize);
            Add(Label);
        }

        public HeaderBox(string text, float fontSize, Color fontColor) : this(text, fontSize, fontColor, Color.clear)
        {

        }
    }
}
