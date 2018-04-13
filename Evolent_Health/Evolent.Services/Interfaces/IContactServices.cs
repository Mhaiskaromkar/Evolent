using Evolent.Entities;
using System.Collections.Generic;

namespace Evolent.Services.Interfaces
{
    /// <summary>
    /// <see cref="IContactServices"/> interface.
    /// </summary>
    public interface IContactServices
    {
        List<ContactEntity> GetContacts();
        ContactEntity GetContactById(int ContactID);
        int CreateContact(ContactEntity ContactEntity);
        int UpdateContact(int UserID, ContactEntity ContactEntity);
        int DeleteContact(int UserID);
    }
}
