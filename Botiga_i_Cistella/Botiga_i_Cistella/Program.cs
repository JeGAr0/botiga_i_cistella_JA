// BOTIGA
string[,] productesBotiga = new string[5, 2];
int nElemBotiga = 0;
char continuar = 's';


while (continuar == 's')
{
    Console.Write("Afegeix el producte: ");
    string nouProducte = Console.ReadLine();
    Console.Write("Afegeix el preu del producte: ");
    double nouPreu = Convert.ToSingle(Console.ReadLine());

    AfegirProducte(nouProducte, nouPreu);
    Console.WriteLine("Vols seguir afegint productes?(s/n): ");
    continuar = Console.ReadKey().KeyChar;
    Console.Clear();
}

MostrarMatriz(productesBotiga);

void AfegirProducte(string producte, double preu)
{
    if (nElemBotiga < productesBotiga.GetLength(0))
    {
        productesBotiga[nElemBotiga, 0] = producte;
        productesBotiga[nElemBotiga, 1] = preu.ToString();
        nElemBotiga++;
        Console.WriteLine($"Producte {producte} afegit amb preu {preu}.");
        Console.WriteLine("--------------------------------------------");
    }
    else
    {
        Console.WriteLine("La botiga està plena, no es poden afegir més productes.");
    }
}


static void MostrarMatriz(string[,] matriz)
{
    int filas = matriz.GetLength(0);
    int columnas = matriz.GetLength(1);

    for (int i = 0; i < filas; i++)
    {
        for (int j = 0; j < columnas; j++)
        {
            Console.Write(matriz[i, j] + " ");
        }
        Console.WriteLine();
    }
}
// METODES CISTELLA