using System.Linq;
using System.Collections.Generic;
using Colecoes.Helper;

namespace Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            // ******** - Operações com Array - ********
            int[] arrayInteiros = new int[3];

            arrayInteiros[0] = 10;
            arrayInteiros[1] = 20;
            arrayInteiros[2] = int.Parse("30");

            // Ao descomentar a linha abaixo o programa retornará uma exceção pois não é uma posição válida no array
            //arrayInteiros[3] = 30;

            // Percorrendo o array
            System.Console.WriteLine("Percorrendo o array pelo For");
            for (int i = 0; i < arrayInteiros.Length; i++)
            {
                System.Console.WriteLine(arrayInteiros[i]);
            }

            System.Console.WriteLine("Percorrendo o array pelo ForEach");
            foreach (int item in arrayInteiros)
            {
                System.Console.WriteLine(item);
            }

            // ******** - Operações com matriz multidimensional, sendo composta de 4 linhas e 2 colunas - ********
            int[,] matriz = new int[4, 2]
            {
                { 8, 8 },
                { 10, 20 },
                { 50, 100 },
                { 90, 200 }
            };

            // Percorrendo a matriz
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    System.Console.WriteLine(matriz[i, j]);
                }
            }

            // Utilizando a classe OperacoesArray, que contém métodos auxiliares
            OperacoesArray op = new OperacoesArray();
            int[] array = new int[5] { 6, 3, 8, 1, 9 };
            int[] arrayCopia = new int[10];

            System.Console.WriteLine("Array original:");
            op.ImprimirArray(array);

            op.OrdenarBubbleSort(ref array);
            op.Ordenar(ref array);

            System.Console.WriteLine("Array ordenado:");
            op.ImprimirArray(array);

            System.Console.WriteLine("Array antes da cópia:");
            op.ImprimirArray(arrayCopia);

            op.Copiar(ref array, ref arrayCopia);
            System.Console.WriteLine("Array após a cópia:");
            op.ImprimirArray(arrayCopia);

            // Conversão de um array de inteiros para um array de string, com os mesmos elementos
            string[] arrayString = op.ConverterParaArrayString(array);

            System.Console.WriteLine($"Capacidade atual do array: {array.Length}");

            // Redimensionando um array para o dobro de sua capacidade atual
            op.RedimensionarArray(ref array, array.Length * 2);

            System.Console.WriteLine($"Capacidade atual do array após redimensionar: {array.Length}");

            // Procurando um índice com base no elemento
            int valorProcurado = 8;
            int indice = op.ObterIndice(array, valorProcurado);

            // Caso retornar -1, significa que o elemento não existe no array
            if (indice > -1)
            {
                System.Console.WriteLine($"O indice do elemento {valorProcurado} é: {indice}");
            }
            else
            {
                System.Console.WriteLine("Valor não existente no array");
            }

            // Procurando o elemento no array por seu valor
            int valorAchado = op.ObterValor(array, valorProcurado);

            // Caso retornar -1, significa que o elemento não existe no array
            if (valorAchado > 0)
            {
                System.Console.WriteLine("Encontrei o valor");
            }
            else
            {
                System.Console.WriteLine("Não encontrei o valor");
            }

            // Verifica se o array obedece uma determinada condição
            // Neste caso, verifica se todos os elementos são maior que o valor procurado
            bool todosMaiorQue = op.TodosMaiorQue(array, valorProcurado);

            if (todosMaiorQue)
            {
                System.Console.WriteLine("Todos os valores são maior que {0}", valorProcurado);
            }
            else
            {
                System.Console.WriteLine("Existe valores que não são maiores do que {0}", valorProcurado);
            }

            // Verifica se um determinado elemento existe no array, retornando um booleano
            bool existe = op.Existe(array, valorProcurado);

            if (existe)
            {
                System.Console.WriteLine("Encontrei o valor: {0}", valorProcurado);
            }
            else
            {
                System.Console.WriteLine("Não encontrei o valor: {0}", valorProcurado);
            }

            // ******** - Operações com lista - ********
            OperacoesLista opLista = new OperacoesLista();
            List<string> estados = new List<string> { "SP", "MG", "BA" };
            string[] estadosArray = new string[2] { "SC", "MT" };

            System.Console.WriteLine($"Quantidade de elementos na lista: {estados.Count}");

            opLista.ImprimirListaString(estados);

            System.Console.WriteLine("Removendo o elemento");
            estados.Remove("MG");

            estados.AddRange(estadosArray);
            estados.Insert(1, "RJ");

            opLista.ImprimirListaString(estados);

            // ******** - Operações com Fila - ********
            Queue<string> fila = new Queue<string>();
            fila.Enqueue("Leonardo");
            fila.Enqueue("Eduardo");
            fila.Enqueue("André");

            System.Console.WriteLine($"Pessoas na fila: {fila.Count}");

            while (fila.Count > 0)
            {
                System.Console.WriteLine($"Vez de: {fila.Peek()}");
                System.Console.WriteLine($"{fila.Dequeue()} atendido");
            }

            System.Console.WriteLine($"Pessoas na fila: {fila.Count}");

            // ******** - Operações com Pilha - ********
            Stack<string> pilhaLivros = new Stack<string>();
            pilhaLivros.Push(".NET");
            pilhaLivros.Push("DDD");
            pilhaLivros.Push("Código limpo");

            System.Console.WriteLine($"Livros para a leitura: {pilhaLivros.Count}");
            while (pilhaLivros.Count > 0)
            {
                System.Console.WriteLine($"Próximo livro para a leitura: {pilhaLivros.Peek()}");
                System.Console.WriteLine($"{pilhaLivros.Pop()} lido com sucesso");
            }

            System.Console.WriteLine($"Livros para a leitura: {pilhaLivros.Count}");

            // ******** - Operações com Dicionário - ********
            Dictionary<string, string> estadosDicionario = new Dictionary<string, string>();

            estadosDicionario.Add("SP", "São Paulo");
            estadosDicionario.Add("MG", "Minas Gerais");
            estadosDicionario.Add("BA", "Bahia");

            foreach (KeyValuePair<string, string> item in estadosDicionario)
            {
                System.Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
            }

            string valorProcuradoDicionario = "BA";

            // Ao descomentar a linha abaixo o programa retornará uma exceção pois não é uma chave válida no dicionário
            //var teste = estadosDicionario["SC"];

            // Obter um valor no dicionário de forma segura
            if (estadosDicionario.TryGetValue(valorProcuradoDicionario, out string estadoEncontrado))
            {
                System.Console.WriteLine(estadoEncontrado);
            }
            else
            {
                System.Console.WriteLine($"Chave {valorProcuradoDicionario} não existe no dicionário");
            }

            System.Console.WriteLine($"Removendo o valor: {valorProcuradoDicionario}");

            estadosDicionario.Remove(valorProcuradoDicionario);

            // Percorrendo um dicionário
            foreach (KeyValuePair<string, string> item in estadosDicionario)
            {
                System.Console.WriteLine($"Chave: {item.Key}, Valor: {item.Value}");
            }

            // Adicionando novamente o valor para atualizar
            estadosDicionario.Add("BA", "Bahia");
            System.Console.WriteLine("Valor original:");
            System.Console.WriteLine(estadosDicionario[valorProcuradoDicionario]);

            estadosDicionario[valorProcuradoDicionario] = "BA - teste atualização";

            System.Console.WriteLine("Valor atualizado:");
            System.Console.WriteLine(estadosDicionario[valorProcuradoDicionario]);            

            // ******** - Operações com LINQ - ********
            int[] arrayNumeros = new int[10] { 100, 1, 4, 0, 8, 15, 19, 19, 4, 100 };

            var minimo = arrayNumeros.Min();
            var maximo = arrayNumeros.Max();
            var medio = arrayNumeros.Average();
            var soma = arrayNumeros.Sum();
            var arrayUnico = arrayNumeros.Distinct().ToArray();

            var numerosParesQuery =
                    from num in arrayNumeros
                    where num % 2 == 0
                    orderby num
                    select num;

            var numerosParesMetodo = arrayNumeros.Where(x => x % 2 == 0).OrderBy(x => x).ToList();

            System.Console.WriteLine("Números pares query: " + string.Join(", ", numerosParesQuery));
            System.Console.WriteLine("Números pares método: " + string.Join(", ", numerosParesMetodo));
            System.Console.WriteLine($"Minimo: {minimo}");
            System.Console.WriteLine($"Maximo: {maximo}");
            System.Console.WriteLine($"Medio: {medio}");
            System.Console.WriteLine($"Soma: {soma}");
            System.Console.WriteLine($"Array original: {string.Join(", ", arrayNumeros)}");
            System.Console.WriteLine($"Array distinto: {string.Join(", ", arrayUnico)}");
        }
    }
}
