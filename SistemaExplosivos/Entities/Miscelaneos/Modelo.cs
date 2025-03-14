using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Miscelaneos
{
	[Table("Modelo", Schema = "Misc")]
	public class Modelo : NamedMetadata
	{
		[ForeignKey(nameof(MarcaId))]
		public int MarcaId { get; set; }
		public virtual Marca? Marca { get; set; }
	}
}
