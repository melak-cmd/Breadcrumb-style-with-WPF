using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Breadcrumb_style_with_WPF
{
    public interface IParent
    {
        IParent Parent { get; }
    }
}