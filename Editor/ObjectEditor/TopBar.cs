using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    public partial class StatEditor
    {
        private enum TabState
        {
            Vital,
            Attribute,
            Modifier,
            Linker
        }

        private TabState _tabState;

        void TopBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            VitalTab();
            AttributeTab();
            ModifierTab();
            LinkerTab();
            GUILayout.EndHorizontal();
        }

        void VitalTab()
        {
            if (GUILayout.Button("Vitals"))
            {
                _tabState = TabState.Vital;
            }
        }

        void AttributeTab()
        {
            if (GUILayout.Button("Attributes"))
            {
                _tabState = TabState.Attribute;
            }
        }

        void ModifierTab()
        {
            if (GUILayout.Button("Modifiers"))
            {
                _tabState = TabState.Modifier;
            }
        }

        void LinkerTab()
        {
            if (GUILayout.Button("Linkers"))
            {
                _tabState = TabState.Linker;
            }
        }
    }
}

