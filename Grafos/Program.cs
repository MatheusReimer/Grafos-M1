﻿using System;
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
                        while (!connectedNode.Equals("0") && directedNode.RemainingNodesExist(directedGraphs, directedNode))
                        {
                            Console.WriteLine("Este no se conecta com qual dos ja existentes nos? (DIGITE 0 QUANDO NAO TIVER MAIS ITENS PARA CONECTAR)");
                            connectedNode = Console.ReadLine();
                            var numberForConnection = Convert.ToInt32(connectedNode);
                            if (Exists(numberForConnection, directedGraphs) && numberForConnection != contDirected)
                            {
                                directedNode.LinkedNumbers.Add(numberForConnection);
                            }
                            else if (numberForConnection.Equals(0)) { }
                            else
                            {
                                Console.WriteLine("ERRO: Este numero nao é valido...Por favor, digite um no existente e que nao é o proprio valor do no");
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
                        create2dMatrix(directedGraphs);
                        adding = false;
                    }
     
                }
            }
            void removeDirectedNode() {
                if (directedGraphs.Count.Equals(0)) { Console.WriteLine("ERRO: Nao existem pontos no grafo\n"); return; }
                bool removing = true;
                while (removing && directedGraphs.Count>0)
                {
                    Console.WriteLine("Removendo...");
                    Console.WriteLine("Qual no voce deseja remover?");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    if (Exists(userInput, directedGraphs))
                    {
                        var itemToRemove = directedGraphs.SingleOrDefault(r => r.Number.Equals(userInput));
                        directedGraphs.Remove(itemToRemove);
                        //FOR EVERY GRAPH THAT HAS NUMBER GREATHER THAN THE REMOVED ONE
                        foreach(var item in directedGraphs) if (item.Number > userInput)
                            {
                                item.Number--;
                            }
                        foreach(var item in directedGraphs)
                        {
                            foreach(var linked in item.LinkedNumbers) 
                                {
                                if (linked > userInput)
                                {
                                    linked--;
                                }else if(linked==userInput){
                                    linked = 0;
                                }

                                }
                            item.LinkedNumbers.ToList().ForEach(s=>s--);
                        }
                     

                    }
                    Console.WriteLine("Continuar removendo?");
                    Console.WriteLine("1-Sim\n" +
                        "2-Nao");
                    var isStillRunning = Console.ReadLine();
                    if (isStillRunning.ToString().Equals("2") || isStillRunning.ToString().Equals("Nao"))
                    {
                        create2dMatrix(directedGraphs);
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
                 "6-Remover conexao de um no especifico \n"+
                 "7-Sair"
                );
            }


            bool Exists(int numberToSearch, List<DirectedGraph> list)
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
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Por favor, selecione uma opcao valida");
                        break;
                }
            }
        }
        public static void create2dMatrix(List<DirectedGraph> list)
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
        public static void Print2dMatrix(List<DirectedGraph> list, int[,]array2d)
        {
            var array = list.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                foreach (var numberLink in array[i].LinkedNumbers)
                {
                    array2d[i, (numberLink-1)]=1;
                }
            }
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length; j++)
                {
                    Console.Write(array2d[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        public void printMatrix(List<UndirectedGraph> list)
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