using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ClassLibraryCS
{
    public interface IJSONSerializer
    {
        Boolean readFromJSON(string file);
        Boolean writeToJSON(string file);
    }
}
