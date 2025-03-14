using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Miscelaneos
{
	[Table("Tipos", Schema = "Misc")]
	public class Tipo : NamedMetadata
	{
	}
}
