using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Reflection;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcio;
            int codigoAluno = 51;
            do
            {
                Console.WriteLine("[ 1 ] Creació d'un objecte");
                Console.WriteLine("[ 2 ] Retornar el path absolut actual");
                Console.WriteLine("[ 3 ] Obrir i llistar un directori ");
                Console.WriteLine("[ 4 ] Retornar el número d' elements dins d'un directori");
                Console.WriteLine("[ 5 ] Retornar si un path determinat és un directori");
                Console.WriteLine("[ 6 ] Retornar si un path determinat és un fitxer");
                Console.WriteLine("[ 7 ] Comprovar permisos d'escriptura");
                Console.WriteLine("[ 8 ] Retorna l'element pare del File actual");
                Console.WriteLine("[ 9 ] Retornar la data de la última modificació");
                Console.WriteLine("[ 10 ] Retornar si un fitxer es ocult");
                Console.WriteLine("[ 11 ] Retorna l'espai que ocupa un directori");
                Console.WriteLine("[ 12 ] Comprovar si un fitxer o directori existeix");
                Console.WriteLine("[ 13 ] Crear un nou fitxer ");
                Console.WriteLine("[ 14 ] Esborrar un fitxer");
                Console.WriteLine("[ 15 ] Modificar nom d'un fitxer");
                Console.WriteLine("[ 16 ] Copiar un fitxer a un nou path");
                Console.WriteLine("[ 17 ] Mostrar contingut fitxer");
                Console.WriteLine("[ 0 ] Sortir");
                Console.WriteLine("-------------------------------------");
                Console.Write("Escull una opció: ");
                opcio = Int32.Parse(Console.ReadLine());
                switch (opcio)
                {
                    case 1:
                        ex1();
                        break;
                    case 2:
                        ex2();
                        break;
                    case 3:
                        ex3();
                        break;
                    case 4:
                        ex4();
                        break;
                    case 5:
                        ex5();
                        break;
                    case 6:
                        ex6();
                        break;
                    case 7:
                        ex7();
                        break;
                    case 8:
                        ex8();
                        break;
                    case 9:
                        ex9();
                        break;
                    case 10:
                        ex10();
                        break;
                    case 11:
                        ex11();
                        break;
                    case 12:
                        ex12();
                        break;
                    case 13:
                        ex13();
                        break;
                    case 14:
                        ex14();
                        break;
                    case 15:
                        ex15();
                        break;
                    case 16:
                        ex16();
                        break;
                    case 17:
                        ex17();
                        break;
                    default:
                        sortirPrograma();
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (opcio != 0);
        }

        private static void sortirPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Gràcies per utilitzar el nostre menú. Apreta una tecla per sortir...");
        }

        private static void ex1()
        {
            Console.WriteLine();
            FileStream objecte = new FileStream(@"C:\\random\random.txt", FileMode.Create);
        }

        private static void ex2()
        {
            Console.WriteLine();
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
        }
        
        private static void ex3()
        {
            Console.WriteLine();
            //Busco tot el contingut del directori actual
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories);
            foreach (var file in allfiles){
                FileInfo info = new FileInfo(file);
                //mostro cada ruta obtenida del for
                Console.WriteLine(file);
            }
        }
        
        private static void ex4()
        {
            Console.WriteLine();
            int contador = 0;
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories);
            foreach (var file in allfiles)
                //Amb el codi anterior faig un contador i el mostro al final del for, per tal de mostrar el nombre total.
            {
                contador = contador + 1;
            }
            Console.WriteLine(contador);
        }
        
        private static void ex5()
        {
            Console.WriteLine();
            FileAttributes attr = File.GetAttributes(@"C:\random");
            
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                Console.WriteLine("és un directori");
            else
            {
                Console.WriteLine("No és un directori");
            }
        }
        
        
        private static void ex6()
        {
            Console.WriteLine();
            FileAttributes attr = File.GetAttributes(@"C:\random\random.txt");
            
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                Console.WriteLine("No és un fitxer");
            else
            {
                Console.WriteLine("És un fitxer");
            }
        }
        
        private static void ex7()
        {
            Console.WriteLine();
            var escr = File.Open(@"C:\random\random.txt", FileMode.Open);
            var canWrite = escr.CanWrite;
            if (canWrite == true)
            {
                Console.WriteLine("Té permisos d'escriptura");
            }
            else
            {
                Console.WriteLine("No té permisos d'escriptura'");
            }
        }
        
        private static void ex8()
        {
            Console.WriteLine();
            string parent = System.IO.Directory.GetParent(@"C:\random\random.txt").FullName;
            Console.WriteLine(parent);
        }
        
        private static void ex9()
        {
            Console.WriteLine();
            string dada = File.GetLastWriteTime(@"C:\random\random.txt").ToString();
            Console.WriteLine(dada);
        }
        
        private static void ex10()
        {
            Console.WriteLine();
            //comprovo si és un fitxer ocult amb l'atribut hidden
            bool isHidden = (File.GetAttributes(@"C:\random\random.txt") & FileAttributes.Hidden) == FileAttributes.Hidden;
            Console.WriteLine(isHidden);
        }
        
        private static void ex11()
        {
            Console.WriteLine();
            string[] d = Directory.GetFiles(@"C:\random","*");
            //faig una variable long que guardarà la mida total
            long size = 0;
            //faig una traça amb un for a la llista de fitxers mentre sumo la mida cada vegada
            foreach (string file in d) 
            {      
                size += file.Length;
            }
            //mostro la mida final
            Console.WriteLine(size);
        }
        
        private static void ex12()
        {
            Console.WriteLine();
            //faig un booleà que comprovarà si el directori o el fitxer existeix, mostrarà true o false
            bool exists = (Directory.Exists(@"C:\random") || File.Exists(@"C:\random"));
            Console.WriteLine(exists);
        }
        
        private static void ex13()
        {
            Console.WriteLine();
            //streamWriter ja farà la comprovació i crearà el fitxer si no existeix
            using (StreamWriter w = File.AppendText(@"C:\random\log.txt"));
            // tot i així faig la comprovació per mostrar per pantalla si ja existeix
            if (File.Exists(@"C:\random\log.txt"))
            {
                Console.WriteLine("Ja existeix");
            }
            else
            {
                Console.WriteLine("S'ha creat el fitxer");
            }
        }
        
        private static void ex14()
        {
            Console.WriteLine();
            //Comprovo si existeix el fitxer, si és així el borra si no mostra que no existeix
            if(File.Exists(@"C:\random.txt"))
            {
                File.Delete(@"C:\random.txt");
                Console.WriteLine("S'ha esborrat'");
            }
            else
            {
                Console.WriteLine("No existeix");
            }
        }
        
        private static void ex15()
        {
            Console.WriteLine();
            //si existeix mou el fitxer a una nova ruta (especifico el nou nom a la ruta destí)
            if (File.Exists(@"C:\random\random1.txt") ) 
                File.Move( @"C:\random\random1.txt", @"C:\random\random3.txt");
            else
            {
                Console.WriteLine("No existeix!");
            }
        }
        
        private static void ex16()
        {
            Console.WriteLine();
            //Com l'anterior però fem un copiar a una nova carpeta en canvi de mourel
            if (File.Exists(@"C:\random\random.txt") ) 
                File.Copy( @"C:\random\random.txt", @"C:\random1\random.txt");
            Console.WriteLine("S'ha copiat correctament'");
        }
        
        private static void ex17()
        {
            Console.WriteLine();
            //faig una variable la qual emmagatzema tot el text llegit gràcies a la classe readAllText i ho mostro per pantalla
            string llegir = File.ReadAllText(@"C:\random\random.txt");
            Console.WriteLine(llegir);
        }
    }
}