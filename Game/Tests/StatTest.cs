using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    using System;

    public class StatTest : MonoBehaviour
    {
        private StatCollection _stats;

        private void Start()
        {
            _stats = new DefaultStats();

            DisplayStatValues();
            
            _stats.GetStat<Attribute>(StatType.Stamina).ScaleStat(5);
            _stats.GetStat<Attribute>(StatType.Wisdom).ScaleStat(10);
            
            DisplayStatValues();
        }

        void ForEachEnum<T>(Action<T> action)
        {
            if (action != null)
            {
                var statTypes = Enum.GetValues(typeof(T));
                foreach (var statType in statTypes)
                {
                    action((T) statType);
                }
            }
        }

        void DisplayStatValues()
        {
            ForEachEnum<StatType>((statType) =>
            {
                Stat stat = _stats.GetStat(statType);
                if (stat != null)
                {
                    Debug.Log(string.Format("Stat {0}'s value is {1}", stat.Name, stat.Value));
                }
            });
        }
    }
}