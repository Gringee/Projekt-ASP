using Data;
using Data.Entities;
using Laboratorium3.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium3.Models
{
    public class PhotoService : IPhotoService
    {
        private AppDbContext _context;

        public PhotoService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Photo album)
        {
            var e = _context.Photos.Add(PhotoMapper.ToEntity(album));
            _context.SaveChanges();
        }

        public void Delete(Photo photo)
        {
            PhotoEntity? find = _context.Photos.Find(photo.Id);
            if (find != null)
            {
                _context.Photos.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Photo> FindAll()
        {
            return _context.Photos.Select(e => PhotoMapper.FromEntity(e)).ToList();
        }

        public Photo? FindById(int id)
        {
            return PhotoMapper.FromEntity(_context.Photos.Find(id));
        }

        public void Update(Photo photo)
        {
            _context.Photos.Update(PhotoMapper.ToEntity(photo));
            _context.SaveChanges();
        }
    }
}
