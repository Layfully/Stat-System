using System;
using UnityEditor;
using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    [Serializable]
    public class StatObject
    {        
        [SerializeField]
        private string _name;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}