using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp.Config
{
    /// <summary>
    /// Configuración de la aplicación
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Nombre de la aplicación
        /// </summary>
        public string ApplicationName { get; set; } = "ConsoleApp";
        
        /// <summary>
        /// Versión de la aplicación
        /// </summary>
        public string Version { get; set; } = "1.0.0";
        
        /// <summary>
        /// Nivel de logging
        /// </summary>
        public string LogLevel { get; set; } = "Info";
        
        /// <summary>
        /// Directorio de datos
        /// </summary>
        public string DataDirectory { get; set; } = "./Data";
        
        /// <summary>
        /// Timeout en segundos para operaciones
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;
        
        /// <summary>
        /// Configuración de desarrollo
        /// </summary>
        public bool IsDevelopment { get; set; } = true;
        
        /// <summary>
        /// Instancia singleton de configuración
        /// </summary>
        private static AppSettings? _instance;
        
        /// <summary>
        /// Obtiene la instancia actual de configuración
        /// </summary>
        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = LoadFromFile() ?? new AppSettings();
                }
                return _instance;
            }
        }
        
        /// <summary>
        /// Carga la configuración desde archivo JSON
        /// </summary>
        /// <returns>Instancia de AppSettings o null si no existe el archivo</returns>
        private static AppSettings? LoadFromFile()
        {
            try
            {
                var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                
                if (File.Exists(configPath))
                {
                    var json = File.ReadAllText(configPath);
                    return JsonSerializer.Deserialize<AppSettings>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cargando configuración: {ex.Message}");
            }
            
            return null;
        }
        
        /// <summary>
        /// Guarda la configuración actual en archivo JSON
        /// </summary>
        public void SaveToFile()
        {
            try
            {
                var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                
                File.WriteAllText(configPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error guardando configuración: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Valida que la configuración sea correcta
        /// </summary>
        /// <returns>True si la configuración es válida</returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ApplicationName) &&
                   !string.IsNullOrWhiteSpace(Version) &&
                   TimeoutSeconds > 0;
        }
    }
}