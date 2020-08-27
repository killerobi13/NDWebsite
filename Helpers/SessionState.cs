using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Helpers
{

    public class SessionState
    {
        public IStringResource language { get; set; } = new EnglishStringResource();
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }

}
