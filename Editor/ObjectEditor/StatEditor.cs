using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    public partial class StatEditor : EditorWindow
    {
        private readonly StatDatabaseType<VitalDatabase, VitalData, Vital> _vitalDatabase = new StatDatabaseType<VitalDatabase, VitalData, Vital>("VitalDatabase.asset");
        public static readonly StatDatabaseType<AttributeDatabase, AttributeData, Attribute> AttributeDatabase = new StatDatabaseType<AttributeDatabase, AttributeData, Attribute>("AttributeDatabase.asset");
        public static readonly StatDatabaseType<ModifierDatabase, StatModifierData, StatModifier> ModifierDatabase = new StatDatabaseType<ModifierDatabase, StatModifierData, StatModifier>("ModifierDatabase.asset");
        public static readonly StatDatabaseType<LinkerDatabase, StatLinkerBasicData, StatLinkerBasic> LinkerDatabase = new StatDatabaseType<LinkerDatabase, StatLinkerBasicData, StatLinkerBasic>("LinkerDatabase.asset");

        private readonly Vector2 _buttonSize = new Vector2(190, 25);
        private const int ListViewWidth = 200;

        [MenuItem("Stat System/Stat System Editor %#i")]
        public static void Initialize()
        {
            StatEditor window = GetWindow<StatEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = "Stat System Database";
        }

        void OnEnable()
        {            
            AttributeDatabase.OnEnable("Attribute");
            _vitalDatabase.OnEnable("Vital");
            ModifierDatabase.OnEnable("Modifier");
            LinkerDatabase.OnEnable("Linker");
            _tabState = TabState.Attribute;
        }

        void OnGUI()
        {
            TopBar();
            GUILayout.BeginHorizontal();

            switch (_tabState)
            {
                case TabState.Vital:
                    _vitalDatabase.OnGUI(_buttonSize, ListViewWidth);
                    break;
                case TabState.Attribute:
                    AttributeDatabase.OnGUI(_buttonSize, ListViewWidth);
                    break;
                case TabState.Modifier:
                    ModifierDatabase.OnGUI(_buttonSize, ListViewWidth);
                    break;
                case TabState.Linker:
                    LinkerDatabase.OnGUI(_buttonSize, ListViewWidth);
                    break;
            }
            GUILayout.EndHorizontal();
            BottomBar();
        }
    }
}
