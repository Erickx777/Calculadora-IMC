using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Models;
using ConsoleApp.Utils;

namespace ConsoleApp.Services
{
    /// <summary>
    /// Servicio principal que maneja la lógica de negocio de la aplicación
    /// </summary>
    public class AppService
    {
        private readonly List<AppData> _data;
        private int _nextId;
        
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        public AppService()
        {
            _data = new List<AppData>();
            _nextId = 1;
            
            Logger.Info("AppService inicializado correctamente");
        }
        
        /// <summary>
        /// Procesa datos de entrada y devuelve un resultado
        /// </summary>
        /// <param name="input">Datos de entrada</param>
        /// <returns>Resultado procesado</returns>
        public string ProcessData(string input)
        {
            try
            {
                Logger.Info($"Procesando datos: {input}");
                
                // Crear nuevo elemento
                var newItem = new AppData(input, $"Procesado el {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
                {
                    Id = _nextId++
                };
                
                _data.Add(newItem);
                
                Logger.Info($"Elemento creado con ID: {newItem.Id}");
                
                return $"Procesado exitosamente. Total de elementos: {_data.Count}";
            }
            catch (Exception ex)
            {
                Logger.Error($"Error al procesar datos: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Obtiene todos los elementos activos
        /// </summary>
        /// <returns>Lista de elementos activos</returns>
        public List<AppData> GetActiveItems()
        {
            return _data.Where(x => x.IsActive).ToList();
        }
        
        /// <summary>
        /// Busca elementos por nombre
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda</param>
        /// <returns>Lista de elementos encontrados</returns>
        public List<AppData> SearchByName(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<AppData>();
                
            return _data
                .Where(x => x.IsActive && 
                           x.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        /// <summary>
        /// Desactiva un elemento por su ID
        /// </summary>
        /// <param name="id">ID del elemento a desactivar</param>
        /// <returns>True si se desactivó correctamente</returns>
        public bool DeactivateItem(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsActive = false;
                Logger.Info($"Elemento {id} desactivado");
                return true;
            }
            
            Logger.Warning($"No se encontró elemento con ID: {id}");
            return false;
        }
        
        /// <summary>
        /// Obtiene estadísticas de la aplicación
        /// </summary>
        /// <returns>Cadena con estadísticas</returns>
        public string GetStatistics()
        {
            var total = _data.Count;
            var active = _data.Count(x => x.IsActive);
            var inactive = total - active;
            
            return $"Estadísticas - Total: {total}, Activos: {active}, Inactivos: {inactive}";
        }
    }
}