using System.Collections.Generic;

namespace the_other_balloon_widget.Models.Logic
{
    public interface IColorLogic
    {
        string DeleteColor(int id);
        string AddColor(Colors color);
        string UpdatedTrending();
        List<Colors> GetColorByType(string colorType);
        IEnumerable<Colors> GetAllColors();
    }
}