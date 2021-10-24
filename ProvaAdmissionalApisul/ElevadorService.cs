using System;
using ProvaAdmissionalCSharpApisul;
using System.Collections.Generic;
using System.Linq;

namespace ProvaAdmissionalApisul
{
    public class ElevadorService : IElevadorService
    {
        public List<Entrada> _entradas { get; set; }

        public ElevadorService(List<Entrada> entradas)
        {
            _entradas = entradas;
        }

        public List<int> andarMenosUtilizado()
        {
            var andaresAgrupadosPorUso = (
                from p in _entradas
                group p by p.Andar
                into pgroup
                select new { AndarCount = pgroup.Count(), pgroup.Key }
            ).OrderBy(x => x.AndarCount);

            var menorUtilizacao = andaresAgrupadosPorUso.AsEnumerable().Min(x => x.AndarCount);

            var andares = (
                from p in andaresAgrupadosPorUso
                where p.AndarCount == menorUtilizacao
                select p.Key).ToList();

            return andares;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var elevadoresAgrupadosPorUso = (
                from p in _entradas
                group p by p.Elevador
                into pgroup
                select new { ElevadorCount = pgroup.Count(), pgroup.Key }
            ).OrderBy(x => x.ElevadorCount);

            var maiorFrequenciaElevador = elevadoresAgrupadosPorUso.AsEnumerable().Max(x => x.ElevadorCount);

            var elevadorMaisFrequentado = (
                (from p in elevadoresAgrupadosPorUso
                 where p.ElevadorCount == maiorFrequenciaElevador
                 select p.Key)).ToList();

            return elevadorMaisFrequentado;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var elevadoresAgrupadosPorUso = (
                from p in _entradas
                group p by p.Elevador
                into pgroup
                select new { ElevadorCount = pgroup.Count(), pgroup.Key }
            ).OrderBy(x => x.ElevadorCount);

            var menorFrequenciaElevador = elevadoresAgrupadosPorUso.AsEnumerable().Min(x => x.ElevadorCount);

            var elevadorMaisFrequentado = (
                (from p in elevadoresAgrupadosPorUso
                 where p.ElevadorCount == menorFrequenciaElevador
                 select p.Key)).ToList();

            return elevadorMaisFrequentado;
        }

        public float percentualDeUsoElevadorA()
        {
            return calculaValorPercentual(Convert.ToChar("A"));
        }

        public float percentualDeUsoElevadorB()
        {
            return calculaValorPercentual(Convert.ToChar("B"));
        }

        public float percentualDeUsoElevadorC()
        {
            return calculaValorPercentual(Convert.ToChar("C"));
        }

        public float percentualDeUsoElevadorD()
        {
            return calculaValorPercentual(Convert.ToChar("D"));
        }

        public float percentualDeUsoElevadorE()
        {
            return calculaValorPercentual(Convert.ToChar("E"));
        }

        private float calculaValorPercentual(char elevador)
        {
            float qtdeTotal = _entradas.Count;
            float qtdeUsoElevador = _entradas.Count(x => x.Elevador.Equals(elevador));

            var percentual = qtdeUsoElevador * 100 / qtdeTotal;

            return (float) Math.Round(percentual,2);
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadorMaisFrequentado = this.elevadorMaisFrequentado().First();

            var periodoAgrupadosPorUso = (
                from p in _entradas
                where p.Elevador == elevadorMaisFrequentado
                group p by p.Turno
                into pgroup
                select new { TurnoCount = pgroup.Count(), pgroup.Key }
            ).OrderBy(x => x.TurnoCount);

            var maiorFrequenciaTurno = periodoAgrupadosPorUso.AsEnumerable().Max(x => x.TurnoCount);

            var turnoMaiorFluxo = (
                (from p in periodoAgrupadosPorUso
                 where p.TurnoCount == maiorFrequenciaTurno
                 select p.Key)).ToList();

            return turnoMaiorFluxo;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var utilizacaoElevadoresAgrupadosPorTurno = (
                from p in _entradas
                group p by p.Turno
                into pgroup
                select new { TurnoCount = pgroup.Count(), pgroup.Key }
            ).OrderBy(x => x.TurnoCount);

            var maiorUtilizacaoPorTurno = utilizacaoElevadoresAgrupadosPorTurno.AsEnumerable().Max(x => x.TurnoCount);

            var maiorUtilizacao = (from p in utilizacaoElevadoresAgrupadosPorTurno
                                   where p.TurnoCount == maiorUtilizacaoPorTurno
                                   select p.Key).ToList();

            return maiorUtilizacao;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var elevadorMenosFrequentado = this.elevadorMenosFrequentado().First();

            var periodoAgrupadosPorUso = (
                from p in _entradas
                where p.Elevador == elevadorMenosFrequentado
                group p by p.Turno
                into pgroup
                select new { TurnoCount = pgroup.Count(), pgroup.Key }
            ).OrderBy(x => x.TurnoCount);

            var menorFrequenciaTurno = periodoAgrupadosPorUso.AsEnumerable().Min(x => x.TurnoCount);

            var turnoMenorFluxo = (
                from p in periodoAgrupadosPorUso
                where p.TurnoCount == menorFrequenciaTurno
                select p.Key).ToList();

            return turnoMenorFluxo;
        }
    }
}
