﻿using HouseForSale_Api.Repositories.ContactRepository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HouseForSale_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }
    }
}