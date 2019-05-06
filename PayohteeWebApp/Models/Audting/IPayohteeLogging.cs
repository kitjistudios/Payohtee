using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payohtee.Models.Audting
{
    interface IPayohteeLogging
    {
        void UserLogging();
        void ActionLogging();
        void ClassLogging();
        void MethodLogging();
    }
}
