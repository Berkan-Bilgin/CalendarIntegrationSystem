using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Domain.Entities
{
    public class UserOperationClaim : Core.Entities.UserOperationClaim
    {
        public virtual OperationClaim OperationClaim { get; set; }

        public virtual User User { get; set; }
    }
}
