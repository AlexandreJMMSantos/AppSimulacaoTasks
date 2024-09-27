using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int indexTask = 0;
        var tasks = new List<Task>();

        while (true)
        {
            indexTask += 1;
            tasks.Add(ProcessamentoAsync(indexTask));

            if (indexTask > 100) 
            {
                break;
            }
        }

        await Task.WhenAll(tasks);

        Console.ResetColor();

        Console.WriteLine("Todas as tarefas foram processadas.");
    }

    static async Task ProcessamentoAsync(int indexTask)
    {
        try
        {
            Random random = new Random();
            int tempoDeEspera = random.Next(0, 5000);

            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TASK " + indexTask + " >> aguardando " + tempoDeEspera + " milissegundos.");

            await Task.Delay(tempoDeEspera);

            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tempo de execução da TASK " + indexTask + " >> " + stopwatch.Elapsed.TotalSeconds + " segundos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
