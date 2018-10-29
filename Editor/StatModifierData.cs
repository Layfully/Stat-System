using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public class StatModifierData : Data<StatModifier, StatModifierData>
    {
        public StatModifierData()
        {
            Stat = new StatModifier();
        }

        public StatModifierData(StatModifierData modiferData)
        {
            Clone(modiferData);
        }

        public override void Clone(StatModifierData statModifierData)
        {
            Stat = statModifierData.Stat;
        }

        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
            Stat.ModifierType = (ModifierType)EditorGUILayout.EnumPopup("Modifier type", Stat.ModifierType);
            Stat.Stacks = EditorGUILayout.Toggle("Stackable", Stat.Stacks);
            Stat.Value = EditorGUILayout.FloatField("Modifier Value", Stat.Value);
        }
    }
}