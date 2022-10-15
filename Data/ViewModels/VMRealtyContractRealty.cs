using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    [Keyless]
    public class VMRealtyContractRealty
    {
        public VMRealty realty { get; set; }
        public VMRealtyContract realtyContract { get; set; }
    }
}
