using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class Attribute : StatModifiable, IStatScalable, IStatLinkable
    {
        [SerializeField] private int _statLevelValue;
        private int _statLinkerValue;
        [SerializeField] protected List<StatLinkerBasic> _statLinkers;

        public override int BaseValue
        {
            get { return base.BaseValue + StatLevelValue + StatLinkerValue; }
        }

        public int StatLevelValue
        {
            get { return _statLevelValue; }
            set { _statLevelValue = value; }
        }

        public int StatLinkerValue
        {
            get { return _statLinkerValue; }
        }

        public List<StatLinkerBasic> StatLinkers
        {
            get { return _statLinkers; }
        }
        
        public Attribute()
        {
            _statLinkers = new List<StatLinkerBasic>();
        }

        public virtual void ScaleStat(int level)
        {
            _statLevelValue = level;
            TriggerValueChange();
        }

        public void AddLinker(StatLinkerBasic linker)
        {
            _statLinkers.Add(linker);

            linker.OnValueChanged += OnLinkerValueChanged;
        }

        public void ClearLinkers()
        {
            foreach (var linker in _statLinkers)
            {
                linker.OnValueChanged -= OnLinkerValueChanged;
            }

            _statLinkers.Clear();
        }

        public void UpdateLinkers()
        {
            _statLinkerValue = 0;
            foreach (StatLinker link in _statLinkers)
            {
                _statLinkerValue += link.Value;
            }
        }

        public void OnLinkerValueChanged(object linker, EventArgs args)
        {
            UpdateLinkers();
        }
    }
}