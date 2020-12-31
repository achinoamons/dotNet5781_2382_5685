using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
//using BO;
using DLAPI;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        public void AddLine(BO.Line line)
        {
            throw new NotImplementedException();
        }

        public void AddLineStation(BO.LineStation linestation)
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

        public IEnumerable<BO.Line> GetAllLines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.LineStation> GetAllLineStations()
        {
            throw new NotImplementedException();
        }

        public BO.Line GetLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Line> GetLineBy(Predicate<BO.Line> predicate)
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
            DO.Station dstation;
            try
            {
                dlinestion = dl.GetLineStation(code);
                dstation = dl.GetStation(code);
            }
            catch (DO.BadLineStationIdException ex)
            {
                throw new BO.BadLineStationException("This linestation is not exist ", ex);
            }
            BO.LineStation bls = new BO.LineStation();
            bls=LineStationDoBoAdapter(dlinestion);

    }

        public IEnumerable<BO.LineStation> GetLineStationBy(Predicate<BO.LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(BO.Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int id, Action<BO.Line> update)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(BO.LineStation linestation)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int id, Action<BO.LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
