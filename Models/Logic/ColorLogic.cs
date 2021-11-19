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

        private DateTime timeNow() {
            var timeNow = DateTime.UtcNow;
            // var timeNow = DateTime.Now;
            return timeNow;
        }

        private void UpdateTheDatabase(Colors colorSub)
        {
            if (colorSub.Counter < 5)
            {
                colorSub.Type = "upAndComing";
            }
            else if (colorSub.Counter >= 5 && colorSub.Counter < 11)
            {
                colorSub.Type = "popular";
            }
            else if (colorSub.Counter >= 11)
            {
                colorSub.Type = "trending";
                colorSub.Timestamp = timeNow();
            }
            _db.Colors.Update(colorSub);
            _db.SaveChanges();
        }

        private void ResetTrending(List<string> id){
            id.ForEach((x) => {
                var itemColor = _db.Colors.Find(x);
                itemColor.Type = "popular";
                itemColor.Counter = 9;
                _db.Colors.Update(itemColor);
                _db.SaveChanges();
            });
            
        }

        public string UpdatedTrending(){
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            var ids = new List<string>();
            foreach (var itemColor in colorFromDatabase)
            {
                if (itemColor.Type == "trending")
                {
                    var compareTime = (timeNow().AddMinutes(-5)) > (itemColor.Timestamp);
                    Console.WriteLine(compareTime);
                    Console.WriteLine( new TimeSpan(0,5,0) );
                    Console.WriteLine(compareTime);
                    if(compareTime){
                        ids.Add(itemColor.Id);

                    }
                }
            }
            ResetTrending(ids);
            return "Updated";
        }

        public void DeleteColor(int id){
            var obj = _db.Colors.Find(id);
            _db.Colors.Remove(obj);
            _db.SaveChanges();
        }

        public void subCurrentColor(string id){
            var colorSub = _db.Colors.Find(id);
            Console.WriteLine(colorSub.Counter);
            
            colorSub.Counter--;
            if(colorSub.Counter == 0){
                _db.Colors.Remove(colorSub);
                _db.SaveChanges();
            } else
            {
                UpdateTheDatabase(colorSub);
            }
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
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            color.Timestamp = timeNow();
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
                UpdateTheDatabase(currentColorUpdate);
                message = "Successfully Updated🥳";
                Console.WriteLine((currentColorUpdate.Timestamp));
                Console.WriteLine(timeNow());
                Console.WriteLine((currentColorUpdate.Timestamp - timeNow()) > new TimeSpan(0,5,0));
            }
            else
            {
                color.Counter = 1;
                _db.Colors.Add(color);
                _db.SaveChanges();
                message = "Successfully Addded🥳";
            }
            return message;
        }

    }
}