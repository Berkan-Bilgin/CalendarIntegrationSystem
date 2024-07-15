using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Domain.Entities
{
    public class OperationClaim : Core.Entities.OperationClaim
    {
        public virtual List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
