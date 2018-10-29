using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public abstract class StatObjectData : Data<StatObject, StatObjectData>
    {
        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
        }
        
        public override void Clone(StatObjectData statData)
        {
            Stat = statData.Stat;
        }
    }
}