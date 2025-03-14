using SistemaExplosivos.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Organizacion
{
	[Table("Empresas", Schema = "org")]
	public class Empresa : AuditableMetadata
	{
		public required string Nombre { get; set; }
		public required string RNC { get; set; }
		
		[StringLength(10)]
		[DataType(DataType.PhoneNumber)]
		public required string Telefono { get; set; }

		[ForeignKey("TitularId")]
		public required int TitularId { get; set; }
		public virtual Titular? Titular { get; set; }
	}
}
