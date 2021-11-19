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
    [Route("api/[controller]/[action]")]
    public class ColorController : ControllerBase
    {
        private readonly IColorLogic colorLogic;
        public ColorController([FromServices]IColorLogic colorLogic){
            this.colorLogic = colorLogic;
        }

        [HttpPost("{color}")]
        public string CreateUpdateColor(string color){
            var colorModel = new Colors();
            var guid = Guid.NewGuid();
            colorModel.Id = guid.ToString();
            colorModel.Name = color;
            colorModel.Type = "upAndComing";
            return colorLogic.AddColor(colorModel);
        }

        [HttpPost]
        public string updateRefresh(){
            return colorLogic.UpdatedTrending();
        }
        
        [HttpGet("{type}")]
        public List<Colors> updateRefresh(string type){
            return colorLogic.GetColorByType(type);
        }

        [HttpPost("{id}")]
        public string SubractCurrentColor(string id){
            colorLogic.subCurrentColor(id);
            return "";
        }

        [HttpGet]
        public IEnumerable<Colors> GetAllColors(){
            return colorLogic.GetAllColors();
        }

    }
}