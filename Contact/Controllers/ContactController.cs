using Contact.DTO;
using Contact.Model;
using Contact.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IService _service;
        public ContactController(IService service)
        {
            _service = service;
        }
        /// <summary>
        /// If model.Id Parameter is null then select all records
        /// if model.Id not null then select by userId 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Get")]
        public async Task<SPResult<ContactListOut>> GetListByIdOrAll([FromBody]ContactListIn model)
        {
            if (!ModelState.IsValid) return null;
            string SpName = "Glb_Sp_GetContactInfo";
            return await _service.ListAsync<ContactListIn, ContactListOut>(model, SpName);
        }
        /// <summary>
        /// Add Contact Info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<SPResult> AddContact([FromBody] ContactIn model)
        {
            if (!ModelState.IsValid) return new SPResult { ErrorCode = 1, ErrorMessage = "ورودی نامعتبر" };
            string SpName = "Glb_Sp_AddContactInfo";
            return await _service.AddAsync(model, SpName);
        }
        /// <summary>
        /// Delete Contact Info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public async Task<SPResult> DeleteContact([FromBody] ContactDelIn model)
        {
            if (!ModelState.IsValid) return new SPResult { ErrorCode = 1, ErrorMessage = "ورودی نامعتبر" };
            string SpName = "Glb_Sp_DeleteContactInfo";
            return await _service.AddAsync(model, SpName);
        }
    }
}
