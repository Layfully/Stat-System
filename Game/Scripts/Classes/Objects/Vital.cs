using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class Vital : Attribute, IStatCurrentValueChanged
    {
        public event EventHandler OnCurrentValueChanged;
        
        [SerializeField]
        private int _statCurrentValue;

        public int CurrentValue
        {
            get { return _statCurrentValue; }
            set
            {
                if (_statCurrentValue != value)
                {
                    TriggerCurrentValueChange();
                    _statCurrentValue = Mathf.Clamp(value, 0, Value);
                }
            }
        }
        
        public Vital()
        {
            _statCurrentValue = 0;
        }

        public void SetCurrentValueToMax()
        {
            CurrentValue = Value;
        }
        
        private void TriggerCurrentValueChange()
        {
            if (OnCurrentValueChanged != null)
            {
                OnCurrentValueChanged(this, null);
            }
        }
    }
}