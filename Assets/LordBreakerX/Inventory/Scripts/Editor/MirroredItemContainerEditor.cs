using LordBreakerX.Utilities.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LordBreakerX.Inventory
{
    [CustomEditor(typeof(MirroredItemContainer), true)]
    public class MirroredItemContainerEditor : Editor
    {
        private SerializedProperty _container;

        private SerializedProperty _content;

        private SerializedProperty _slotPrefab;

        protected virtual void OnEnable()
        {
            _container = serializedObject.FindProperty("_container");
            _content = serializedObject.FindProperty("_content");
            _slotPrefab = serializedObject.FindProperty("_slotPrefab");
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            HeaderBox header = new HeaderBox("Mirrored Item Container", 30, Color.black, Color.gray);
            header.AddBorder(5, Color.black);

            BoxElement space = new BoxElement(20);

            DecoratedFoldout basicDetails = new DecoratedFoldout("Basic Details");
            CreateBasicDetails(basicDetails.Content);

            DecoratedFoldout additional = new DecoratedFoldout("Additional Details");
            OnCreateAdditional(basicDetails.Content);

            root.AddRange(header, space, basicDetails);

            if (additional.Content.childCount > 0) 
            {
                root.Add(additional);
            }

            return root;
        }

        private void CreateBasicDetails(VisualElement content)
        {
            BetterPropertyField container = new BetterPropertyField(_container, "Container To Mirror", Color.black);
            BetterPropertyField placementContent = new BetterPropertyField(_content, Color.black);
            BetterPropertyField slotPrefab = new BetterPropertyField(_slotPrefab, Color.black);

            content.AddRange(container, placementContent, slotPrefab);
        }

        private void OnCreateAdditional(VisualElement content)
        {
            FieldsUtility.ShowDerivedFields(content, serializedObject, target.GetType(), typeof(MirroredItemContainer));
        }
    }
}
