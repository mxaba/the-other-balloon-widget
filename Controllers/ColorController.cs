using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using the_other_balloon_widget.Database;
using the_other_balloon_widget.Models;
using the_other_balloon_widget.Models.Logic;

namespace the_other_balloon_widget.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IColorLogic colorLogic;
        public ColorController([FromServices]IColorLogic colorLogic){
            this.colorLogic = colorLogic;
        }


        [HttpPost("AddUpdateColor")]
        public string CreateUpdateColor([FromBody] Colors color){
            
            return "";
        }

    }
}