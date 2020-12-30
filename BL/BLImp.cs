using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using BO;
using DLAPI;

namespace BL
{
    class BLImp:IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(LineStation linestation)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAllLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetAllLineStations()
        {
            throw new NotImplementedException();
        }

        public Line GetLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetLineBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineStation
        BO.LineStation LineStationDoBoAdapter(DO.LineStation lsdo)
        {
            BO.LineStation lsbo = new BO.LineStation();
            lsdo.CopyPropertiesTo(lsbo);
            return lsbo;
        }
        public BO.LineStation GetLineStation(int code)//
        {
            DO.LineStation dlinestion;
            try
            {
                dlinestion = dl.GetLineStation(code);

            }
            catch { }//צריך למלא--עוד לא טיפלנו בחריגות
            return LineStationDoBoAdapter(dlinestion);
        }

        public IEnumerable<LineStation> GetLineStationBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int id, Action<Line> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(LineStation linestation)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int id, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
