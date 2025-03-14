using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Organizacion
{
	[Table("Titulares", Schema = "org")]
	public class Titular : IdentifierMetadata
	{
		[StringLength(11)]
		public required string Cedula { get; set; }
		public required string Nombre { get; set; }
		public required string Apellido { get; set; }		
		public string? Telefono { get; set; }

	}
}
