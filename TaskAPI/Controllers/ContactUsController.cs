using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.DTOs.Request;
using TaskAPI.Models;
using TaskAPI.Unit_of_Work;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ContactUsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactUsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("contact us")]
        public IActionResult ContactUs([FromBody] ContactUsRequest contactUsRequest)
        {
            var newMess = contactUsRequest.Adapt<ContactUs>(); 
            _unitOfWork.ContactUs.Create(newMess);
            _unitOfWork.Commit();
            return CreatedAtAction(nameof(ContactUs), new { id = newMess.Id }, contactUsRequest);
        }
    }
}
