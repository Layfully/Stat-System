using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class StatLinker : StatObject ,IStatValueChanged
    {        
        public StatLinker()
        {
            
        }
        
        [SerializeField]
        private Stat _stat;        //meant to be attribute

        public event EventHandler OnValueChanged;
        
        public StatLinker(Stat stat)
        {
            _stat = stat;
            
            IStatValueChanged statValueChangedEvent = _stat as IStatValueChanged;
            if (statValueChangedEvent != null)
            {
                statValueChangedEvent.OnValueChanged += OnLinkedStatValueChanged;
            }
        }
        
        public Stat Stat
        {
            get { return _stat; }
            set { _stat = value; }
        }

        public virtual int Value
        {
            get { return 0; }
        }

        private void OnLinkedStatValueChanged(object stat, EventArgs args)
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, null);
            }
        }
    }
}
