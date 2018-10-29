using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    using System.Collections.Generic;
    using System;

    public class StatCollection : MonoBehaviour
    {
        private Dictionary<StatType, Stat> _statsDictionary;

        public Dictionary<StatType, Stat> StatsDictionary
        {
            get { return _statsDictionary ?? (_statsDictionary = new Dictionary<StatType, Stat>()); }
        }

        public StatCollection()
        {
            _statsDictionary = new Dictionary<StatType, Stat>();
            ConfigureStats();
        }

        protected virtual void ConfigureStats()
        {
        }

        public bool ContainStat(StatType statType)
        {
            return StatsDictionary.ContainsKey(statType);
        }

        public Stat GetStat(StatType statType)
        {
            return ContainStat(statType) ? StatsDictionary[statType] : null;
        }

        public T GetStat<T>(StatType type) where T : Stat
        {
            return GetStat(type) as T;
        }

        protected T CreateStat<T>(StatType statType) where T : Stat
        {
            T stat = Activator.CreateInstance<T>();
            StatsDictionary.Add(statType, stat);
            return stat;
        }

        protected T CreateOrGetStat<T>(StatType statType) where T : Stat
        {
            T stat = GetStat<T>(statType) ?? CreateStat<T>(statType);

            return stat;
        }

        public void AddModifier(StatType target, StatModifier modifier)
        {
            AddModifier(target, modifier, false);
        }
        
        public void AddModifier(StatType target, StatModifier modifier, bool update)
        {
            if (ContainStat(target))
            {
                var modifierStat = GetStat(target) as IStatModifiable;
                if (modifierStat != null)
                {
                    modifierStat.AddModifier(modifier);
                    if (update)
                    {
                        modifierStat.UpdateModifiers();
                    }
                }
                else
                {
                    Debug.Log("Tried adding modifier to non modifiable stat");
                }
            }
            else
            {
                Debug.Log("Tried adding modifier to stat that doesn't exist");
            }
        }

        public void RemoveModifier(StatType target, StatModifier modifier)
        {
            RemoveModifier(target, modifier, false);
        }

        public void RemoveModifier(StatType target, StatModifier modifier, bool update)
        {
            if (ContainStat(target))
            {
                var modifierStat = GetStat(target) as IStatModifiable;
                if (modifierStat != null)
                {
                    modifierStat.RemoveModifier(modifier);
                    if (update)
                    {
                        modifierStat.UpdateModifiers();
                    }
                }
                else
                {
                    Debug.Log("Tried removing modifier to non modifiable stat");
                }
            }
            else
            {
                Debug.Log("Tried removing modifier to stat that doesn't exist");
            }
        }

        public void ClearAllModifiers()
        {
            ClearAllModifiers(false);
        }
        
        public void ClearAllModifiers(bool update)
        {
            foreach (var key in StatsDictionary.Keys)
            {
                ClearModifier(key, update);
            }
        }

        public void ClearModifier(StatType target)
        {
            ClearModifier(target, false);
        }

        public void ClearModifier(StatType target, bool update)
        {
            if (ContainStat(target))
            {
                var modifierStat = GetStat(target) as IStatModifiable;
                if (modifierStat != null)
                {
                    modifierStat.ClearModifiers();
                    if (update)
                    {
                        modifierStat.UpdateModifiers();
                    }
                }
                else
                {
                    Debug.Log("Tried clearing modifier to non modifiable stat");
                }
            }
            else
            {
                Debug.Log("Tried clearing modifier to stat that doesn't exist");
            }
        }

        public void UpdateAllModifiers()
        {
            foreach (var key in StatsDictionary.Keys)
            {
                UpdateModifiers(key);
            }
        }
        
        public void UpdateModifiers(StatType target)
        {
            if (ContainStat(target))
            {
                var modifierStat = GetStat(target) as IStatModifiable;
                if (modifierStat != null)
                {
                    modifierStat.UpdateModifiers();
                }
                else
                {
                    Debug.Log("Tried updating modifier to non modifiable stat");
                }
            }
            else
            {
                Debug.Log("Tried updating modifier to stat that doesn't exist");
            }
        }
    }
}