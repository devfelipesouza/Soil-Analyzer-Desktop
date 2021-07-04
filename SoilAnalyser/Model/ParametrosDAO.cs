using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class ParametrosDAO
    {
        DB DB = new DB();
        ParametrosCTRL ParametrosCTRL = new ParametrosCTRL();

        public DataTable Retornar_parametros()
        {
            DataTable dt = new DataTable();

            string sql = String.Format("select * FROM parametros");
            dt = DB.retorna_registro(sql);

            return dt;
        }

        public void Atualizar_parametros(Decimal tempo_registro)
        {
            string comando = String.Format("UPDATE parametros set tempo_registro = '{0}'",
                                           tempo_registro);
            DB.ExecutarComandoSQL(comando);
        }
    }
}
