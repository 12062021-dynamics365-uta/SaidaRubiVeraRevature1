using Microsoft.AspNetCore.Mvc;
using SweetnSaltyBusiness;
using SweetnSaltyModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetnSaltyController : Controller
    {
        private readonly ISweetnSaltyBusinessClass _businessClass;
        //constructor
        public SweetnSaltyController(ISweetnSaltyBusinessClass ISweetnSaltyBusinessClass)
        {
            this._businessClass = ISweetnSaltyBusinessClass;
        }


        [HttpPost]
        [Route("postaflavor/{flavor}")]
        public async Task<ActionResult<Flavor>> PostFlavor(string flavor)
        {
            Flavor f = await this._businessClass.PostFlavor(flavor);
            if (f != null)
            {
                return Created($"http://5001/sweetnsalty/postaflavor/{f.FlavorId}", f);
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("postperson/{fname}/{lname}/{flavor}")]
        public async Task<ActionResult<Person>> PostPerson(string fname, string lname, string flavor)
        {
            Person p = await this._businessClass.PostPerson(fname, lname, flavor);
            List<Flavor> flavors = p.Flavors;
            string flavorLiked = flavors[flavors.Count - 1].FlavorType;
            if (p != null)
            {
                return Created($"http://5001/sweetnsalty/postaperson/{p.Fname}/{p.Lname}/{flavorLiked}", p);
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("getperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> GetPerson(string fname, string lname)
        {
            Person p = await this._businessClass.GetPerson(fname, lname);
            if (p != null)
            {
                return Created($"http://5001/sweetnsalty/getaperson/{p.Fname}/{p.Lname}", p);
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("getpersonsandflavors/{id}")]
        public async Task<ActionResult<Person>> GetPersonAndFlavors(int id)
        {
            Person p = await this._businessClass.GetPerson(id);
            if (p != null)
            {
                return Created($"http://5001/sweetnsalty/getaperson/{p.Fname}/{p.Lname}/{p.Flavors}", p);
            }
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("getlistofflavors")]
        public async Task<ActionResult<List<Flavor>>> GetAllFlavors()
        {
            List<Flavor> flavors = await this._businessClass.GetFlavors();
            if (flavors != null)
            {
                return Created($"http://5001/sweetnsalty/getaperson/{flavors}", flavors);
            }
            else
                return BadRequest();
        }


    }
}