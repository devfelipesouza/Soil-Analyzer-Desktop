using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class UsuarioDAO
    {
        DB DB = new DB();
        UsuarioCTRL UsuarioCTRL = new UsuarioCTRL();

        public DataTable Retornar_usuario(String usuario)
        {
            DataTable dt = new DataTable();

            string sql = String.Format("select * FROM usuarios where upper(usuario) = '{0}' and ativo = 1", usuario);
            dt = DB.retorna_registro(sql);

            return dt;
        }

        public DataTable Retornar_usuario_porID(String id_usuario)
        {
            DataTable dt = new DataTable();

            string sql = String.Format("select * FROM usuarios where id_usuario = {0} ", id_usuario);

            dt = DB.retorna_registro(sql);

            return dt;
        }

        public void Inserir_usuario(String nome, String usuario, String senha, Boolean admin, Boolean ativo)
        {
            string comando = String.Format("INSERT INTO usuarios(nome, usuario, senha, admin, ativo) VALUES ('{0}', '{1}', '{2}', {3}, {4})",
                                           nome, usuario, senha, admin, ativo);
            DB.ExecutarComandoSQL(comando);
        }

        public void Atualizar_usuario(String nome, String usuario, String senha, Boolean admin, Boolean ativo, String id_usuario)
        {
            string comando = String.Format("UPDATE usuarios set nome = '{0}' , usuario = '{1}', senha = '{2}' , admin = {3} , ativo = {4} where id_usuario = {5}",
                                           nome, usuario, senha, admin, ativo, id_usuario);
            DB.ExecutarComandoSQL(comando);
        }

        public void Exclui_usuario(String id_usuario)
        {
            string comando = String.Format("DELETE from usuarios where id_usuario = {0}", id_usuario);
            DB.ExecutarComandoSQL(comando);
        }

        public DataTable Retornar_pesquisa_usuarios()
        {
            DataTable dt = new DataTable();

            string sql = String.Format(" select usuario         " +
                                       "       ,nome            " +
                                       "       ,id_usuario      " +
                                       " FROM usuarios          ");

            dt = DB.retorna_registro(sql);

            return dt;
        }

    }
}
