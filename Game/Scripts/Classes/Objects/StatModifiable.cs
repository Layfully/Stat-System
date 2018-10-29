using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.Serialization;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class StatModifiable : Stat, IStatModifiable, IStatValueChanged
    {
        [SerializeField]
        private List<StatModifier> _statModifiers;
        private int _statModifierValue;

        public event EventHandler OnValueChanged;

        public override int Value
        {
            get { return BaseValue + StatModifierValue; }
        }

        public int StatModifierValue
        {
            get { return _statModifierValue; }
        }

        public List<StatModifier> StatModifiers
        {
            get { return _statModifiers; }
        }

        public StatModifiable()
        {
            _statModifiers = new List<StatModifier>();
            _statModifierValue = 0;
        }

        protected void TriggerValueChange()
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, null);
            }
        }

        public void AddModifier(StatModifier modifier)
        {
            _statModifiers.Add(modifier);
            modifier.OnValueChanged += OnModifierValueChanged;
        }

        public void RemoveModifier(StatModifier modifier)
        {            
            _statModifiers.Remove(modifier);
            modifier.OnValueChanged -= OnModifierValueChanged;
        }
        
        public void ClearModifiers()
        {
            foreach (var modifier in _statModifiers)
            {
                modifier.OnValueChanged -= OnModifierValueChanged;
            }
            _statModifiers.Clear();
        }

        public void UpdateModifiers()
        {
            _statModifierValue = 0;

            var orderGroups = _statModifiers.OrderBy(m => m.Order).GroupBy(m => m.Order);

            foreach (var modifierGroup in orderGroups)
            {
                float sum = 0;
                float max = 0;

                foreach (var modifier in modifierGroup)
                {
                    if (modifier.Stacks)
                    {
                        sum += modifier.Value;
                    }
                    else
                    {
                        if (modifier.Value > max)
                        {
                            max = modifier.Value;
                        }
                    }

                    _statModifierValue += modifierGroup.First()
                        .ApplyModifier(BaseValue + _statModifierValue,sum > max ? sum : max);
                }
            }

            TriggerValueChange();
        }

        public void OnModifierValueChanged(object modifier, EventArgs args)
        {
            UpdateModifiers();
        }
    }
}