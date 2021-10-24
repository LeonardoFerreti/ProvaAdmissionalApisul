using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ProvaAdmissionalApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename =  Directory.GetCurrentDirectory() + @"\\input.json";

            if (File.Exists(filename))
            {
                var input = File.ReadAllText(filename);
                var json = JsonConvert.DeserializeObject<List<Entrada>>(input);
                var elevadorService = new ElevadorService(json);
                 
                Console.WriteLine("A)=> Andar(es) meno(s) utilizado(s):");
                elevadorService.andarMenosUtilizado().ForEach(a => Console.WriteLine(a));

                Console.WriteLine("B)=> Elevador mais frequentado e período de maior fluxo:"); 
                Console.WriteLine($"Elevador: {elevadorService.elevadorMaisFrequentado().First()}");
                Console.WriteLine($"Período: {elevadorService.periodoMaiorFluxoElevadorMaisFrequentado().First()}");

                Console.WriteLine("C)=> Elevador menos frequentado e período de menor fluxo: ");
                Console.WriteLine($"Elevador: {elevadorService.elevadorMenosFrequentado().First()}");
                Console.WriteLine($"Período: {elevadorService.periodoMenorFluxoElevadorMenosFrequentado().First()}");
                
                Console.WriteLine("D)=> Período de maior utilização do conjunto de elevadores:");
                Console.WriteLine(elevadorService.periodoMaiorUtilizacaoConjuntoElevadores().First());

                Console.WriteLine("E)=> Percentual de uso de cada elevador com relação a todos os serviços prestados:");
                Console.WriteLine($"Elevador A= {elevadorService.percentualDeUsoElevadorA()}%");
                Console.WriteLine($"Elevador B= {elevadorService.percentualDeUsoElevadorB()}%");
                Console.WriteLine($"Elevador C= {elevadorService.percentualDeUsoElevadorC()}%");
                Console.WriteLine($"Elevador D= {elevadorService.percentualDeUsoElevadorD()}%");
                Console.WriteLine($"Elevador E= {elevadorService.percentualDeUsoElevadorE()}%");
            }
            else
            {
                Console.WriteLine("input não encontrado.");
                
            }
            Console.ReadKey();
        }
    }
}
