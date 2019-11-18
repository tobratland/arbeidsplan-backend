using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbeidsplan.Contracts
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        IDayRepository Day { get; }
        void Save();
    }
}
