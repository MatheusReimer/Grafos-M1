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
            showMenu();
            int contDirected = 0;
            int contUndirected = 0;
            ///CRIAR OBJETO -> DENTRO DE CADA OBJETO UMA LISTA DE NOS LINKADOS
            List<DirectedGraph> directedGraphs = new List<DirectedGraph>();
            List<UndirectedGraph> undirectedGraphs = new List<UndirectedGraph>();
            var userAnswer = Console.ReadLine();
            switch (userAnswer)
            {
                case "1":
                    addDirectedNode();
         
                    break;
                case "2":
                    removeDirectedNode();
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
            
            Console.ReadKey();


            void addDirectedNode() {
                Console.WriteLine("Adicionando...");
                bool adding = true;
                while (adding)
                {
                    contDirected++;
                    var directedNode = new DirectedGraph();
                    directedNode.Number = contDirected;
                    if (directedGraphs.Count > 0)
                    {
                        string connectedNode = "";
                        while (!connectedNode.Equals("0"))
                        {
                            Console.WriteLine("Este no se conecta com qual dos ja existentes nos? (DIGITE 0 QUANDO NAO TIVER MAIS ITENS PARA CONECTAR)");
                            connectedNode = Console.ReadLine();
                            var numberForConnection = Convert.ToInt32(connectedNode);
                            if (directedNode.Exists(numberForConnection, directedGraphs))
                            {
                                directedNode.LinkedNumbers.Add(numberForConnection);
                            }
                            else if (numberForConnection.Equals(0)) { }
                            else
                            {
                                Console.WriteLine("Este numero nao é valido...Por favor, digite um no existente");
                            }
                        }
                    }
                    directedGraphs.Add(directedNode);
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
                Console.WriteLine("Removendo...");
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
                 "4-Remover No direcionado \n"
                );
            }
        }
    }
}
