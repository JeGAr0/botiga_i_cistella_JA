//BOTIGA-----
string[,] productesBotiga = new string[3, 2];
int nElemBotiga = 0;
int capacidadMaxima = productesBotiga.GetLength(0);
int cont = capacidadMaxima;
char ampliar;
char seleccionarOpcio;

Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Red;

do
{
    Menu();
    seleccionarOpcio = char.ToLower(Console.ReadKey().KeyChar);

    switch (seleccionarOpcio)
    {
        case '1':   //AFEGIR PRODUCTES

            do
            {
                Console.Clear();
                Console.Write("Afegeix el producte: ");
                string nouProducte = Console.ReadLine();
                Console.Write("Afegeix el preu del producte: ");
                double nouPreu = Convert.ToSingle(Console.ReadLine());

                AfegirProducte(nouProducte, nouPreu);

                int numAmpliacio = 0;
                if (nElemBotiga > capacidadMaxima)
                {
                    Console.WriteLine("Vols ampliar la botiga? (s/n): ");
                    ampliar = Console.ReadKey().KeyChar;

                    if (ampliar == 's')
                    {
                        Console.WriteLine("Indica quant vols ampliar la botiga: ");
                        numAmpliacio = Convert.ToInt32(Console.ReadLine());
                    }

                    AmpliarBotiga(numAmpliacio);
                }

                Console.Clear();
                Console.WriteLine("Pulsa 'Esc' per sortir");
                Console.WriteLine("---------- o ----------");
                Console.WriteLine("Pulsa qualsevol tecla per afegir un altre producte");
            } while (Console.ReadKey().KeyChar != 27);

            
            
            MostrarMatriu(productesBotiga);
            CompteEnrera();

            break;

        case '2':   //MODIFICAR EL PREU D'UN PRODUCTE

            Console.Clear();
            Console.Write("El producte a modificar: ");
            string nomProducteModificar = Console.ReadLine();
            Console.Write("Preu al qual vols actualitzar el producte: ");
            string preuProducteModificar = Console.ReadLine();

            ModificarPreu(nomProducteModificar, preuProducteModificar);
            CompteEnrera();

            break;

        case '3':   //MODIFICAR EL NOM D'UN PRODUCTE
            
            Console.Clear();
            Console.Write("Nom del producte a modificar: ");
            string nomProducte = Console.ReadLine();
            Console.Write("Nou nom pel producte: ");
            string nomProducteModificat = Console.ReadLine();

            ModificarNomProducto(nomProducte, nomProducteModificat);
            CompteEnrera();

            break;

        case '4':   //ORDENAR PRODUCTES ALFABETICAMENT 2op(ASC / DESC)

            Console.Clear();
            Console.Write("Ordenar de manera ascendent o descendent?(asc / desc): ");
            string direccio = Console.ReadLine();
            OrdenarProducte(direccio.ToLower());
            CompteEnrera();

            break;

        case '5':   //ORDENAR PRODUCTES PER PREU 2op(ASC / DESC)

            Console.Clear();
            Console.Write("Ordenar de manera ascendent o descendent?(asc / desc): ");
            string direccioP = Console.ReadLine();
            OrdenarPreus(direccioP.ToLower());
            CompteEnrera();
            break;

        case '6':   //MOSTRAR TOTA LA BOTIGA

            Console.Clear();
            if (nElemBotiga == 0)
            {
                Console.WriteLine("Encara no n'hi han productes a la botiga");
            }
            else
            {
                MostrarMatriu(productesBotiga);
            }
            
            CompteEnrera();
            break;

        case '7':   //MOSTRAR LA CISTELLA

            break;
    }
    Console.Clear();
} while (seleccionarOpcio != '9');

//CISTELLA-----

//METODES DE LA BOTIGA-----

    //MENU DE LES OPCIONS
static void Menu()
{

    Console.Write(Centrar(DateTime.Now.ToString("ddd dd MMM")));

    Console.WriteLine(Centrar("                                           "));
    Console.WriteLine(Centrar("                                           "));
    Console.WriteLine(Centrar("                ▄▀▄     ▄▀▄                "));
    Console.WriteLine(Centrar("               ▄█░░▀▀▀▀▀░░█▄               "));
    Console.WriteLine(Centrar("           ▄▄  █░░░░░░░░░░░█  ▄▄           "));
    Console.WriteLine(Centrar("          █▄▄█ █░░▀░░┬░░▀░░█ █▄▄█          "));


    Console.WriteLine(Centrar(" ---------- Selecciona una opcio --------- "));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|        1. Afegir productes              |"));
    Console.WriteLine(Centrar("|        2. Modificar preu                |"));
    Console.WriteLine(Centrar("|        3. Modificar producte            |"));
    Console.WriteLine(Centrar("|        4. Ordenar per productes         |"));
    Console.WriteLine(Centrar("|        5. Ordenar per preus             |"));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|        6. Mostrar botiga                |"));
    Console.WriteLine(Centrar("|        7. Mostrar cistella              |"));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|        9. SORTIR                        |"));
    Console.WriteLine(Centrar("|-----------------------------------------|"));

}

    //CENTRAR CONTINGUT A LA CONSOLA
static string Centrar(string valor)
{
    int longitud = (valor.Length + 80) / 2;
    string cadenaAmbEspais = valor.PadLeft(longitud);
    return cadenaAmbEspais;
}

    //TEMPS ESPERA
