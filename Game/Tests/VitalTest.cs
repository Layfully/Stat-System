using UnityEngine;

namespace AdrianGaborek.StatSystem
{
    using System;

    public class VitalTest : MonoBehaviour
    {
        private StatCollection _stats;

        private void Start()
        {
            _stats = new DefaultStats();

            var health = _stats.GetStat<Vital>(StatType.Health);
            health.AddModifier(new StatModifier(2, false, ModifierType.TotalValueAdd));
            health.OnCurrentValueChanged += OnStatValueChange;

            DisplayStatValues();

            health.CurrentValue -= 75;
            
            DisplayStatValues();
        }

        void OnStatValueChange(object sender, EventArgs args)
        {
            Vital vital = (Vital) sender;
            if (vital != null)
            {
                Debug.Log(string.Format("Value {0}'s OnStatValueChange triggered", vital.Name));
            }
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
                    Vital vital = stat as Vital;

                    Debug.Log(vital != null
                        ? string.Format("Stat {0}'s value is {1}/{2}", vital.Name, vital.CurrentValue, vital.Value)
                        : string.Format("Stat {0}'s value is {1}", stat.Name, stat.Value));
                }
            });
        }
    }
}