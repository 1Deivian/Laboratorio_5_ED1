using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Lab_1_ED_I
{
    internal class Program
    {
        static int BuscadorDeApart(string[][] blocks, string[] reqs)
        {
            int[] distancias = new int[blocks.Length];

            // Para cada requerimiento, calcula la distancia de cada bloque a ese requerimiento
            foreach (string req in reqs)
            {
                for (int b = 0; b < blocks.Length; b++)
                {
                    int menorDistancia = int.MaxValue;
                    for (int s = 0; s < blocks.Length; s++)
                    {
                        if (blocks[s].Contains(req))
                        {
                            int distancia = Math.Abs(b - s);
                            if (distancia < menorDistancia)
                            {
                                menorDistancia = distancia;
                            }
                        }
                    }
                    distancias[b] += menorDistancia;
                }
            }

            // Encuentra el índice del apartamento que tenga la menor suma de distancias
            int menorDistancia = int.MaxValue;
            int resultado = -1;
            for (int i = 0; i < distancias.Length; i++)
            {
                if (distancias[i] < menorDistancia)
                {
                    menorDistancia = distancias[i];
                    resultado = i;
                }
            }

            return resultado;
        }
    }
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


            var blocks = new[] {
            new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Mall", true } },
            new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Barber Shop", true } },
            new Dictionary<string, bool> { { "Park", true } }, new Dictionary<string, bool> { { "Gas Station", true } },
            new Dictionary<string, bool> { { "Kindergarten", false } }, new Dictionary<string, bool>(),
            new Dictionary<string, bool> { { "Gas Station", true }, { "Hospital", false } },
            new Dictionary<string, bool> { { "Mall", true }, { "Beauty Salon", true } },
            new Dictionary<string, bool> { { "Mall", true }, { "Beauty Salon", true } }, new Dictionary<string, bool> { { "Bar", true } },
            new  Dictionary<string, bool>(), new Dictionary<string, bool> { { "Cofee shop", true } },
            new Dictionary<string, bool> { { "Grocery", true }, { "Kindergarten", true } },
            new Dictionary<string, bool> { { "Gas Station", false }, { "Mall", false } },
            new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Beauty Salon", true } },
            new Dictionary<string, bool> { { "Clinic", true }, { "Mall", false } },
            new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Gym", true }, { "Bakery", false } },
            new Dictionary<string, bool>(), new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Mall", true }, { "Park", true } },
            new Dictionary<string, bool> { { "Clinic", true } }, new Dictionary<string, bool> { { "Barber Shop", true } },
            new Dictionary<string, bool> { { "Clinic", true }, { "Barber Shop", true } },
            new Dictionary<string, bool> { { "Gym", false }, { "Gas Station", false } },
            new Dictionary<string, bool> { { "Gas Station", true }, { "Academy", false } },
            new Dictionary<string, bool> { { "Vet", false } }, new Dictionary<string, bool> { { "Restaurant", true } },
            new Dictionary<string, bool>(), new Dictionary<string, bool>(), new Dictionary<string, bool>(),
            new Dictionary<string, bool> { { "Mall", true } }, new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Mall", false }, { "Vet", true } },
            new Dictionary<string, bool> { { "Academy", false }, { "Beauty Salon", false }, { "Cofee shop", true } },
            new Dictionary<string, bool>(), new Dictionary<string, bool> { { "Bar", true }, { "Academy", false } },
            new Dictionary<string, bool> { { "Restaurant", true }, { "Beauty Salon", true }, { "Kindergarten", true } },
            new Dictionary<string, bool>(), new Dictionary<string, bool>(), new Dictionary<string, bool>(),
            new Dictionary<string, bool> { { "Beauty Salon", true }, { "Vet", false }, { "Barber Shop", true } },
};

            var familyBlocks = new[] {
            new List<string> { "Gas Station", "Park", "Bar" },
            new List<string> { "Mall", "Beauty Salon" },
            new List<string> { "Gas Station", "Hospital" },
            new List<string> { "Park", "Cofee shop" },
            new List<string> { "Mall", "Kindergarten" },
            new List<string> { "Gym", "Academy" },
            new List<string> { "Gas Station", "Clinic", "Vet" },
            new List<string> { "Grocery", "Bar" },
            new List<string> { "Clinic", "Barber Shop" },
            new List<string> { "Mall", "Restaurant" }
};
        }

        System.Console.WriteLine("There were {0} lines.", counter);
        // Suspend the screen.  
        System.Console.ReadLine();



    }




}

