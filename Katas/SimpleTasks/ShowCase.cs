using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class ShowCase
    {
        private readonly IEnumerable<ILister> listers;

        public ShowCase(IEnumerable<ILister> listers) => this.listers = listers;
         
        public void Run()
        {
            this.listers.ToList().ForEach(lister => lister.ShowWhatYouCan());
        }
    }
}
