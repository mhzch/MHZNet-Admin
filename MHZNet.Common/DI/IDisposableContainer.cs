using System;

namespace MHZNet.Common.DI;

public interface IDisposableContainer : IDisposable
{
    void AddDisposableObj(IDisposable disposableObj);
}
