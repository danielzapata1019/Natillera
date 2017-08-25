using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
namespace N.Data
{
    public class SQL
    {

        #region Propiedades

        SqlConnection _cnn = new SqlConnection();
        SqlDataAdapter _da = new SqlDataAdapter();
        SqlCommand _cmd = new SqlCommand();
        SqlParameterCollection _pc = new SqlParameterCollection();

        private string _Base="Default";

        public string Base
        {
            get { return _Base; }
            set { _Base = value; }
        }

        private int _TimeOut=15;

        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        public string Cadena
        {
            get
            {
                switch (_Base)
                {
                    case "Default": return N.Data.Properties.Settings.Default.Nat;
                    default:
                        return N.Data.Properties.Settings.Default.Nat;
                }
            }
        }
        #endregion 

        #region MetodosPrivados

        /// <summary>
        /// Método que permite abrir la conexion con la base de datos
        /// </summary>
        private void abrirBase()
        {
            _cnn.ConnectionString = Cadena;
            _cnn.Open();
        }

        private void cerrarBase()
        {
            if (_cnn.State == ConnectionState.Open)
            {
                _cnn.Close();
            }
        }

        #endregion

        #region MetodosPúblicos
        public DataTable executeQ(string SQL)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(SQL, _cnn);
                abrirBase();
                da.SelectCommand.CommandTimeout = TimeOut;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                cerrarBase();
            }
            
        }

        public void executeNQ(string SQL)
        {
            try
            {
                abrirBase();
                _cmd.Connection = _cnn;
                _cmd.CommandText = SQL;
                _cmd.CommandTimeout = TimeOut;
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                cerrarBase();
            }
        }

        public void agregarParametro(string parametro, string valor)
        {
            _cmd.Parameters.Add(new SqlParameter(parametro, valor));
        }

        public DataTable SP_Q(string SP)
        {
            abrirBase();
            DataTable dt = new DataTable();
            _cmd.Connection = _cnn;
            _cmd.CommandText = SP;
            _cmd.CommandTimeout = TimeOut;
            _cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.Fill(dt);
            return dt;
        }
        #endregion


    }
}
