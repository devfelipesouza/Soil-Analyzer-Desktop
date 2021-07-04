using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class BombaCTRL
    {
        private int id;
        private string descricao;
        private string vazao;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Vazao { get => vazao; set => vazao = value; }
    }
}
