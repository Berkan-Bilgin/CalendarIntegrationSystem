using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseUser
    {
        public string UserName { get; set; }


        public ICollection<Event> Events { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
