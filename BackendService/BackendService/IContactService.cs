using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BackendService.Models;

namespace BackendService
{
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        List<Contact> GetContacts(int userId);

        [OperationContract]
        Contact AddContact(Contact contact);

        [OperationContract]
        Contact GetContact(Contact contact);

        [OperationContract]
        Contact UpdateContact(Contact contact);

        [OperationContract]
        Contact DeleteContact(Contact contact);

        [OperationContract]
        bool UploadToTempFolder(byte[] pFileBytes, string pFileName);

        [OperationContract]
        byte[] GetFileFromFolder(string pFileName);
    }
}
