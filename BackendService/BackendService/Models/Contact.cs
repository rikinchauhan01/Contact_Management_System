﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BackendService.Models
{
    [MessageContract]
    public class Contact
    {
        public Contact()
        {

        }

        [MessageHeader]
        public int ContactId { get; set; }

        [MessageHeader]
        public int UserId { get; set; }

        [MessageBodyMember]
        public string Name { get; set; }

        [MessageBodyMember]
        public string Email { get; set; }

        [MessageBodyMember]
        public string PhoneNumber { get; set; }

        [MessageBodyMember]
        public string Description { get; set; }

        [MessageBodyMember]
        public string PhotoPath { get; set; }
    }
}
