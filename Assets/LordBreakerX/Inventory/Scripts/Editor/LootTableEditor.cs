using UnityEngine;
using UnityEditor;
using LordBreakerX.Utilities.Editor;
using UnityEditor.TerrainTools;
using UnityEngine.UIElements;
using LordBreakerX.Utilities.UIElements;

namespace LordBreakerX.Inventory
{
    [CustomEditor(typeof(LootTable))]
    public class LootTableEditor : Editor
    {
        private SerializedProperty _minRolls;
        private SerializedProperty _maxRolls;
        private SerializedProperty _bonusRolls;
        private SerializedProperty _entries;

        private DecoratedFoldout _generalFoldout;
        private DecoratedFoldout _entriesFoldout;

        private void OnEnable()
        {
             _minRolls = serializedObject.FindProperty("_minRolls");
            _maxRolls = serializedObject.FindProperty("_maxRolls");
            _bonusRolls = serializedObject.FindProperty("_bonusRolls");
            _entries = serializedObject.FindProperty("_entries");

        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            HeaderBox header = new HeaderBox("Loot Table", 30, Color.black, Color.gray);
            header.AddBorder(5, Color.black);

            BoxElement space = new BoxElement(20);

            CreateGeneralFoldout();
            CreateEntriesFoldout();

            root.AddRange(header, space, _generalFoldout, _entriesFoldout);

            return root;
        }

        private void CreateGeneralFoldout()
        {
            _generalFoldout = new DecoratedFoldout("General Details");

            BetterPropertyField minRolls = new BetterPropertyField(_minRolls, Color.black);
            BetterPropertyField maxRolls = new BetterPropertyField(_maxRolls, Color.black);
            BetterPropertyField bonusRolls = new BetterPropertyField(_bonusRolls, Color.black);

            _generalFoldout.AddRangeToContent(minRolls, maxRolls, bonusRolls);
        }

        private void CreateEntriesFoldout()
        {
            _entriesFoldout = new DecoratedFoldout("Loot Entries");

            BetterPropertyField entries = new BetterPropertyField(_entries, Color.black);

            _entriesFoldout.AddRangeToContent(entries);
        }
    }
}
