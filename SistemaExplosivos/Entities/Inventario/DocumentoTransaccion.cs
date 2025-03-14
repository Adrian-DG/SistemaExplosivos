using SistemaExplosivos.Entities.Abstraction;
using SistemaExplosivos.Entities.Miscelaneos;
using SistemaExplosivos.Entities.Organizacion;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Inventario
{
	[Table("DocumentosTransacciones", Schema = "Inv")]
	public class DocumentoTransaccion : AuditableMetadata
	{
		
		[ForeignKey(nameof(TipoDocumentoId))]
		public int TipoDocumentoId { get; set; }
		public virtual TipoDocumento? TipoDocumento { get; set; }
		public byte[]? Archivo { get; set; }
		public DateOnly FechaEmision { get; set; }
		public DateOnly FechaDuracion { get; set; }
		public DateOnly? FechaVencimiento { get; set; }

		[ForeignKey(nameof(TransaccionId))]
		public int TransaccionId { get; set; }
		public virtual Transaccion? Transaccion { get; set; }

		[ForeignKey(nameof(EmpresaId))]
		public int EmpresaId { get; set; }
		public virtual Empresa? Empresa { get; set; }

	}
}
