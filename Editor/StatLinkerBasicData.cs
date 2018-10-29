using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public class StatLinkerBasicData : Data<StatLinkerBasic, StatLinkerBasicData>
    {
        private int _selectedAttributeIndex;
        private string[] _attributeOptions;
        private StatDatabaseType<AttributeDatabase, AttributeData, Attribute> _attributeDatabase;
        
        public StatLinkerBasicData()
        {
            Stat = new StatLinkerBasic();
        }
        
        public StatLinkerBasicData(StatLinkerBasicData statLinkerBasicData)
        {
            Clone(statLinkerBasicData);
        }

        public override void Clone(StatLinkerBasicData statData)
        {
            Stat = statData.Stat;
        }

        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
            Stat.Ratio = EditorGUILayout.FloatField("Ratio", Stat.Ratio);
            DisplayLinker();
        }
        
        public int SelectedAttributeIndex
        {
            get { return _selectedAttributeIndex; }
        }
        
        public void LoadAttributeDatabase()
        {
            _attributeDatabase = StatEditor.AttributeDatabase;

            _attributeOptions = new string[_attributeDatabase.Count];
            for (int i = 0; i < _attributeDatabase.Count; i++)
            {
                _attributeOptions[i] = _attributeDatabase.Get(i).Stat.Name;
            }
        }
        
        public void DisplayLinker()
        {
            LoadAttributeDatabase();
            int attributeIndex = 0;

            if (Stat != null)
            {
                attributeIndex = _attributeDatabase.GetIndex(Stat.Name);
            }

            if (attributeIndex == -1)
            {
                attributeIndex = 0;
            }
            _selectedAttributeIndex = EditorGUILayout.Popup("Linked stat", attributeIndex, _attributeOptions);
            Stat.Stat = _attributeDatabase.Get(SelectedAttributeIndex).Stat;
        }
    }
}