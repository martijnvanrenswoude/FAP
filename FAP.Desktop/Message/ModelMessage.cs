using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAP.Desktop.Message
{
    public struct ModelMessage<T>
        where T : class
    {
        // FromWho represent the name of the ViewModel that we want to receive data from
        public string FromWho { get; set; }
        public T Model { get; set; }
    }
}
