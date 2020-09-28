using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public enum EPackageState:byte
    {
        En_espera=1,
        En_camino=2,
        Retrasado=3,
        En_terminal_destino=4
    }
}
