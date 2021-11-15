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

        public string AddColor(Colors color)
        {
            IEnumerable<Colors> colorFromDatabase = _db.Colors;
            color.Timestamp = new System.DateTime().Minute;
            string message;
            foreach (var itemColor in colorFromDatabase)
            {
                if (itemColor.Name == color.Name)
                {
                    color.Id = itemColor.Id;
                    break;
                }
            }
            if (colorFromDatabase.Count() > 0)
            {
                var currentColorUpdate = _db.Colors.Find(color.Id);
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
                message = "Successfully Updated🥳";
            }
            else
            {
                color.Type = "upAndComing";
                color.Counter = 1;
                _db.Colors.Add(color);
                message = "Successfully Addded🥳";
            }
            _db.SaveChanges();
            return message;
        }

    }
}