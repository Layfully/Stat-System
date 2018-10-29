/*
ScriptableObjectDatabase.cs
April 27, 2018
Adrian Gaborek - Layfully

Generic database that will store items to a ScriptableObject. ScriptableObject  can be read from at runtime
but not written or added to. They are immutable.

 */

using UnityEngine;
using System.Collections.Generic;

namespace AdrianGaborek
{
    public class ScriptableObjectDatabase<T> : ScriptableObject where T: class 
    {
        [SerializeField] protected List<T> _items = new List<T>();

        public List<T> Items
        {
            get { return _items; }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public T Get(int index)
        {
            return _items[index];
        }
    }
}
