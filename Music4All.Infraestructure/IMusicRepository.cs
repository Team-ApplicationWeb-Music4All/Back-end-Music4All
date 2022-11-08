using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public interface IMusicRepository
{
    Task<List<Music>> getAll(string name);

    Task<Music> getMusicById(int id);
    Task<bool> create(Music music);
    Task<bool> Update(int id, Music music);

    Task<bool> Delete(int id);
}