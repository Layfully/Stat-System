using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public class StatModifiableData : Data<StatModifiable, StatModifiableData>
    {        
        [SerializeField]
        private int _modifierFlags = 0;
        private string[] _modifierOptions;

        private StatDatabaseType<ModifierDatabase, StatModifierData, StatModifier> _modifierDatabase;
        
        public StatModifiableData()
        {
            Stat = new StatModifiable();
        }
        
        public StatModifiableData(StatModifiableData statModifiableData)
        {
            Clone(statModifiableData);
        }
        
        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
            Stat.BaseValue = EditorGUILayout.IntField("BaseValue", Stat.BaseValue);
            DisplayModifer();
        }
    
        public override void Clone(StatModifiableData statModifiableData)
        {
            Stat = statModifiableData.Stat;
        }

        public void LoadModifierDatabase()
        {
            _modifierDatabase = StatEditor.ModifierDatabase;

            _modifierOptions = new string[_modifierDatabase.Count];
            for (int i = 0; i < _modifierDatabase.Count; i++)
            {
                _modifierOptions[i] = _modifierDatabase.Get(i).Stat.Name;
            }
        }

        public void DisplayModifer()
        {
            LoadModifierDatabase();
            
            _modifierFlags = EditorGUILayout.MaskField ("Modifiers", _modifierFlags, _modifierOptions);
            
            for (int i = 0; i < _modifierOptions.Length; i++)
            {
                if ((_modifierFlags & (1 << i)) == (1 << i))
                {
                    StatModifier modifier = _modifierDatabase.Get(i).Stat;

                    if (!Stat.StatModifiers.Contains(modifier))
                    {
                        Stat.StatModifiers.Add(_modifierDatabase.Get(i).Stat);
                    }
                }
            }   
        }
    }
}