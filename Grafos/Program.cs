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
                            if (Exists(numberForConnection, undirectedGraphs))
                            {
                                undirectedNode.LinkedNumbers.Add(numberForConnection);
                            }
                            else if (numberForConnection.Equals(0)) { }
                            else
                            {
                                Console.WriteLine("ERRO: Este numero nao é valido...Por favor, digite um no existente");
                            }
                        }
                    }
                    undirectedGraphs.Add(undirectedNode);
                    Console.WriteLine("Continuar adicionando?\n" +
                        "1-Sim\n" +
                        "2-Nao");
                    var defineAdding = Console.ReadLine();
                    if (defineAdding.ToString().Equals("Nao") || defineAdding.ToString().Equals("2"))
                    {
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
                        //printMatrix
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
    }
}
