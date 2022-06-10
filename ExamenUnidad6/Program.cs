using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamenUnidad6
{
    class Program
    {
        class InventarioAmazon
        {
            //Declaracion de campos
            string nombre, descripcion;
            float precio;
            int cantidad;

            //Metodo para agregar
            public void AgregarPro()
            {

                StreamWriter sw = new StreamWriter("Productos.txt", true);

                try
                {
                    Console.Clear();

                    //Captura de la informacion
                    Console.WriteLine("----------Estimado usuario, ingrese la informacion adecuada-----------");
                    Console.Write("Nombre del producto: ");
                    nombre = Console.ReadLine();
                    Console.Write("descripcion del producto: ");
                    descripcion = Console.ReadLine();
                    Console.Write("Precio del producto: ");
                    precio = float.Parse(Console.ReadLine());
                    Console.Write("Cantidad en Stock: ");
                    cantidad = int.Parse(Console.ReadLine());

                    Console.Clear();

                    //Captura en el archivo
                    sw.WriteLine("Nombre del producto: " + nombre);
                    sw.WriteLine("Descripcion: " + descripcion);
                    sw.WriteLine("Precio: {0:C}", precio);
                    sw.WriteLine("Cantidad en Stock: " + cantidad);
                    sw.WriteLine("El precio total a pagar sera de: {0:C} ", + CalcularCoste());
                    sw.WriteLine("");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.Clear();
                    Console.WriteLine("Prodcuto agregado al carrito exitosamente");
                    Console.Write("\n Presione enter para continuar");
                    sw.Close();
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            //Metodo para consultar historial
            public void LecturaInv()
            {
                try
                {
                    Console.Clear();
                    StreamReader sr = new StreamReader("Productos.txt");
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error, por favor de registrar un producto primero");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione ENTER para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            //Metodo para limpiar
            public void LimpiarInv()
            {
                Console.Clear();
                StreamWriter sw = new StreamWriter("Productos.txt", false);
                Console.WriteLine("Historial limpiado exitosamente");
                Console.WriteLine("Presione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }

            //Metodo para calcular el coste a pagar
            public float CalcularCoste()
            {
                return precio * cantidad;
            }
        }
        static void Main(string[] args)
        {
            byte op,opc;
            InventarioAmazon ama = new InventarioAmazon();
            do
            {
                Console.WriteLine("Bienvenido a la sucursal en linea de Amazon" +
                "\n1). Ingresar producto al carrito de compras" +
                "\n2). Limpiar historial de compras" +
                "\n3). Ver historial" +
                "\n4). Salir del programa");
                Console.Write( "\nSeleccione una opcion: ");
                op = byte.Parse(Console.ReadLine());
                Console.Clear();

                switch (op)
                {
                    case 1:
                        do
                        {
                            ama.AgregarPro();

                            //Pregunta al suario si quiere repetir la accion o no
                            Console.WriteLine("Le gustaria agregar otro producto? " +
                                "\n1.Si" +
                                "\n2.No");
                            Console.Write("Ingrese la opcion: ");
                            opc = byte.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (opc!=2);
                        break;
                    case 2:
                        ama.LimpiarInv();
                        break;
                    case 3:
                        do
                        {
                            ama.LecturaInv();

                            //Pregunta al suario si quiere repetir la accion o no
                            Console.WriteLine("Le gustaria ver nuevamente el historial? " +
                                "\n1.Si" +
                                "\n2.No");
                            Console.Write("Ingrese la opcion: ");
                            opc = byte.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (opc != 2);
                        break;
                    case 4:
                        Console.WriteLine("Agradecemos su preferencia, esperemas siga siendo cliente de nuestra sucursal");
                        Console.Write("Para salir del programa presione ENTER");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("Estimado usario, a ingresado una opcion incorrecta");
                        Console.Write(" Para salir del programa presione ENTER");
                        Console.ReadKey();
                        break;
                }
            } while (op != 4);

        }
    }
}
