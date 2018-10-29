using UnityEngine.Timeline;

namespace AdrianGaborek.StatSystem
{
    public class DefaultStats : StatCollection
    {
        protected override void ConfigureStats()
        {
            var stamina = CreateOrGetStat<Attribute>(StatType.Stamina);
            stamina.Name = "Stamina";
            stamina.BaseValue = 10;

            var wisdom = CreateOrGetStat<Attribute>(StatType.Wisdom);
            wisdom.Name = "Wisdom";
            wisdom.BaseValue = 10;
            
            var health = CreateOrGetStat<Vital>(StatType.Health);
            health.Name = "Health";
            health.BaseValue = 100;
            health.AddLinker(new StatLinkerBasic(CreateOrGetStat<Attribute>(StatType.Stamina), 13));
            health.UpdateLinkers();
            health.SetCurrentValueToMax();
            
            var mana = CreateOrGetStat<Vital>(StatType.Mana);
            mana.Name = "Mana";
            mana.BaseValue = 100;
            mana.AddLinker(new StatLinkerBasic(CreateOrGetStat<Attribute>(StatType.Wisdom), 23));
            mana.UpdateLinkers();
            mana.SetCurrentValueToMax();
        }
    }
}