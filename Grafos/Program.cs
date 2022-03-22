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
            MainMenuSwitch();


            void addNode<T>(List<T> genericList) where T : AbstractGraphs<T>

            {
                Console.WriteLine("Adicionando...");
                bool adding = true;
                while (adding)
                {
                    int genericCont;
                    if (genericList.GetType() == directedGraphs.GetType())
                    { contDirected++; genericCont = contDirected; }
                    else
                    { contUndirected++; genericCont = contUndirected; }

                    T genericNode = (T)Activator.CreateInstance(typeof(T));
                    genericNode.Number = genericCont;


                    if (genericList.Count > 0)
                    {
                        string connectedNode = "";
                        while (!connectedNode.Equals("0") && genericNode.RemainingNodesExist(genericList, genericNode))
                        {
                            Console.WriteLine("Este vertice se conecta com qual dos ja existentes vertices? (DIGITE 0 QUANDO NAO TIVER MAIS ITENS PARA CONECTAR)");
                            connectedNode = Console.ReadLine();
                            var numberForConnection = Convert.ToInt32(connectedNode);
                            if (Exists(numberForConnection, genericList) && numberForConnection != genericCont)
                            {
                                genericNode.LinkedNumbers.Add(numberForConnection);
                                if (genericList.GetType() == undirectedGraphs.GetType())
                                {
                                    ///CREATE LINK BETWEEN OTHER NODES
                                    genericList[numberForConnection - 1].LinkedNumbers.Add(genericNode.Number);
                                }
                            }
                            else if (numberForConnection.Equals(0)) { }
                            else
                            {
                                Console.WriteLine("ERRO: Este numero nao é valido...Por favor, digite um vertice existente e que nao é o proprio valor do vertice");
                            }
                        }
                    }
                    genericList.Add(genericNode);
                    Console.WriteLine("Continuar adicionando?\n" +
                        "1-Sim\n" +
                        "2-Nao");
                    var defineAdding = Console.ReadLine();
                    if (defineAdding.ToString().Equals("Nao") || defineAdding.ToString().Equals("2"))
                    {
                        create2dMatrix(genericList);
                        adding = false;
                    }
                }
            }


            void RemoveNode<T>(List<T> genericList) where T : AbstractGraphs<T>
            {
                if (genericList.Count.Equals(0)) { Console.WriteLine("ERRO: Nao existem pontos no grafo\n"); return; }
                bool removing = true;
                while (removing && genericList.Count > 0)
                {
                    Console.WriteLine("Removendo...");
                    Console.WriteLine("Qual vertice voce deseja remover?");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    if (Exists(userInput, genericList))
                    {
                        var itemToRemove = genericList.SingleOrDefault(r => r.Number.Equals(userInput));
                        genericList.Remove(itemToRemove);
                        //FOR EVERY GRAPH THAT HAS NUMBER GREATHER THAN THE REMOVED ONE
                        foreach (var item in genericList) if (item.Number > userInput)
                            {
                                item.Number--;
                            }
                        foreach (var item in genericList)
                        {

                            for (int i = 0; i < item.LinkedNumbers.Count; i++)
                            {
                                if (item.LinkedNumbers[i] > userInput)
                                {
                                    item.LinkedNumbers[i]--;
                                }
                                else if (item.LinkedNumbers[i].Equals(userInput))
                                {
                                    item.LinkedNumbers = item.LinkedNumbers.Where(val => val != userInput).ToList();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERRO: Vertice inexistente");
                    }
                    Console.WriteLine("Continuar removendo?");
                    Console.WriteLine("1-Sim\n" +
                        "2-Nao");
                    var isStillRunning = Console.ReadLine();
                    if (isStillRunning.ToString().Equals("2") || isStillRunning.ToString().Equals("Nao"))
                    {
                        create2dMatrix(genericList);
                        removing = false;
                    }
                }
            }


            void ModifyNode<T>(List<T> genericList) where T : AbstractGraphs<T>
            {
                Console.WriteLine("Qual vertice voce gostaria de modificar?");
                var modifyConection = Convert.ToInt32(Console.ReadLine());
                while (!Exists(modifyConection, genericList) && !modifyConection.Equals(0))
                {
                    Console.WriteLine("ERRO: Selecione um numero de um vertice que existe\n" + "DIGITE 0 PARA VOLTAR");
                    modifyConection = Convert.ToInt32(Console.ReadLine());

                }
                if (modifyConection.Equals(0)) { }
                else
                {
                    Console.WriteLine("Voce deseja:\n" +
                    "0-Voltar\n" +
                    "1-Retirar relacao\n" +
                    "2-Adicionar relacao");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    while (userInput != 1 && userInput != 2 && userInput != 0)
                    {
                        Console.WriteLine("Por favor selecione uma opcao valida");
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    if (userInput.Equals(0)) { return; }
                    else if (userInput.Equals(1))
                    {
                        PrintConections(genericList, modifyConection);
                        RemoveConection(genericList, modifyConection);
                    }
                    else
                    {
                        AddConnection(genericList, modifyConection);
                    }

                }


            }
            void AddConnection<T>(List<T> genericList, int number) where T : AbstractGraphs<T>
            {
                var element = genericList[number - 1];
                Console.WriteLine("Voce quer fazer uma conexao com qual dos vertices?");
                var toAddTo = Convert.ToInt32(Console.ReadLine());

                while (toAddTo.Equals(number))
                {
                    Console.WriteLine("ERRO: O numero nao pode se conectar com ele mesmo, tente novamente");
                    toAddTo = Convert.ToInt32(Console.ReadLine());
                }
                if (Exists(toAddTo, genericList))
                {
                    element.LinkedNumbers.Add(toAddTo);
                    if (genericList.GetType().Equals(undirectedGraphs.GetType()))
                    {
                        genericList[toAddTo - 1].LinkedNumbers.Add(number);
                    }

                }
                else
                {
                    Console.WriteLine("ERRO: O vertice que voce esta tentando se conectar nao existe");
                }
            }

            void RemoveConection<T>(List<T> genericList, int modifyNode) where T : AbstractGraphs<T>
            {
                string elementToRemove;
                var element = genericList[modifyNode - 1];
                Console.WriteLine("");
                if (element.LinkedNumbers.Count > 1)
                {
                    elementToRemove = "";
                    Console.WriteLine("Qual das conexoes acima voce deseja remover?");
                    elementToRemove = Console.ReadLine();
                    while (elementToRemove != "" && !element.LinkedNumbers.Contains(Convert.ToInt32(elementToRemove)))
                    {
                        Console.WriteLine("Informe uma conexao valida");
                        elementToRemove = Console.ReadLine();
                    }
                }
                else if (element.LinkedNumbers.Count.Equals(0))
                {
                    Console.WriteLine("ERRO: Nenhuma conexao para remover");
                    return;
                }
                else
                {
                    elementToRemove = element.LinkedNumbers.First().ToString();
                }
                element.LinkedNumbers.Remove(Convert.ToInt32(elementToRemove));
                if (genericList.GetType().Equals(undirectedGraphs.GetType()))
                {
                    var index = (Convert.ToInt32(elementToRemove)) - 1;
                    genericList[index].LinkedNumbers.Remove(modifyNode);
                }
            }
            void PrintConections<T>(List<T> genericList, int number) where T : AbstractGraphs<T>
            {
                var element = genericList[number - 1];
                Console.Write($"O elemento: {element.Number} possui a(s) seguinte(s) conexao(oes): ");
                foreach (var x in element.LinkedNumbers)
                {
                    Console.Write(" " + x);
                }
            }

            void ShowMenu()
            {
                Console.WriteLine(
                 "1-Adicionar vertice direcionado \n" +
                 "2-Remover vertice direcionado\n" +
                 "3-Modificar as conexoes de um vertice direcionado\n" +   
                 "4-Adicionar vertice NAO direcionado  \n" +
                 "5-Remover vertice NAO direcionado \n" +
                 "6-Modificar as conexoes de um vertice NAO direcionado\n" +
                 "7-Busca de profundidade\n" +
                 "8-Busca em largura\n" +
                 "9-Printar meu grafo \n" +
                 "10-Sair"
                );
            }
            void Search(int search)
            {
                Console.WriteLine("1-Direcionado\n" +
                    "2-Nao direcionado");
                var userListChoice = Convert.ToInt32(Console.ReadLine());
                while(!userListChoice.Equals(1) && !userListChoice.Equals(2))
                {
                    Console.WriteLine("Opcao invalida, tente novamente");
                    userListChoice = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Qual numero do ponto que voce esta procurando?");
                var numberToSearchFor = Convert.ToInt32(Console.ReadLine());
                
                if (userListChoice.Equals(1) && search.Equals(1)) 
                {

                    DepthSearch(directedGraphs, numberToSearchFor);
                }
                else if(userListChoice.Equals(2) && search.Equals(1))
                {

                    DepthSearch(undirectedGraphs, numberToSearchFor);
                }
                else if(userListChoice.Equals(1) && search.Equals(2))
                {
                    BreadthSearch(directedGraphs, numberToSearchFor);

                }
                else
                {
                    BreadthSearch(undirectedGraphs, numberToSearchFor);
                }

            }
        

            void DepthSearch<T>(List<T> genericList, int numberToSearchFor) where T : AbstractGraphs<T>
            {
                int numberToStart = -1;
                Console.WriteLine("Qual sera o vertice de partida?");
                numberToStart = Convert.ToInt32(Console.ReadLine());
                while (!Exists(numberToStart, genericList)){
                    Console.WriteLine("Ponto inexistente, tente novamente");
                    numberToStart = Convert.ToInt32(Console.ReadLine());
                }

                Stack<int> stack = new Stack<int>();
                List<int> controllerList = new List<int>();
                stack.Push(numberToStart);
                controllerList.Add(numberToStart);
                var initialObj = genericList.FirstOrDefault(obj => obj.Number.Equals(numberToStart));

                while (controllerList.Count() != genericList.Count())
                {
                    while (initialObj.LinkedNumbers.Count > 0 && !initialObj.LinkedNumbers.All(item=> controllerList.Contains(item)))
                    {
                        var test = initialObj.LinkedNumbers.All(item => controllerList.Contains(item));
                        int nextNumber = -1;
                        for (int i = 0; i < initialObj.LinkedNumbers.Count; i++)
                        {
                            if (!controllerList.Contains(initialObj.LinkedNumbers[i]))
                            {
                                nextNumber = initialObj.LinkedNumbers[i];
                            } 
                        }
                        var nextObj = genericList.FirstOrDefault(obj => obj.Number.Equals(nextNumber));
                        stack.Push(nextNumber);
                        controllerList.Add(nextNumber);
                        initialObj = nextObj;
                        if (nextNumber.Equals(numberToSearchFor))
                        {
                            Console.WriteLine("Encontrado");
                            return;
                        }
                    }
                    
                    if (stack.Count > 0)
                    {
                        
                        initialObj.Number = stack.Peek();
                        stack.Pop();
                    }
                    else
                    {
                        T temp = null;
                        for (int i = 0; i < genericList.Count(); i++)
                        {
                            
                            if (!controllerList.Contains(genericList[i].Number))
                            {
                                temp= initialObj;
                                initialObj = genericList.FirstOrDefault(obj => obj.Number.Equals(genericList[i].Number));
                                
                            }
                        }
                        if (initialObj != temp)
                        {
                            controllerList.Add(initialObj.Number);
                        }
                    }
                    if (initialObj.Number.Equals(numberToSearchFor))
                    {
                        Console.WriteLine("Encontrado");
                        return;
                    }
                }
                Console.WriteLine("Nao encontrado");
                return;
            }

            void BreadthSearch<T>(List < T > genericList, int numberToSearchFor) where T : AbstractGraphs<T>
            {
                Queue<int> queue = new Queue<int>();
                List<int> controllerList = new List<int>();
                var elementT = -1;
                Console.WriteLine("Qual sera o vertice de partida?");
                elementT = Convert.ToInt32(Console.ReadLine());
                while (!Exists(elementT, genericList))
                {
                    Console.WriteLine("Ponto inexistente, tente novamente");
                    elementT = Convert.ToInt32(Console.ReadLine());
                }
                controllerList.Add(elementT);
                
                while (controllerList.Count() != genericList.Count())
                {
                    if (genericList[elementT-1].LinkedNumbers.Count() > 0)
                    {
                        for (int i = 0; i < genericList[elementT-1].LinkedNumbers.Count(); i++)
                        {
                            elementT = genericList[elementT - 1].LinkedNumbers[i];
                            if (!queue.Contains(elementT) && !controllerList.Contains(elementT))
                            {
                                queue.Enqueue(elementT);
                            }  
                        }
                        elementT = queue.Peek();
                        controllerList.Add(elementT);
                        queue.Dequeue();

                    }
                    else if (queue.Count() > 0)
                    {
                        elementT = queue.Peek();
                        controllerList.Add(elementT);
                    }
                    else
                    {
                        foreach (var element in genericList)
                        {
                            if (!controllerList.Contains(element.Number))
                            {
                                elementT = element.Number;
                                queue.Enqueue(elementT);
                            }
                        }
                        controllerList.Add(elementT);
                    }
                    if (elementT.Equals(numberToSearchFor)||queue.Contains(numberToSearchFor)) { Console.WriteLine("Encontrei"); return; }

                }
                Console.WriteLine("Nao encontrei");
                return;
            }
            void PrintMyGraph()
            {
                Console.WriteLine("1-Printar grafo direcionado\n" +
                    "2- Printar grafo nao direcionado?");
                var userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput.Equals(1))
                {
                    create2dMatrix(directedGraphs);
                }
                if (userInput.Equals(2))
                {
                    create2dMatrix(undirectedGraphs);
                }
            }

            bool Exists<T>(int numberToSearch, List<T> list) where T : AbstractGraphs<T>
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

            void MainMenuSwitch()
            {
                ShowMenu();
                var userAnswer = Console.ReadLine();

                switch (userAnswer)
                {
                    case "1":
                        addNode(directedGraphs);
                        MainMenuSwitch();
                        break;
                    case "2":
                        RemoveNode(directedGraphs);
                        MainMenuSwitch();
                        break;
                    case "3":
                        ModifyNode(directedGraphs);
                        MainMenuSwitch();
                        break;

                    case "4":
                        addNode(undirectedGraphs);
                        MainMenuSwitch();
                        break;
                    case "5":
                        RemoveNode(undirectedGraphs);
                        MainMenuSwitch();
                        break;
                    case "6":
                        ModifyNode(undirectedGraphs);
                        MainMenuSwitch();
                        break;
                    case "7":
                        Search(1);
                        MainMenuSwitch();
                        break;
                    case "8":
                        Search(2);
                        MainMenuSwitch();
                        break;
                    case "9":
                        PrintMyGraph();
                        MainMenuSwitch();
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Por favor, selecione uma opcao valida");
                        break;
                }
            }
        }

        public static void create2dMatrix<T>(List<T> list) where T : AbstractGraphs<T>
        {
            var array = list.ToArray();
            Console.WriteLine("Em meu array list tem: " + array.Length);
            int[,] array2d = new int[array.Length, array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                var test = array[i].LinkedNumbers.ToArray();

                for (int z = 0; z < array.Length; z++)
                {
                    array2d[i, z] = 0;
                }
                Console.WriteLine("");
            }
            Print2dMatrix(list, array2d);
        }
        public static void Print2dMatrix<T>(List<T> list, int[,] array2d) where T : AbstractGraphs<T>
        {
            var array = list.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                foreach (var numberLink in array[i].LinkedNumbers)
                {
                    array2d[i, (numberLink - 1)] = 1;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
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