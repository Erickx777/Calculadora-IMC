using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    /// <summary>
    /// Modelo de datos principal de la aplicación
    /// </summary>
    public class AppData
    {
        /// <summary>
        /// Identificador único
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre del elemento
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Descripción del elemento
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; set; }
        
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Estado activo/inactivo
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public AppData() { }
        
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="name">Nombre del elemento</param>
        /// <param name="description">Descripción del elemento</param>
        public AppData(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }
        
        /// <summary>
        /// Representación en cadena del objeto
        /// </summary>
        /// <returns>Cadena descriptiva del objeto</returns>
        public override string ToString()
        {
            return $"AppData [Id: {Id}, Name: {Name}, Active: {IsActive}, Created: {CreatedDate:yyyy-MM-dd}]";
        }
    }
}