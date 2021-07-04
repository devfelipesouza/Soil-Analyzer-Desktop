using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoilAnalyser
{
    class ParametrosCTRL
    {
        private double tempo_registro;
        private double vazao_bomba;

        public double Tempo_registro { get => tempo_registro; set => tempo_registro = value; }
        public double Vazao_bomba { get => vazao_bomba; set => vazao_bomba = value; }

    }
}
