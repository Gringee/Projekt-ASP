using Laboratorium3.Models;
using Data.Entities;

namespace Laboratorium3.Mappers
{
    public class PhotoMapper
    {
        public static Photo FromEntity(PhotoEntity entity)
        {
            return new Photo()
            {
                Id = entity.Id,
                Data = entity.Data,
                Opis = entity.Opis,
                Autor = entity.Autor,
                Aparat = entity.Aparat,
                Resolution = entity.Resolution,
                Format = entity.Format,
                Priority = entity.Priority,
            };
        }

        public static PhotoEntity ToEntity(Photo model)
        {
            return new PhotoEntity()
            {
                Id = model.Id,
                Data = model.Data,
                Opis = model.Opis,
                Autor = model.Autor,
                Aparat = model.Aparat,
                Resolution = model.Resolution,
                Format = model.Format,
                Priority = model.Priority,
            };
        }
    }
}
