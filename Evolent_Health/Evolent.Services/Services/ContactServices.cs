using AutoMapper;
using Evolent.DataModel.Model;
using Evolent.DataModel.UnitofWork;
using Evolent.Entities;
using Evolent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolent.Services.Services
{
    /// <summary>
    /// <see cref="ContactServices"/>  class which inherits <see cref="IContactServices"/> interface.
    /// </summary>
    public class ContactServices : IContactServices
    {
        #region Private variables
        private readonly UnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ContactServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public int CreateContact(ContactEntity ContactEntity)
        {
            int ContactID = 0;
            try
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<ContactEntity, Contact>();
                });
                var Contact = Mapper.Map<ContactEntity, Contact>(ContactEntity);
                _unitOfWork.ContactRepository.Insert(Contact);
                _unitOfWork.Save();
                ContactID = Contact.ContactID;
            }
            catch (Exception)
            {
                //To Do add log code here
            }
            return ContactID;
        }

        public int DeleteContact(int ContactID)
        {
            var success = 0;
            try
            {
                if (ContactID > 0)
                {
                    var product = _unitOfWork.ContactRepository.GetByID(ContactID);
                    if (product != null)
                    {

                        _unitOfWork.ContactRepository.Delete(product);
                        _unitOfWork.Save();
                        success = 1;
                    }
                }
            }
            catch (Exception)
            {
                //To Do add log code here
            }
            return success;
        }

        public ContactEntity GetContactById(int ContactID)
        {
            ContactEntity ContactModel = null;
            try
            {
                var contact = _unitOfWork.ContactRepository.GetByID(ContactID);
                if (contact != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Contact, ContactEntity>();
                    });

                    IMapper mapper = config.CreateMapper();
                    ContactModel = Mapper.Map<Contact, ContactEntity>(contact);
                }
            }
            catch (Exception)
            {
                //To Do add log code here
            }
            return ContactModel;
        }

        public List<ContactEntity> GetContacts()
        {
            List<ContactEntity> ContactsModel = null;
            try
            {
                var contacts = _unitOfWork.ContactRepository.GetAll().ToList();
                if (contacts != null)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<Contact, ContactEntity>();

                    });

                    ContactsModel = Mapper.Map<List<Contact>, List<ContactEntity>>(contacts).ToList();
                }
            }
            catch (Exception)
            {
                //To Do add log code here
            }
            return ContactsModel;
        }

        public int UpdateContact(int ContactID, ContactEntity ContactEntity)
        {
            var success = 0;
            try
            {
                if (ContactEntity != null)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<ContactEntity, Contact>();
                    });

                    var Contact = Mapper.Map<ContactEntity, Contact>(ContactEntity);

                    _unitOfWork.ContactRepository.Update(Contact);
                    _unitOfWork.Save();
                    success = 1;
                }
            }
            catch (Exception)
            {
                //To Do add log code here
            }
            return success;
        }
        #endregion
    }
}
