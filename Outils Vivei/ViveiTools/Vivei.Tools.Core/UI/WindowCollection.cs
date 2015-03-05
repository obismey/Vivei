using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core.UI
{
    public interface IWindowCollection : IEnumerable<IWindow>
    {
        IWindow this[string name] { get ; }

        IWindow this[int index] { get; }

        IWindow this[object view] { get; }
    }
}
