using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Utilities.UIElements
{
    public class Seperator : VisualElement
    {
        public BoxElement Line { get; private set; }

        public Seperator(float spacingBefore, float spacingAfter, Color seperatorColor, SeperatorType type = SeperatorType.Thin)
        {
            Line = new BoxElement((int)type, seperatorColor);

            Add(new BoxElement(spacingBefore, Color.clear));
            Add(Line);
            Add(new BoxElement(spacingAfter, Color.clear));
        }

        public Seperator(float totalSpacing, Color seperatorColor, SeperatorType type = SeperatorType.Thin) : this(totalSpacing / 2, totalSpacing / 2, seperatorColor, type)
        {

        }
    }
}
