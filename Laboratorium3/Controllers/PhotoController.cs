﻿using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using Laboratorium3.Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium3.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService albumService)
        {
            _photoService = albumService;
        }
        public IActionResult Index()
        {
            return View(_photoService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Photo model = new Photo();
            model.Organizations = _photoService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Photo photo)
        {
            Photo model = new Photo();
            model.Organizations = _photoService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            if (ModelState.IsValid) // nie ma jawnego powiązania ale sprawdza czy model istenieje
            {
                _photoService.Add(photo);
                // zapamietaj kontakt

                return RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_photoService.FindById(id));
        }
        [HttpPost]
        public IActionResult Details(Photo model)
        {
            if (ModelState.IsValid)
            {


                return RedirectToAction("Index");
            }
            return View();

        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_photoService.FindById(id));
        }
        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_photoService.FindById(id));
        }
        [HttpPost]
        public IActionResult Delete(Photo photo)
        {
            var albumToDelete = _photoService.FindById(photo.Id);

            if (albumToDelete != null)
            {
                _photoService.Delete(albumToDelete);
                return RedirectToAction("Index");
            }

            return NotFound(); 
        }
    }
}
