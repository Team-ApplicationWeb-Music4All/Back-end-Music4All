using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IMusicDomain
{

    Task<List<Music>> getAll(string name);
    Task<Music> getMusicById(int id);
    Task<bool> createMusic(Music music);
    Task<bool> updateMusic(int id, Music music);
    Task<bool> deleteMusic(int id);
}