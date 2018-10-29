using System;
using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class Stat : StatObject
    {
        [SerializeField]
        private int _baseValue;

        public virtual int BaseValue
        {
            get { return _baseValue; }
            set { _baseValue = value; }
        }

        public virtual int Value
        {
            get { return 0; }
        }
    }
}