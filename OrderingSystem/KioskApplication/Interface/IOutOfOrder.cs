using System;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Options
{
    public interface IOutOfOrder
    {
        event EventHandler outOfOrder;

    }
}
