using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserOperationClaim : Entity
    {
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
