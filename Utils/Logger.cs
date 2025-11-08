using System;

namespace ConsoleApp.Utils
{
    /// <summary>
    /// Utilidad simple para logging en consola
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Registra un mensaje informativo
        /// </summary>
        /// <param name="message">Mensaje a registrar</param>
        public static void Info(string message)
        {
            WriteLog("INFO", message, ConsoleColor.Green);
        }
        
        /// <summary>
        /// Registra un mensaje de advertencia
        /// </summary>
        /// <param name="message">Mensaje a registrar</param>
        public static void Warning(string message)
        {
            WriteLog("WARN", message, ConsoleColor.Yellow);
        }
        
        /// <summary>
        /// Registra un mensaje de error
        /// </summary>
        /// <param name="message">Mensaje a registrar</param>
        public static void Error(string message)
        {
            WriteLog("ERROR", message, ConsoleColor.Red);
        }
        
        /// <summary>
        /// Registra un mensaje de depuración
        /// </summary>
        /// <param name="message">Mensaje a registrar</param>
        public static void Debug(string message)
        {
            WriteLog("DEBUG", message, ConsoleColor.Gray);
        }
        
        /// <summary>
        /// Escribe el mensaje de log formateado en consola
        /// </summary>
        /// <param name="level">Nivel del log</param>
        /// <param name="message">Mensaje</param>
        /// <param name="color">Color para mostrar</param>
        private static void WriteLog(string level, string message, ConsoleColor color)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{timestamp}] ");
            
            Console.ForegroundColor = color;
            Console.Write($"{level,-5} ");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            
            Console.ResetColor();
        }
    }
}