using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    [Keyless]
    public class VMIssues
    {        
        public IList<Beneficiary> beneficiary { get; set; }
        public IList<Fees> fees { get; set; }
        public IList<OfficialDocument> officialDocument { get; set; }        
        public RealtyContract realtyContract { get; set; }

    }
}
