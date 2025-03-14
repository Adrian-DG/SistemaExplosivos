using SistemaExplosivos.Entities.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Abstraction
{
	public class AuditableMetadata : IdentifierMetadata
	{
		[ForeignKey("UsuarioId")]
		public required int UsuarioId { get; set; }
		public virtual Usuario? Usuario { get; set; }

		public DateTime FechaCreacion { get; set; }
		public DateTime FechaModificacion { get; set; }
	}
}
