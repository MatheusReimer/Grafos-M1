using System;
using System.Collections.Generic;
using System.Linq;

namespace Grafos
{
    class Program
    {

 
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao gerador de grafos");
            int contDirected = 0;
            int contUndirected = 0;
            ///CRIAR OBJETO -> DENTRO DE CADA OBJETO UMA LISTA DE NOS LINKADOS
            List<DirectedGraph> directedGraphs = new List<DirectedGraph>();
            List<UndirectedGraph> undirectedGraphs = new List<UndirectedGraph>();
            mainMenuSwitch();
            
            Console.ReadKey();


            void addDirectedNode() {
                Console.WriteLine("Adicionando...");
                bool adding = true;
                while (adding)
                {
                    contUndirected++;
                    var undirectedNode = new UndirectedGraph();
                    undirectedNode.Number = contUndirected;
                    
                    if (undirectedGraphs.Count > 0)
                    {
                        string connectedNode = "";
                        while (!connectedNode.Equals("0") && undirectedNode.RemainingNodesExist(undirectedGraphs, undirectedNode))
                        {
                            Console.WriteLine("Este no se conecta com qual dos ja existentes nos? (DIGITE 0 QUANDO NAO TIVER MAIS ITENS PARA CONECTAR)");
                            connectedNode = Console.ReadLine();
                            var numberForConnection = Convert.ToInt32(connectedNode);
                            if (Exists(numberForConnection, undirectedGraphs) && numberForConnection != contUndirected)
                            {
                                undirectedNode.LinkedNumbers.Add(numberForConnection);
                            }
                            else if (numberForConnection.Equals(0)) { }
                            else
                            {
                                Console.WriteLine("ERRO: Este numero nao é valido...Por favor, digite um no existente e que nao é o proprio valor do no");
                            }
                        }
                    }
                    if (undirectedNode.LinkedNumbers.Count.Equals(0)) {
                        undirectedNode.LinkedNumbers.Add(0);
                    }
                    undirectedGraphs.Add(undirectedNode);
                    Console.WriteLine("Continuar adicionando?\n" +
                        "1-Sim\n" +
                        "2-Nao");
                    var defineAdding = Console.ReadLine();
                    if (defineAdding.ToString().Equals("Nao") || defineAdding.ToString().Equals("2"))
                    {
                        create2dMatrix(undirectedGraphs);
                        adding = false;
                    }
     
                }
            }
            void removeDirectedNode() {
                if (undirectedGraphs.Count.Equals(0)) { Console.WriteLine("ERRO: Nao existem pontos no grafo\n"); return; }
                bool removing = true;
                while (removing && undirectedGraphs.Count>0)
                {
                    Console.WriteLine("Removendo...");
                    Console.WriteLine("Qual no voce deseja remover?");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    if (Exists(userInput, undirectedGraphs))
                    {
                        var itemToRemove = undirectedGraphs.SingleOrDefault(r => r.Number.Equals(userInput));
                        undirectedGraphs.Remove(itemToRemove);
                    }
                    Console.WriteLine("Continuar removendo?");
                    Console.WriteLine("1-Sim\n" +
                        "2-Nao");
                    var isStillRunning = Console.ReadLine();
                    if (isStillRunning.ToString().Equals("2") || isStillRunning.ToString().Equals("Nao"))
                    {
                        removing = false;
                    }
                }
            }
            void addUndirectedNode() {
                Console.WriteLine("Adicionando...");
            }
            void removeUndirectedNode() {
                Console.WriteLine("Removendo...");
            }
            void showMenu()
            {
                Console.WriteLine(
                 "1-Adicionar No \n" +
                 "2-Remover No \n" +
                 "3-Adicionar No direcionado \n" +
                 "4-Remover No direcionado \n"+
                 "5-Adicionar conexao a um no especifico \n"+
                 "6-Remover conexao de um no especifico"
                );
            }


            bool Exists(int numberToSearch, List<UndirectedGraph> list)
            {
                foreach (var number in list)
                {
                    if (number.Number.Equals(numberToSearch))
                    {
                        return true;
                    }

                }
                return false;
            }

            void mainMenuSwitch()
            {
                showMenu();
                var userAnswer = Console.ReadLine();
               
                switch (userAnswer)
                {
                    case "1":
                        addDirectedNode();
                        mainMenuSwitch();
                        
                       
                        break;
                    case "2":
                        removeDirectedNode();
                        mainMenuSwitch();
                        break;
                    case "3":
                        addUndirectedNode();
                        break;
                    case "4":
                        removeUndirectedNode();
                        break;
                    default:
                        Console.WriteLine("Por favor, selecione uma opcao valida");
                        break;
                }
            }
        }
        public static void create2dMatrix(List<UndirectedGraph> list)
        {
            var array = list.ToArray();
            Console.WriteLine("Em meu array list tem: " + array.Length);
            int[,] array2d = new int[array.Length, array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                var test = array[i].LinkedNumbers.ToArray();

                for (int z = 0; z < array.Length; z++)
                {
                    array2d[i,z] = 0;
                }
                Console.WriteLine("");
            }
            Print2dMatrix(list, array2d);
        }
        public static void Print2dMatrix(List<UndirectedGraph> list, int[,]array2d)
        {
            var array = list.ToArray();
            Console.WriteLine("Tamanho do array2d" + array2d.Length);
            Console.WriteLine("Tamanho do outro" + array.Length);


            for (int i = 0; i < array2d.Length; i++)
            {
                foreach (var numberLink in array[i].LinkedNumbers)
                {
                    array2d[i, numberLink]=1;
                }
            }
            for(int i = 0; i < array2d.Length; i++)
            {
                for(int j = 0; j < array2d.Length; j++)
                {
                    Console.Write(array2d[i, j]);
                }
                Console.WriteLine("");
            }
            }
        public void printMatrix(List<DirectedGraph> list)
        {
            var array = list.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {

                }
            }
        }
    }

}
