using DemoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alfabetocliente
{
    class Program
    {
        static void Main(string[] args)
        {
            //obtenemos de DB lista de alfabeto
            Console.WriteLine("obteniendo datos......./n");    //NOTA:
            var mialfabeto = new myHelperData().GeTAlfabeto(); //Este codigo no va ha funcionar si no tienes la base de datos.
                                                               //Recuerda tener la cada de coneccion en los dos App.Config


            //Leemos txt
            Console.WriteLine("cargando archivo ...................");
            string text = System.IO.File.ReadAllText(@"C:\Users\edgar\Documents\Proyectos .Net\nombres.txt");
            
            //Quitamos las comillas y separo los nombre en un arreglo
            var arrNombres = text.Replace("\"", "").Split(',');

            //ordenamos lista sin comillas alfabeticamente
            Console.WriteLine("Ordenando ...................");
            //Declaracion de la Instruccion de modificacion del Arreglo.
            Comparison<string> comparador = new Comparison<string>((cadena1, cadena2) => cadena1.CompareTo(cadena2));
            Array.Sort<string>(arrNombres, comparador);
            
            
            int count = 1;
            int sumatotal = 0;
            Console.WriteLine("Calculando ...................");
            //recorre todas los nombres
            foreach (string nombre in arrNombres)
            {
                int? value = 0;
                //recorre las letras del nombre
                for (int i = 0; i < nombre.Length; i++)
                {
                    //obtiene la letra
                    var letra = nombre[i];
                    //obtiene el valor de la letra desde nuesta lista de alfabeto de DB y la suma
                    value += mialfabeto.Where(c => c.fcValue == letra.ToString()).FirstOrDefault().fiIdKey;
                }
                //se multiplica valor de la letra  por la posicion de la letra
                var sumletra = value * count;
                Console.WriteLine($"nombre: {nombre} \tvalor:{value} \tposicion: {count} \tPuntuacion: {sumletra}\n");
                //se suma total de valor de letras
                sumatotal += (int)sumletra;
                count++;
            }

            Console.WriteLine($"Total de Nombre: {arrNombres.Length} Puntuacion total: {sumatotal}");
            Console.ReadLine();
        }
    }
}
