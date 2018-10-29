using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public class StatLinkerData : Data<StatLinker, StatLinkerData>
    {
        private int _selectedAttributeIndex;
        private string[] _attributeOptions;
        
        private StatDatabaseType<AttributeDatabase, AttributeData, Attribute> _attributeDatabase;

        public StatLinkerData()
        {
        }
        
        public StatLinkerData(StatLinkerData statLinkerData)
        {
            Clone(statLinkerData);
        }

        public override void Clone(StatLinkerData statData)
        {
            Stat = statData.Stat;
        }

        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
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

            if (Stat.Stat != null)
            {
                attributeIndex = _attributeDatabase.GetIndex(Stat.Stat.Name);
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