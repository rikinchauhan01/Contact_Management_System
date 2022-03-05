using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BackendService.Models
{
    [MessageContract]
    public class GroupContact
    {
        public GroupContact()
        {
        }

        [MessageHeader]
        public int Id { get; set; }

        [MessageHeader]
        public int ContactId { get; set; }

        [MessageHeader]
        public int GroupId { get; set; }
    }
}
