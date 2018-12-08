using Prism.Mvvm;
using System.Collections.Generic;

namespace DnnSummit.ViewModels
{
    public class InfoViewModel : BindableBase
    {
        public string Title => "Info";
        public IEnumerable<string> Pages => new[]
        {
            "Page 1",
            "Page 2",
            "Page 3"
        };
    }
}
