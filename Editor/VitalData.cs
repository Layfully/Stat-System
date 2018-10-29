using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public class VitalData : Data<Vital, VitalData>
    {
        [SerializeField] private int _linkerFlags = 0;
        [SerializeField] private int _modifierFlags = 0;
        private StatDatabaseType<LinkerDatabase, StatLinkerBasicData, StatLinkerBasic> _linkerDatabase;
        private StatDatabaseType<ModifierDatabase, StatModifierData, StatModifier> _modifierDatabase;
        private string[] _linkerOptions;
        private string[] _modifierOptions;

        public VitalData()
        {
            Stat = new Vital();
        }

        public VitalData(VitalData vitalData)
        {
            Clone(vitalData);
        }

        public override void Clone(VitalData vitalData)
        {
            Stat = vitalData.Stat;
        }

        public override void OnGUI()
        {
            Stat.Name = EditorGUILayout.TextField("Name", Stat.Name);
            Stat.BaseValue = EditorGUILayout.IntField("BaseValue", Stat.BaseValue);
            Stat.StatLevelValue = EditorGUILayout.IntField("StatLevel", Stat.StatLevelValue);
            Stat.CurrentValue = EditorGUILayout.IntField("CurrentValue", Stat.CurrentValue);
            DisplayModifer();
            DisplayLinker();
        }

        public void LoadLinkerDatabase()
        {
            _linkerDatabase = StatEditor.LinkerDatabase;
            _linkerOptions = new string[_linkerDatabase.Count];
            
            for (int i = 0; i < _linkerDatabase.Count; i++)
            {
                _linkerOptions[i] = _linkerDatabase.Get(i).Stat.Name;
            }
        }

        public void DisplayLinker()
        {
            LoadLinkerDatabase();

            _linkerFlags = EditorGUILayout.MaskField("Linkers", _linkerFlags, _linkerOptions);

            for (int i = 0; i < _linkerOptions.Length; i++)
            {
                if ((_linkerFlags & (1 << i)) == (1 << i))
                {
                    StatLinkerBasic linker = _linkerDatabase.Get(i).Stat;

                    if (!Stat.StatLinkers.Contains(linker))
                    {
                        Stat.StatLinkers.Add(_linkerDatabase.Get(i).Stat);
                    }
                }
            }
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

            _modifierFlags = EditorGUILayout.MaskField("Modifiers", _modifierFlags, _modifierOptions);

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