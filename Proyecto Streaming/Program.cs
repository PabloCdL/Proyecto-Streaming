//Definicion de mis variables
//VAriables de operaciones
string tipocontenido;
int duracion;
string clasificacion;
int hora;
string nivelP;
int opcion;
//Variables Contadoritas :D
int publicado = 0;
int revision = 0;
int totalevaluados = 0;
int impactobajo = 0;
int impactomedio = 0;
int impactoalto = 0;
int rechazados = 0;
//Variables Auxiliares
bool valido = true;
string razon = "";
string impacto = "";
int num;
double porcentaje;

do
{
    menu();
    Console.Clear();
    switch (opcion)
    {
    case 1: // Evaluar nuevo contenido

        break;
    case 2: // Mostrar reglas del sistema

        break;
    case 3: // Estadisticas de la sesion

        break;
    case 4: //Reiniciar estadisticas

        break;
    case 5: // resumen

        break;
    default: // Caso invalido
        Console.WriteLine("Opcion no valida");
        break;
    }

} while (opcion != 5);

    void menu()
    {
        Console.WriteLine("______Menú_____");
        Console.WriteLine("1. Evaluar nuevo contenido");
        Console.WriteLine("2. Mostrar reglas del sistema");
        Console.WriteLine("3. Estadisticas de la sesion");
        Console.WriteLine("4. Reiniciar estadisticas");
        Console.WriteLine("5. Salir");
        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Invalido: \n Intente de nuevo");
            Console.ReadKey();
        }
        Console.Clear();
    }
void Evalcuaion()
{
    valido = true;
    razon = "";
    impacto = "";
}

string LeerTexto(string mensaje)
{
    Console.WriteLine(mensaje);
    return Console.ReadLine() ?? "";
}

int LeerEntero(string mensaje)
{
    Console.WriteLine(mensaje);
    while (!int.TryParse(Console.ReadLine(), out num))
    {
        Console.WriteLine("Error papito. Invalido lo que metio");
    }
    return num;
}

