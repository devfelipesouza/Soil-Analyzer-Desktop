using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class AreaCTRL
    {
        private int id;
        private string descricao;
        private string id_bomba;
        private string id_sensorUmidade;
        private string seco;
        private string ideal_menor;
        private string ideal_maior;
        private string umido;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Id_bomba { get => id_bomba; set => id_bomba = value; }
        public string Id_sensorUmidade { get => id_sensorUmidade; set => id_sensorUmidade = value; }
        public string Seco { get => seco; set => seco = value; }
        public string Ideal_menor { get => ideal_menor; set => ideal_menor = value; }
        public string Ideal_maior { get => ideal_maior; set => ideal_maior = value; }
        public string Umido { get => umido; set => umido = value; }


    }
}
