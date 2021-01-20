using System;

namespace Samples
{
    public interface IButtonView
    {
        event Action Click;
    }
}