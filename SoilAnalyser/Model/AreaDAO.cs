using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class AreaDAO
    {
        DB DB = new DB();
        AreaCTRL AreaCTRL = new AreaCTRL();

        public DataTable Retornar_areas_porID(String id_area)
        {
            DataTable dt = new DataTable();

            string sql = String.Format("select * FROM areas where id_area = {0} ", id_area);

            dt = DB.retorna_registro(sql);

            return dt;
        }

        public DataTable Retornar_areas_por_IDSENSOR(decimal id_sensor)
        {
            DataTable dt = new DataTable();

            string sql = String.Format("select * FROM areas where id_sensor = {0} ", id_sensor);

            dt = DB.retorna_registro(sql);

            return dt;
        }

        public void Inserir_area(String descricao, String id_bomba, String id_sensor, String seco, String ideal_menor, String ideal_maior, String umido, String ip)
        {
            string comando = String.Format("INSERT INTO areas(descricao, id_bomba, id_sensor, seco, ideal_menor, ideal_maior, umido, ip) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, '{7}')",
                                           descricao, id_bomba, id_sensor, seco, ideal_menor, ideal_maior, umido, ip);
            DB.ExecutarComandoSQL(comando);
        }

        public void Atualizar_area(String descricao, String id_bomba, String id_sensor, String seco, String ideal_menor, String ideal_maior, String umido, String ip, String id_area)
        {
            string comando = String.Format("UPDATE areas set descricao = '{0}' , id_bomba = {1}, id_sensor = {2}, seco = {3}, ideal_menor = {4}, ideal_maior = {5}, umido = {6}, ip = '{7}' where id_area = {8}",
                                           descricao, id_bomba, id_sensor, seco, ideal_menor, ideal_maior, umido, ip, id_area);
            DB.ExecutarComandoSQL(comando);
        }

        public void Exclui_area(String id_area)
        {
            string comando = String.Format("DELETE from areas where id_area = {0}", id_area);
            DB.ExecutarComandoSQL(comando);
        }

        public DataTable Retornar_pesquisa_areas()
        {
            DataTable dt = new DataTable();

            string sql = String.Format(" select descricao       " +
                                       "       ,id_area         " +
                                       " FROM areas          ");

            dt = DB.retorna_registro(sql);

            return dt;
        }

        public DataTable retornar_IP_Area(String id_area)
        {
            DataTable dt = new DataTable();

            string sql = String.Format(" select ip FROM areas where id_area = {0}", id_area);

            dt = DB.retorna_registro(sql);

            return dt;
        }
    }
}
