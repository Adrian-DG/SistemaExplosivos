using SistemaExplosivos.Entities.Abstraction;
using SistemaExplosivos.Entities.Organizacion;
using SistemaExplosivos.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Inventario
{
	[Table("Transacciones", Schema = "Inv")]
	public class Transaccion : AuditableMetadata
	{
		public TipoTransaccionEnum TipoTransaccion { get; set; }

		[ForeignKey(nameof(EmpresaId))]
		public int EmpresaId { get; set; }
		public virtual Empresa? Empresa { get; set; }
	}
}
