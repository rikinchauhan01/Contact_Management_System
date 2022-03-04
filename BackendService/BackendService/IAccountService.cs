using BackendService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BackendService
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        User Register(User user);

        [OperationContract]
        User Login(User user);
    }
}
