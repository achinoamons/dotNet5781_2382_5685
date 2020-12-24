using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace DLAPI
{
    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL
    {
        #region Line
        IEnumerable<Line> GetAllLines();
        IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        Line GetLine(int id);
        void AddLine(Line line);
        void UpdateLine(Line line);
        void UpdateLine(int id, Action<Line> update); //method that knows to updt specific fields in Person
        void DeleteLine(int id);
        #endregion
        #region LineStation
        IEnumerable<LineStation> GetAllLineStations();
        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> predicate);
        LineStation GetLineStation(int id);
        void AddLineStation(LineStation linestation);
        void UpdateLineStation(LineStation linestation);
        void UpdateLineStation(int id, Action<LineStation> update); //method that knows to updt specific fields in Person
        void DeleteLineStation(int id);
        #endregion
    }
}
