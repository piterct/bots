using System.Collections.Generic;

namespace Bot.MegaSena
{
    public class Game
    {
        public string TipoJogo { get; set; }
        public int Numero { get; set; }
        public string NomeMunicipioUFSorteio { get; set; }
        public string DataApuracao { get; set; }
        public double ValorArrecadado { get; set; }
        public double ValorEstimadoProximoConcurso { get; set; }
        public double ValorAcumuladoProximoConcurso { get; set; }
        public double ValorAcumuladoConcursoEspecial { get; set; }
        public double ValorAcumuladoConcurso_0_5 { get; set; }
        public bool Acumulado { get; set; }
        public int IndicadorConcursoEspecial { get; set; }
        public List<string> DezenasSorteadasOrdemSorteio { get; set; }
        public object ListaResultadoEquipeEsportiva { get; set; }
        public int NumeroJogo { get; set; }
        public string NomeTimeCoracaoMesSorte { get; set; }
        public int TipoPublicacao { get; set; }
        public string Observacao { get; set; }
        public string LocalSorteio { get; set; }
        public string DataProximoConcurso { get; set; }
        public int NumeroConcursoAnterior { get; set; }
        public int NumeroConcursoProximo { get; set; }
        public int ValorTotalPremioFaixaUm { get; set; }
        public int NumeroConcursoFinal_0_5 { get; set; }
        public List<object> ListaMunicipioUFGanhadores { get; set; }
        public List<PremiumApportionment> listaRateioPremio { get; set; }
        public List<string> ListaDezenas { get; set; }
        public object ListaDezenasSegundoSorteio { get; set; }
        public object Id { get; set; }

    }
}
