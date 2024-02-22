using System.ComponentModel.DataAnnotations;

namespace Parcial1_AP1_CristopherMarte.Models;

public class Metas
{
    [Key]
    public int MetaId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Today;

    [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Solo se permiten letras")]
    [Required(ErrorMessage = "Descripción obligatorio")]
    public string? Descripcion { get; set; }

    [Range(1, float.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    [Required(ErrorMessage = "Ingrese un Monto")]
    public decimal Monto { get; set; }

}
