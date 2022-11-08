namespace Music4All.Infraestructure.Models;

public class Music : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description {get; set; }
    
    public int MusicianId { get; set; }
    //info a parte del id
    public Musician Musician { get; set; }
}