static void CompteEnrera()
{
    int num = 5;
    while (num > 0)
    {
        Console.Write("\r");
        Console.Write(num);
        Thread.Sleep(1000);

        num--;
    }
}

    //AFEGEIX UN PRODUCTE A LA BOTIGA
void AfegirProducte(string producte, double preu)
{
    if (nElemBotiga < productesBotiga.GetLength(0))
    {
        productesBotiga[nElemBotiga, 0] = producte;
        productesBotiga[nElemBotiga, 1] = preu.ToString();
        nElemBotiga++;
    }
}

    //AMPLIA LA BOTIGA SEGON UN NUMERO DONAT
void AmpliarBotiga(int num)
{
    if (num <= 0)
    {
        Console.WriteLine("ERROR");
        return;
    }

    string[,] novaMatriuProductes = new string[productesBotiga.GetLength(0) + num, 2];

    for (int i = 0; i < productesBotiga.GetLength(0); i++)
    {
        novaMatriuProductes[i, 0] = productesBotiga[i, 0];
        novaMatriuProductes[i, 1] = productesBotiga[i, 1];
    }

    productesBotiga = novaMatriuProductes;

    Console.WriteLine($"S'ha ampliat la botiga {num} unitats");

    Console.WriteLine("--------------------------------------------");
}

    //MOSTRA LA MATRIU
static void MostrarMatriu(string[,] matriu)
{
    int files = matriu.GetLength(0);
    int columnes = matriu.GetLength(1);

    for (int i = 0; i < files; i++)
    {
        for (int j = 0; j < columnes; j++)
        {
            Console.Write(matriu[i, j] + " ");
        }
        Console.WriteLine();
    }
}

    //MODIFICAR EL PREU DEL PRODUCTE
void ModificarPreu(string producte, string preu)
{
    bool trobat = false;
    for (int i = 0; i < nElemBotiga; i++)
    {
        if (productesBotiga[i, 0] == producte)
        {
            productesBotiga[i, 1] = preu;
            trobat = true;
            Console.WriteLine($"{producte} ara te el preu de: {preu}");
            Console.WriteLine("--------------------------------------------");
        }
    }
    if (!trobat)
    {
        Console.WriteLine($"{producte} no trobat");
    }
}

    //MODIFICAR EL NOM DEL PRODUCTE
void ModificarNomProducto(string producte, string nom)
{
    bool trobat = false;
    for (int i = 0; i < nElemBotiga; i++)
    {
        if (productesBotiga[i, 0] == producte)
        {
            productesBotiga[i, 0] = nom;
            trobat = true;
            Console.WriteLine($"{producte} s'ha modificat a {nom}");
            Console.WriteLine("--------------------------------------------");
        }
    }
    if (!trobat)
    {
        Console.WriteLine($"{producte} no trobat");
    }
}

    //ORDENAR PRODUCTES PER ALFABET
void OrdenarProducte(string ordre)
{
    string[,] matriuAuxiliar = new string[nElemBotiga, 2];

    for (int i = 0; i < nElemBotiga; i++)
    {
        matriuAuxiliar[i, 0] = productesBotiga[i, 0];
        matriuAuxiliar[i, 1] = productesBotiga[i, 1];
    }

    for (int i = 0; i < nElemBotiga - 1; i++)
    {
        for (int j = i + 1; j < nElemBotiga; j++)
        {
            int comparacio = string.Compare(matriuAuxiliar[i, 0], matriuAuxiliar[j, 0]);
            if ((ordre == "asc" && comparacio > 0) ||
                (ordre == "desc" && comparacio < 0))
            {
                string tempNom = matriuAuxiliar[i, 0];
                string tempPreu = matriuAuxiliar[i, 1];
                matriuAuxiliar[i, 0] = matriuAuxiliar[j, 0];
                matriuAuxiliar[i, 1] = matriuAuxiliar[j, 1];
                matriuAuxiliar[j, 0] = tempNom;
                matriuAuxiliar[j, 1] = tempPreu;
            }
        }
    }

    Console.WriteLine("Productes ordenats:");
    MostrarMatriu(matriuAuxiliar);
}

    //ORDENAR PRODUCTES PER PREU
void OrdenarPreus(string ordre)
{
    string[,] matriuAuxiliar = new string[nElemBotiga, 2];

    for (int i = 0; i < nElemBotiga; i++)
    {
        matriuAuxiliar[i, 0] = productesBotiga[i, 0];
        matriuAuxiliar[i, 1] = productesBotiga[i, 1];
    }

    for (int i = 0; i < nElemBotiga - 1; i++)
    {
        for (int j = i + 1; j < nElemBotiga; j++)
        {
            double preu1 = Convert.ToDouble(matriuAuxiliar[i, 1]);
            double preu2 = Convert.ToDouble(matriuAuxiliar[j, 1]);

            if ((ordre == "asc" && preu1 > preu2) ||
                (ordre == "desc" && preu1 < preu2))
            {
                string tempNom = matriuAuxiliar[i, 0];
                string tempPreu = matriuAuxiliar[i, 1];
                matriuAuxiliar[i, 0] = matriuAuxiliar[j, 0];
                matriuAuxiliar[i, 1] = matriuAuxiliar[j, 1];
                matriuAuxiliar[j, 0] = tempNom;
                matriuAuxiliar[j, 1] = tempPreu;
            }
        }
    }

    Console.WriteLine("Productes ordenats per preu:");
    MostrarMatriu(matriuAuxiliar);
}

//METODES CISTELLA-----