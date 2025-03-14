using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Inventario
{
	[Table("DetalleTransacciones", Schema = "Inv")]
	public class DetalleTransaccion : AuditableMetadata
	{
		[ForeignKey(nameof(ArticuloId))]
		public int ArticuloId { get; set; }
		public virtual Articulo? Articulo { get; set; }

		[DefaultValue(1)]
		public int Cantidad { get; set; }

		[ForeignKey(nameof(TransaccionId))]
		public int TransaccionId { get; set; }
		public virtual Transaccion? Transaccion { get; set; }
	}
}
