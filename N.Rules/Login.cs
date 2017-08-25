using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace N.Rules
{
    class Login:ClaseBase
    {
        private string _IdUser;

        public string IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }
        private string _NomUser;

        public string NomUser
        {
            get { return _NomUser; }
            set { _NomUser = value; }
        }

        public Boolean Login(string IdUsuario, string Password)
        {
            try
            {
                BaseSQLServer = "Local";
                N.Data.SQL oSQL = new N.Data.SQL();
                oSQL.agregarParametro("@IdUsuario", IdUsuario);
                oSQL.agregarParametro("@Psw", Password);

                DataTable dt = oSQL.SP_Q("PA_Login");
                if (dt.Rows[0]["PA_RESP"].Equals(1))
                {
                    IdUser = dt.Rows[0]["IdUsuario"].ToString();
                    NomUser = dt.Rows[0]["Nombre"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
