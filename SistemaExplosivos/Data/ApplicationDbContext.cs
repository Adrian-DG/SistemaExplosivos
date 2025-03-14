using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaExplosivos.Entities.Auth;
using SistemaExplosivos.Entities.Inventario;
using SistemaExplosivos.Entities.Miscelaneos;
using SistemaExplosivos.Entities.Organizacion;

namespace SistemaExplosivos.Data
{

	public class ApplicationDbContext : IdentityDbContext<Usuario>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			#region Auth
			modelBuilder.Entity<Usuario>().ToTable("Usuarios");

			modelBuilder.Entity<Usuario>().Property(u => u.Cedula).IsRequired();

			#endregion

			#region Miscelaneos
			modelBuilder.Entity<Rango>().HasData(
					new Rango { Id = 1, Nombre = "Mayor General", NombreArmada = "" },
					new Rango { Id = 2, Nombre = "General de Brigada", NombreArmada = "" },
					new Rango { Id = 3, Nombre = "Coronel", NombreArmada = "" },
					new Rango { Id = 4, Nombre = "Teniente Coronel", NombreArmada = "" },
					new Rango { Id = 5, Nombre = "Mayor", NombreArmada = "" },
					new Rango { Id = 6, Nombre = "Capitán", NombreArmada = "" },
					new Rango { Id = 7, Nombre = "Primer Teniente", NombreArmada = "" },
					new Rango { Id = 8, Nombre = "Segundo Teniente", NombreArmada = "" },
					new Rango { Id = 9, Nombre = "Subteniente", NombreArmada = "" },
					new Rango { Id = 10, Nombre = "Sargento Mayor", NombreArmada = "" },
					new Rango { Id = 11, Nombre = "Sargento", NombreArmada = "" },
					new Rango { Id = 12, Nombre = "Cabo", NombreArmada = "" },
					new Rango { Id = 13, Nombre = "Raso", NombreArmada = "" }
				);
			#endregion
		}

		#region Miscelaneos

		public DbSet<Marca> Marcas { get; set; }
		public DbSet<Modelo> Modelos { get; set; }
		public DbSet<Tipo> Tipos { get; set; }
		public DbSet<SubTipo> SubTipos { get; set; }
		public DbSet<Calibre> Calibres { get; set; }
		public DbSet<TipoDocumento> TipoDocumentos { get; set; }
		public DbSet<Rango> Rangos { get; set; }

		#endregion

		#region Inv

		public DbSet<Articulo> Articulos { get; set; }
		public DbSet<Transaccion> Transacciones { get; set; }
		public DbSet<DocumentoTransaccion> DocumentosTransacciones { get; set; }
		public DbSet<DetalleTransaccion> DetallesTransacciones { get; set; }

		#endregion

		#region Org

		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Titular> Titulares { get; set; }

		#endregion

	}
}