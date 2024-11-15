using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maisUmTeste
{
    internal class Pessoa
    {
        public enum Pulseira
        {
            Verde,
            Amarela,
            Vermelha
        }
        public enum Sexo
        {
            Masculino,
            Feminino
        }

        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public Pulseira CorPulseira { get; set; }
        public Sexo SexoValue { get; set; }

        public Pessoa()
        {

        }
        public Pessoa(string nomeValue, DateTime dataValue, Pulseira pulseiraValue, Sexo sexoValue)
        {
            Nome = nomeValue;
            Data = dataValue;
            CorPulseira = pulseiraValue;
            SexoValue = sexoValue;
        }
        public override string ToString()
        {
            return "Nome: " + Nome + ", Sexo: " + SexoValue + ", CorPulseira: " + CorPulseira + ".";
        }
    }
}
