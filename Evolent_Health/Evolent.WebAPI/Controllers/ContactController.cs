using Evolent.Entities;
using Evolent.Services.Interfaces;
using System.Web.Http;

namespace Evolent.WebAPI.Controllers
{
    /// <summary>
    /// <see cref="ContactController"/> class which inherits <see cref="ApiController"/> class. 
    /// </summary>
    public class ContactController : ApiController
    {
        #region Private variable
        private readonly IContactServices _contactServices;
        #endregion

        #region Constructor
        
        public ContactController(IContactServices ContactServices)
        {
            _contactServices = ContactServices;
        }

        #endregion

        #region Methods
        
        // GET: api/Contact
        /// <summary>
        ///  Get All Contact By 
        /// Created Date: 10 Apr 2018 
        /// Created By : Omkar M.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var product = _contactServices.GetContacts();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);


        }

        // GET: api/Contact/5
        /// <summary>
        /// Get Contact By Contact ID 
        /// Created Date: 10 Apr 2018 
        /// Created By : Omkar M.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetContact(int id)
        {
            var product = _contactServices.GetContactById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Contact
        /// <summary>
        ///  Insert contact information
        /// Created Date: 10 Apr 2018 
        /// Created By : Omkar M.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody] ContactEntity contactEntity)
        {
            var newcontact = _contactServices.CreateContact(contactEntity);
            if (newcontact != 0)
            {
                return Ok(contactEntity);
            }
            else
            {
                return Conflict();
            }
        }

        // PUT: api/Contact/5
        /// <summary>
        ///  Update contact information
        /// Created Date: 10 Apr 2018 
        /// Created By : Omkar M.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody] ContactEntity contactEntity)
        {
            if (contactEntity.ContactID > 0)
            {
                int newcontact = _contactServices.UpdateContact(contactEntity.ContactID,contactEntity);
                if (newcontact != 0)
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Contact/5
        /// <summary>
        ///  Delete contact information
        /// Created Date: 10 Apr 2018 
        /// Created By : Omkar M.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            int status = _contactServices.DeleteContact(id);
            if (status > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        #endregion
    }
}
