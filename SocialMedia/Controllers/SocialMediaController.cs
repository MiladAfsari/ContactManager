using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SocialMediaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Add Social Info Of Users using UOW pattern
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public IActionResult AddSocialInfo(SocialMedia.Model.SocialMedia model)
        {
            if (!ModelState.IsValid) return BadRequest("Error in Input Model");

            _unitOfWork.SocialMediaInfo.Add(model);
            _unitOfWork.Complete();

            return Ok("SocialInfo Created");
        }
        /// <summary>
        /// Delete Social Info By Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteSocialInfo(SocialMedia.Model.SocialMedia model)
        {
            if (!ModelState.IsValid) return BadRequest("Error in Input Model");

            _unitOfWork.SocialMediaInfo.Delete(model);
            _unitOfWork.Complete();

            return Ok("SocialInfo Is Deleted");
        }
        /// <summary>
        /// Show Social Info Of Users By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetSocialInfo([FromQuery] int id)
        {
            if (!ModelState.IsValid) return BadRequest("Error in Input Model");

            var result = await _unitOfWork.SocialMediaInfo.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Show Social Info Of Users By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetSocialInfoByName([FromQuery] string name)
        {
            if (!ModelState.IsValid) return BadRequest("Error in Input Model");

            var result = _unitOfWork.SocialMediaInfo.GetSocialInfoByName(name);
            return Ok(result);
        }
    }
}
