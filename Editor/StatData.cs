using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public abstract class StatData : Data<Stat, StatData>
    {        
        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
            Stat.BaseValue = EditorGUILayout.IntField("BaseValue", Stat.BaseValue);
        }
        
        public override void Clone(StatData statData)
        {
            Stat = statData.Stat;
        }
    }
}