using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class StatLinkerBasic : StatLinker
    {
        public StatLinkerBasic()
        {
            
        }
        
        [SerializeField]
        private float _ratio;

        public override int Value
        {
            get { return (int) (Stat.Value * _ratio); }
        }

        public float Ratio
        {
            get { return _ratio; }
            set { _ratio = value; }
        }

        public StatLinkerBasic(Stat stat, float ratio) : base(stat)
        {
            _ratio = ratio;
        }
    }
}