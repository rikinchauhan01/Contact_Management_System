using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BackendService.Models
{
    [MessageContract]
    public class Group
    {
        public Group()
        {
        }

        [MessageHeader]
        public int GroupId { get; set; }

        [MessageHeader]
        public int UserId { get; set; }

        [MessageBodyMember]
        public string Name { get; set; }

        [MessageBodyMember]
        public string Description { get; set; }
    }
}
