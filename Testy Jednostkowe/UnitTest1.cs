using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Laboratorium3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy_Jednostkowe
{
    [TestClass]
    public class PhotoControllerTest
    {
        [TestMethod]
        public void PhotoTest1()
        {
            var photo = new Photo
            {
                Id = 1,
                Data = DateTime.Now,
                Opis = "Opis Testowy",
                Aparat = "Aparat Testowy",
                Autor = "Autor Testowy",
                Resolution = "1920x1080", 
                Format = "16x9",
                Priority = 1
            };

            var validationContext = new ValidationContext(photo, null, null);
            var validationResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(photo, validationContext, validationResult, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResult.Count); 
        }

        [TestMethod]
        public void PhotoTest2()
        {
            var photo = new Photo
            {
                Id = 1,
                Data = DateTime.Now,
                Opis = "Opis Testowy",
                Aparat = "Aparat Testowy",
                Autor = "Autor Testowy",
                Resolution = "", 
                Format = "16x9",
                Priority = 1
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(photo, new ValidationContext(photo), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count); 
        }

        [TestMethod]
        public void PhotoTest3()
        {
            var photo = new Photo
            {
                Id = 1,
                Data = DateTime.Now,
                Opis = "Opis Testowy",
                Aparat = "Aparat Testowy",
                Autor = "Autor Testowy",
                Resolution = "1920x1080",
                Format = "16x9",
                Priority = 100
            };

            photo.Data = DateTime.MinValue; 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(photo, new ValidationContext(photo), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, validationResults.Count); 
        }
    }
}


