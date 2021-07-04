using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class BombaDAO
    {
        DB DB = new DB();
        BombaCTRL BombaCTRL = new BombaCTRL();

        public DataTable Retornar_bombas_porID(String id_bomba)
        {
            DataTable dt = new DataTable();

            string sql = String.Format("select * FROM bombas where id_bomba = {0} ", id_bomba);

            dt = DB.retorna_registro(sql);

            return dt;
        }

        public void Inserir_bomba(String descricao, String vazao)
        {
            string comando = String.Format("INSERT INTO bombas(descricao, vazao) VALUES ('{0}', {1})",
                                           descricao, vazao);
            DB.ExecutarComandoSQL(comando);
        }

        public void Atualizar_bomba(String descricao, String vazao, String id_bomba)
        {
            string comando = String.Format("UPDATE bombas set descricao = '{0}' , vazao = {1} where id_bomba = {2}",
                                           descricao, vazao, id_bomba);
            DB.ExecutarComandoSQL(comando);
        }

        public void Exclui_bomba(String id_bomba)
        {
            string comando = String.Format("DELETE from bombas where id_bomba = {0}", id_bomba);
            DB.ExecutarComandoSQL(comando);
        }

        public DataTable Retornar_pesquisa_bombas()
        {
            DataTable dt = new DataTable();

            string sql = String.Format(" select descricao       " +
                                       "       ,id_bomba         " +
                                       " FROM bombas          ");

            dt = DB.retorna_registro(sql);

            return dt;
        }
    }
}
