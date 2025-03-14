using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Miscelaneos
{
	[Table("Rangos", Schema = "Misc")]
	public class Rango : NamedMetadata
	{
		public string? NombreArmada { get; set; }
	}
}
