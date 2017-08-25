using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace N.Rules
{
    public class ClaseBase
    {

        #region Propiedades
        // dt Generico
        DataTable _Dtg = new DataTable();

        public DataTable Dtg
        {
            get { return _Dtg; }
            set { _Dtg = value; }
        }

        //SQLSERVER

        private string _BaseSQLServer = "Default";

        public string BaseSQLServer
        {
            get { return _BaseSQLServer; }
            set { _BaseSQLServer = value; }
        }
        private int _TimeOutSQLServer = 15;//tiempo por defecto

        public int TimeOutSQLServer
        {
            get { return _TimeOutSQLServer; }
            set { _TimeOutSQLServer = value; }
        }
        #endregion

        #region Metodos Privados

        protected void sqlGet(string SQL)
        {
            N.Data.SQL oSQL = new N.Data.SQL();
            if (BaseSQLServer != "")
            {
                oSQL.Base = BaseSQLServer;
            }
            oSQL.TimeOut = TimeOutSQLServer;
            _Dtg = oSQL.executeQ(SQL);
        }

        protected void sqlSet(string SQL)
        {
            N.Data.SQL oSQL = new N.Data.SQL();
            if (BaseSQLServer != "")
            {
                oSQL.Base = BaseSQLServer;
            }
            oSQL.TimeOut = TimeOutSQLServer;
            oSQL.executeQ(SQL);
        }
        #endregion

    }
}
