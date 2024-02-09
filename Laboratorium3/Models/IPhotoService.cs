using Data.Entities;

namespace Laboratorium3.Models
{
    public interface IPhotoService
    {
        void Add(Photo photo);
        void Update(Photo photo);
        void Delete(Photo photo);
        Photo? FindById(int id);
        List<Photo> FindAll();
        List<OrganizationEntity> FindAllOrganizations();
    }
}
