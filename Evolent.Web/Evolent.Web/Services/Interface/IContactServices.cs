using Evolent.Web.Models;
using System.Collections.Generic;

namespace Evolent.Web.Services.Interface
{
    /// <summary>
    /// <see cref="IContactServices"/> interface.
    /// </summary>
    public interface IContactServices
    {
        List<VMContact> GetContacts();
        VMContact GetContactById(int ContactID);
        int CreateContact(VMContact ContactEntity);
        int UpdateContact(VMContact ContactEntity);
        int DeleteContact(int ContactID);

    }
}
