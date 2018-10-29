using System;

namespace AdrianGaborek.StatSystem
{
    public interface IStatValueChanged
    {
        event EventHandler OnValueChanged;
    }
}