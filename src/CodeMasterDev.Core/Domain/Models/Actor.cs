using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CodeMasterDev.Core.Domain.Models;

public class Actor
{
    public int Id { get; set; }
    [ValidateNever]
    public string? Name { get; set; }
    [ValidateNever]
    public DateTime? Birthdate { get; set; }
    [ValidateNever]
    public string? Nationality { get; set; }
}
