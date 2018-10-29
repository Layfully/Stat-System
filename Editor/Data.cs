using System;
using UnityEngine;

namespace AdrianGaborek.StatSystem.Editor
{
    [Serializable]
    public class Data<T, D> where T: StatObject
    {
        [SerializeField] 
        private T _stat;

        public T Stat
        {
            get { return _stat; }
            set { _stat = value; }
        }

        public virtual void OnGUI()
        {
        }

        public virtual void Clone(D d)
        {
        }
    }
}