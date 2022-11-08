using System.ComponentModel.DataAnnotations;

namespace Music4All.API.Resources;

public class EventsResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(150)]
    public string Description { get; set; }

    public ContractorResource Contractor { get; set; }
}