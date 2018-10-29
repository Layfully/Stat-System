namespace AdrianGaborek.StatSystem
{
    public interface IStatLinkable
    {
        int StatLinkerValue { get; }
        
        void AddLinker(StatLinkerBasic linker);
        void ClearLinkers();
        void UpdateLinkers();
    }
}