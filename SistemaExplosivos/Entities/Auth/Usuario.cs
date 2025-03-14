using Microsoft.AspNetCore.Identity;
using SistemaExplosivos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExplosivos.Entities.Auth
{
	[Table("Usuarios", Schema = "Auth")]
	public class Usuario : IdentityUser
	{
		public required string Cedula { get; set; }
		public required string Nombre { get; set; }
		public required string Apellido { get; set; }
		public InstitucionEnum Institucion { get; set; }
	}
}
