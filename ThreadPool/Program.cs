using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Using_Thread_Pool
{
    class Program
    {
        static object MostrarHilo = new object();
        static int EjecutarHilo = 20;
        static void Main(string[] args)
        {

            for (int i = 0; i < EjecutarHilo; i++)
            {
                ThreadPool.QueueUserWorkItem(Display, i);
            }
            Console.WriteLine("Correran los 20 hilos");
            lock (MostrarHilo)
            {
                while (EjecutarHilo > 0) Monitor.Wait(MostrarHilo);
            }
            Console.WriteLine("Todos los hilos corren satisfactoriamente");
            Console.ReadLine();
        }
        public static void Display(Object obj)
        {
            Console.WriteLine("Empieza el hilo:" + obj);
            Thread.Sleep(3000);
            Console.WriteLine("Termina el hilo : " + obj);
            lock (MostrarHilo)
            {
                EjecutarHilo = -EjecutarHilo;
                Monitor.Pulse(MostrarHilo);

            }
        }
    }
}
