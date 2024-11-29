using System.ComponentModel.DataAnnotations;

namespace EraTech.CurrencyManagement.Dtos;

public class UpdateCurrencySettingsDto
{
    [Required]
    public required string Currency { get; set; }


}
