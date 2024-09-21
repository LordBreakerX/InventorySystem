using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using LordBreakerX.Utilities.UIElements;

namespace LordBreakerX.Inventory
{
    [CustomEditor(typeof(Item), true)]
    public class ItemEditor : Editor
    {
        private DecoratedFoldout _basicDetailsFoldout;

        private DecoratedFoldout _visualsFoldout;

        private DecoratedFoldout _statsFoldout;

        private DecoratedFoldout _additionsFoldout;

        private DecoratedFoldout _behaviourDetails;

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            HeaderBox header = new HeaderBox("Item", 30, Color.black, Color.gray);
            header.AddBorder(5, Color.black);

            BoxElement space = new BoxElement(20);

            CreateBasicDetails();

            CreateVisualsDetails();

            CreateStatsDetails();

            CreateBehaviourDetails();

            root.AddRange(header, space, _basicDetailsFoldout, _visualsFoldout, _statsFoldout, _behaviourDetails);

            OnCreateInspectorGUI(root);

            _additionsFoldout = new DecoratedFoldout("Additional Details");
            OnCreateAdditionsDetails(_additionsFoldout.Content);

            if (_additionsFoldout.Content.childCount > 0)
            {
                root.Add(_additionsFoldout);
            }

            return root;
        }

        private void CreateBasicDetails()
        {
            _basicDetailsFoldout = new DecoratedFoldout("Basic Details");

            BetterPropertyField displayName = new BetterPropertyField(serializedObject.FindProperty("_displayName"), Color.black);
            BetterPropertyField category = new BetterPropertyField(serializedObject.FindProperty("_category"), Color.black);
            BetterPropertyField description = new BetterPropertyField(serializedObject.FindProperty("_description"), Color.black);
            BetterPropertyField rarity = new BetterPropertyField(serializedObject.FindProperty("_itemRarity"), Color.black);

            _basicDetailsFoldout.AddRangeToContent(displayName, category, description, rarity);
            OnCreateBasicDetails(_basicDetailsFoldout.Content);
        }

        private void CreateVisualsDetails()
        {
            _visualsFoldout = new DecoratedFoldout("Visuals");

            BetterPropertyField icon = new BetterPropertyField(serializedObject.FindProperty("_icon"), Color.black);
            BetterPropertyField brokenIcon = new BetterPropertyField(serializedObject.FindProperty("_brokenIcon"), Color.black);
            
            _visualsFoldout.AddRangeToContent(icon, brokenIcon);
            OnCreateVisualsDetails(_visualsFoldout.Content);
        }

        private void CreateStatsDetails()
        {
            _statsFoldout = new DecoratedFoldout("Stats");

            BetterPropertyField maxStackSize = new BetterPropertyField(serializedObject.FindProperty("_maxStackSize"), Color.black);
            BetterPropertyField maxDurability = new BetterPropertyField(serializedObject.FindProperty("_maxDurability"), Color.black);
            BetterPropertyField value = new BetterPropertyField(serializedObject.FindProperty("_itemValue"), Color.black);

            _statsFoldout.AddRangeToContent(maxStackSize, maxDurability, value);
            OnCreateStatsDetails(_statsFoldout.Content);
        }

        private void CreateBehaviourDetails()
        {
            _behaviourDetails = new DecoratedFoldout("Functional Details");

            BetterPropertyField consumeOnUse = new BetterPropertyField(serializedObject.FindProperty("_consumeOnUse"), Color.black);

            Seperator seperator = new Seperator(4, Color.black);

            BetterPropertyField noDurability = new BetterPropertyField(serializedObject.FindProperty("_noDurabilityBehavior"), Color.black);

            _behaviourDetails.AddRangeToContent(noDurability, seperator, consumeOnUse);
            OnCreateFunctionalDetails(_behaviourDetails.Content);
        }

        protected void CreateSeperator(VisualElement parent)
        {
            parent.Add(new Seperator(2, 4, Color.black));
        }

        protected virtual void OnCreateInspectorGUI(VisualElement root) { }

        protected virtual void OnCreateBasicDetails(VisualElement content) { }

        protected virtual void OnCreateVisualsDetails(VisualElement content) { }

        protected virtual void OnCreateStatsDetails(VisualElement content) { }

        protected virtual void OnCreateFunctionalDetails(VisualElement content) { }

        protected virtual void OnCreateAdditionsDetails(VisualElement content) 
        {
            FieldsUtility.ShowDerivedFields(content, serializedObject, target.GetType(), typeof(Item), Color.black);
        }
    }
}
