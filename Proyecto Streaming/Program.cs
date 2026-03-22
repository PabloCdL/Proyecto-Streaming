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
Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;
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
    Console.WriteLine("EVALUACION DE CONTENIDO");
    tipocontenido = LeerTexto("Tipo de contenido (película, serie, documetal, evento)").ToLower();
    while ((tipocontenido != "película" && tipocontenido != "pelicula") && tipocontenido != "serie" && tipocontenido != "documental" && tipocontenido != "evento")
    {
        Console.WriteLine("Error. Ingrese una opcion valida o verifique si esta bien escribicida");
        tipocontenido = LeerTexto("Tipo de contenido (película, serie, documetal, evento)").ToLower();
    }
    duracion = LeerEntero("Ingrese la duracion en minutos");
    clasificacion = LeerTexto("Clasificacion (Todo publico, +13, +18)").ToLower();
    while (clasificacion != "todo publico" && clasificacion != "+13" && clasificacion != "+18")
    {
        Console.WriteLine("Error. Ingrese una opcion valida o verifique si esta bien escribicida");
        clasificacion = LeerTexto("Clasificacion (Todo publico, +13, +18)").ToLower();
    }
    hora = LeerEntero("Ingrese la hora programada (0-23)");
    while (hora >= 24 || hora <= 0)
    {
        Console.WriteLine("Error. Ingrese una hora valida");
        hora = LeerEntero("Ingrese la hora programada (0-23)");
    }
    nivelP = LeerTexto("Ingrese el nivel de produccion (baja, media, alta)").ToLower();
    while (nivelP != "baja" && nivelP != "media" && nivelP != "alta")
    {
        Console.WriteLine("Error. Ingrese una opcion valida o verifique si esta bien escribicida");
        nivelP = LeerTexto("Ingrese el nivel de produccion (baja, media, alta)").ToLower();
    }

    //Reglas de calsificacion y horario
    if (clasificacion == "+13")
    {
        if (hora < 6 || hora > 22)
        {
            valido = false;
            razon = "Horario no permitido :(";
        }
    }
    else if (clasificacion == "+18")
    {
        if (hora >= 5 && hora < 22)
        {
            valido = false;
            razon = "horario no permitido :(";
        }
    }
    //Reglas de duracion
    if (valido)
    {
        if (tipocontenido == "película" || tipocontenido == "pelicula")
        {
            if (duracion < 60 || duracion > 180)
            {
                valido = false;
                razon = "Duracion esta fuera de rango para pelicula";
            }
        }
        else if (tipocontenido == "serie")
        {
            if (duracion < 20 || duracion > 90)
            {
                valido = false;
                razon = "Duracion fuera de rango para serie";
            }
        }
        else if (tipocontenido == "documental")
        {
            if (duracion < 30 || duracion > 120)
            {
                valido = false;
                razon = "Duracion fuera de rango para documental";
            }
        }
        else if (tipocontenido == "evento")
        {
            if (duracion < 30 || duracion > 240)
            {
                valido = false;
                razon = "Duracion fuera de rango para evento";
            }
        }
    }

    //Reglas de produccion
    if (valido && nivelP == "baja" && clasificacion == "+18")
    {
        valido = false;
        razon = "Produccion baja solo para todo publico o +13";
    }
    totalevaluados++;

    //Impacto
    if (!valido)
    {
        Console.WriteLine($"Rechazar: {razon}");
        rechazados++;
    }
    else
    {
        if (nivelP == "alto" || duracion > 120 || (hora >= 20 && hora <= 23))
        {
            impacto = "alto";
            impactoalto++;
        }
        else if (nivelP == "medio" || (duracion >= 60 && duracion <= 120))
        {
            impacto = "medio";
            impactomedio++;
        }
        else
        {
            impacto = "baja";
            impactobajo++;
        }

        if (impacto == "alto")
        {
            Console.WriteLine("Enviar a revision (Impacto alto)");
            revision++;
        }
        else
        {
            Console.WriteLine($"Publicar (Impacto {impacto})");
            publicado++;
        }
    }

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

void Estadisticas()
{
    Console.WriteLine("Estadisticas");
    Console.WriteLine($"Total de evaluaciones: {totalevaluados}");
    Console.WriteLine($"Publicaciones: {publicado}");
    Console.WriteLine($"Rechazados: {rechazados}");
    Console.WriteLine($"Revision: {revision}");
    if (totalevaluados > 0)
    {
        porcentaje = (double)publicado / totalevaluados * 100;
        Console.WriteLine($"El porcentaje de aprovacion es de: {porcentaje:F2} %");
    }
}

void reiniciar()
{
    totalevaluados = 0;
    publicado = 0;
    revision = 0;
    rechazados = 0;
    Console.WriteLine("Reiniciando...");
}

void reglas()
{
    for (int i = 0; i < 20; i++) Console.Write("=");
    Console.WriteLine("Reglas tecnicas :D");
    Console.WriteLine("1. Peliculas: 60-180 minutos");
    Console.WriteLine("2. Serie: 20-90 minutos");
    Console.WriteLine("3. Documental: 30-120 minutos");
    Console.WriteLine("4. Evento en vivo: 30-240 minutos");
    Console.WriteLine("5. Reloj de 24 horas");
    Console.WriteLine("6. Opciones de contenido:\n * Peliculas \n * Serie \n * Documental \n Envento en vivo");
}
