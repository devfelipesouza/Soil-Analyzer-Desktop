using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class UsuarioCTRL
    {
        private int id;
        private string nome;
        private string usuario;
        private string senha;
        private bool admin;
        private bool ativo;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public bool Acesso { get => admin; set => admin = value; }
        public bool Ativo { get => ativo; set => ativo = value; }
    }
}
