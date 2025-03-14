using SistemaExplosivos.Entities.Abstraction;
using SistemaExplosivos.Entities.Miscelaneos;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Inventario
{
	[Table("Articulos", Schema = "Inv")]
	public class Articulo : AuditableMetadata
	{

		[ForeignKey(nameof(TipoId))]
		public int TipoId { get; set; }
		public virtual Tipo? Tipo { get; set; }

		[ForeignKey(nameof(SubTipoId))]
		public int SubTipoId { get; set; }
		public virtual SubTipo? SubTipo { get; set; }

		[ForeignKey(nameof(CalibreId))]
		public int CalibreId { get; set; }
		public virtual Calibre? Calibre { get; set; }

		[ForeignKey(nameof(MarcaId))]
		public int MarcaId { get; set; }
		public virtual Marca? Marca { get; set; }

		[ForeignKey(nameof(ModeloId))]
		public int ModeloId { get; set; }
		public virtual Modelo? Modelo { get; set; }
	}
}
