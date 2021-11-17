using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using the_other_balloon_widget.Database;

namespace the_other_balloon_widget.Models.Logic
{
    public class ColorLogic : IColorLogic
    {
        private readonly ApplicationDbContext _db;
        public ColorLogic(ApplicationDbContext db) => _db = db;

        public IEnumerable<Colors> GetAllColors() {
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            
            return colorFromDatabase;

        }

        private int timeNow() {
            var timeNow = DateTime.Now;
            return (timeNow.Minute) / 1000;
        }

        public string UpdatedTrending(){
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            foreach (var itemColor in colorFromDatabase)
            {
                if (itemColor.Type == "trending")
                {
                    if(itemColor.Timestamp < timeNow()){
                        itemColor.Type = "popular";
                        itemColor.Counter = 9;
                        _db.Colors.Update(itemColor);
                        _db.SaveChanges();
                    }
                    // color.Id = itemColor.Id;
                }
            }
            return "Updated";
        }

        public string DeleteColor(int id){
            var obj = _db.Colors.Find(id);
            _db.Colors.Remove(obj);
            _db.SaveChanges();
            return "Deleted Successfully";
        }

        public List<Colors> GetColorByType(string colorType){
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            var sortedColors = new List<Colors>();
            foreach (var itemColor in colorFromDatabase)
            {
                if (itemColor.Type == colorType)
                {
                    sortedColors.Add(itemColor);
                }
            }
            return sortedColors;
        } 

        public string AddColor(Colors color)
        {
            Console.WriteLine(color);
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            color.Timestamp = timeNow();
            var guid = Guid.NewGuid();
            string message;
            var _id = "";
            
            foreach (var itemColor in colorFromDatabase)
            {
                if (itemColor.Name == color.Name)
                {
                    _id = itemColor.Id;
                    break;
                }
            }

            if (colorFromDatabase.Count() > 0 && _id != "")
            {
                var currentColorUpdate = _db.Colors.Find(_id);
                currentColorUpdate.Counter++;
                if (currentColorUpdate.Counter >= 5 && currentColorUpdate.Counter < 11)
                {
                    color.Type = "popular";
                }
                else if (currentColorUpdate.Counter >= 11)
                {
                    color.Type = "trending";
                }
                _db.Colors.Update(color);
                _db.SaveChanges();
                message = "Successfully Updated🥳";
            }
            else
            {
                color.Id = guid.ToString();
                color.Type = "upAndComing";
                color.Counter = 1;
                _db.Colors.Add(color);
                _db.SaveChanges();
                message = "Successfully Addded🥳";
            }
            
            return message;
        }

    }
}