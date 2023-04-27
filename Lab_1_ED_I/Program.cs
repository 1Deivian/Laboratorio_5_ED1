using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Lab_1_ED_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

                int counter = 0;
                string[] Apartamentos = new string[200];
                string[,] Amenidades = new string[200, 200];
                int[,] Pasos = new int[200, 200];
                string[] Requerimientos = new string[20];

                int apartment = 0;
                int contadorM = 1;
                int ContadorR = 0;
                int ContadorC = 0;
                int ContadorA = 0;
                int R = -1;
                int x = 0;
                int z = 0;
                int Rant = 100;
                int Ract = 100;
                int Rtot = 0;


                for (int i = 0; i < 200; i++)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        Amenidades[i, j] = "-";
                        Pasos[i, j] = 333;


                    }

                }

                for (int i = 0; i < 20; i++)
                {
                    Requerimientos[i] = "X";
                }


                // Read the file and display it line by line.  
                foreach (string line in System.IO.File.ReadLines(@"D:\Cosas\Clases\2023\Estructura de datos\txt\input_challenge.jsonl"))
                {

                    Console.Clear();
                    InputLab input = JsonSerializer.Deserialize<InputLab>(line)!;




                    foreach (Dictionary<string, bool> map in input.input1)
                    {
                        Console.WriteLine($"apartment: {apartment}");
                        foreach (KeyValuePair<string, bool> entry in map)
                        {
                            Console.WriteLine($"key {entry.Key} - value {entry.Value}");

                            if (entry.Value)
                            {

                                Amenidades[apartment, contadorM] = entry.Key;

                                contadorM++;
                            }

                        }
                        Pasos[apartment, 0] = apartment;
                        Amenidades[apartment, 0] = Convert.ToString(apartment);

                        apartment++;
                        Console.WriteLine($"-----------");
                    }
                    foreach (string requirement in input.input2)
                    {
                        Console.WriteLine($"requirement: {requirement}");
                        Requerimientos[ContadorR] = requirement;
                        ContadorR++;

                    }



                    for (int i = 0; i < 20; i++)
                    {
                        ContadorC = 0;
                        for (int j = 0; j < 200; j++)
                        {
                            for (int k = 1; k < 200; k++)
                            {
                                if (Amenidades[j, k] == Requerimientos[i])
                                {

                                    x = Convert.ToInt32(Amenidades[j, 0]);
                                    for (int P = 0; P < 200; P++)
                                    {
                                        for (int l = 0; l < 20; l++)
                                        {



                                            for (int m = 0; m < 200; m++)
                                            {
                                                for (int n = 1; n < 200; n++)
                                                {

                                                    if (Requerimientos[i] != Requerimientos[l])
                                                    {
                                                        if (Amenidades[m, 0] != "-")
                                                        {

                                                            z = Convert.ToInt32(Amenidades[m, 0]);
                                                            R = x - z;
                                                            if (Math.Abs(R) < Rant)
                                                            {
                                                                if (Rant < Ract)
                                                                {
                                                                    Ract = Rant;
                                                                    Requerimientos[i] = Requerimientos[l];
                                                                }

                                                            }

                                                        }







                                                    }

                                                }

                                            }
                                        }
                                        Rtot = Rtot + Ract;
                                    }
                                    ContadorC++;
                                }
                            }

                        }
                        if (ContadorC == 0)
                        {
                            Apartamentos[ContadorA] = "[]";
                            i = 20;
                        }

                    }
                    if (Rtot != 0)
                    {

                        Apartamentos[ContadorA] = "[" + Convert.ToString(Rtot) + "]";
                    }

                    Console.WriteLine();
                    Console.WriteLine("Resultados:");
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine(Apartamentos[i]);
                    }



                    ContadorA++;
                    counter++;

                    apartment = 0;
                    contadorM = 1;
                    ContadorR = 0;
                    ContadorC = 0;

                    R = -1;
                    x = 0;
                    z = 0;
                    Rant = 100;
                    Ract = 100;
                    Rtot = 0;


                    for (int i = 0; i < 20; i++)
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            Amenidades[i, j] = "-";
                            Pasos[i, j] = 333;
                            Requerimientos[i] = "X";

                        }

                    }
                }

                System.Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.  
                System.Console.ReadLine();


            
        }


    }
}

