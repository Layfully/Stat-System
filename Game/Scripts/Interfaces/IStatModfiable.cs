namespace AdrianGaborek.StatSystem
{
    public interface IStatModifiable
    {
        int StatModifierValue { get; }

        void AddModifier(StatModifier modifier);
        void RemoveModifier(StatModifier modifier);
        void ClearModifiers();
        void UpdateModifiers();
    }
}

