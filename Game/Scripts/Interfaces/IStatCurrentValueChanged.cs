using System;

namespace AdrianGaborek.StatSystem
{
    public interface IStatCurrentValueChanged
    {
        event EventHandler OnCurrentValueChanged;
    }
}