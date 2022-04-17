using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cedid.AkilliLojistik.Parameters
{
    public interface IParameterReferance
    {
        Task FillParameterRefs(object o);
    }
}
