using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Miscelaneos
{
	[Table("Marcas", Schema = "Misc")]
	public class Marca : NamedMetadata
	{
	}
}
