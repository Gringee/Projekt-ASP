using System.Security.Cryptography.X509Certificates;

namespace Laboratorium3.Models
{
    public class MemoryPhotoServices : IPhotoService
    {
        private readonly Dictionary<int, Photo> _photo= new Dictionary<int, Photo>()
        {

            {1, new Photo() {Id = 1, Data = new DateTime(2022, 5, 1, 8, 30, 0), Opis = "zdjecie z wakacji", Aparat = "Nikon", Autor="Grzegorz", Resolution = "1080p", Format="16x9"} },
            {2, new Photo() {Id = 2, Data = new DateTime(2023, 2, 10, 8, 50, 0), Opis = "zdjecie szkolne", Aparat = "Samsung", Autor="Paweł", Resolution = "720p", Format="4x3"} },
        };
        private int _id = 3;
        public void Add(Photo photo)
        {
            photo.Id = _id++;
            _photo[photo.Id] = photo;

        }
        public void Delete(Photo photo) 
        { 
            _photo.Remove(photo.Id);
        }

        public List<Photo> FindAll()
        {
            return _photo.Values.OrderBy(album => album.Opis).ToList();
        }

        public Photo? FindById(int id)
        {
            return _photo[id];
        }

        public void Update(Photo album)
        {
            _photo[album.Id] = album;
        }
    }
}

