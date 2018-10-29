using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class StatModifier : StatObject
    {
        [SerializeField] private ModifierType _modifierType;
        [SerializeField] private float _value;

        public event EventHandler OnValueChanged;

        public int Order
        {
            get
            {
                switch (_modifierType)
                {        
                    case ModifierType.BaseValuePercent:
                        return 1;
                    case ModifierType.BaseValueAdd:
                        return 2;
                    case ModifierType.TotalValuePercent:
                        return 3;
                    case ModifierType.TotalValueAdd:
                        return 4;
                    default:
                        return 0;
                }
            }
        }

        public bool Stacks { get; set; }

        public float Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (OnValueChanged != null)
                    {
                        OnValueChanged(this, null);
                    }
                }
            }
        }

        public ModifierType ModifierType
        {
            get { return _modifierType; }
            set { _modifierType = value; }
        }

        public StatModifier()
        {
        }

        public StatModifier(float value)
        {
            _value = value;
            Stacks = false;
        }

        public StatModifier(float value, bool stacks)
        {
            _value = value;
            Stacks = stacks;
        }

        public StatModifier(float value, bool stacks, ModifierType modifierType)
        {
            _value = value;
            Stacks = stacks;
            _modifierType = modifierType;
        }

        public int ApplyModifier(int statValue, float modifierValue)
        {
            switch (_modifierType)
            {
                case ModifierType.BaseValueAdd:
                    return (int) (modifierValue);
                case ModifierType.BaseValuePercent:
                    return (int) (statValue * modifierValue);
                case ModifierType.TotalValueAdd:
                    return (int) (modifierValue);
                case ModifierType.TotalValuePercent:
                    return (int) (statValue * modifierValue);
                default:
                    return 0;
            }
        }
    }
}