using prjWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace prjWebApp.Controllers
{
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[] {
            new Contact(){
                Id = 1,
                FirstName = "Luis",
                LastName = "Pereira"
            },
            new Contact(){
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne"
            },
            new Contact(){
                Id = 3,
                FirstName = "Bruce",
                LastName = "Benner"
            }
        };
        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(x => x.Id.Equals(id));
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST: api/Contact
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {
            List<Contact> _listContact = contacts.ToList();
            newContact.Id = _listContact.Count + 1;
            _listContact.Add(newContact);
            contacts = _listContact.ToArray();
            return contacts;
        }

        // PUT: api/Contact/5
        public IEnumerable<Contact> Put(int id, [FromBody]Contact changedContact)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(x => x.Id.Equals(id));
            if (contact != null)
            {
                contact.FirstName = changedContact.FirstName;
                contact.LastName = changedContact.LastName;
            }


            return contacts;
        }

        // DELETE: api/Contact/5
        public IEnumerable<Contact> Delete(int id)
        {
            return contacts.Where<Contact>(x => x.Id != id).ToArray();
        }
    }
}
