using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Miscelaneos
{
	[Table("SubTipos", Schema = "Misc")]
	public class SubTipo : NamedMetadata
	{
		[ForeignKey(nameof(TipoId))]
		public int TipoId { get; set; }
		public virtual Tipo? Tipo { get; set; }
	}
}
