using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPetShop.Domain.Entity;
using DemoPetShop.Models;
using DemoPetShop.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoPetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService m_AnimalService;
        public AnimalController( IAnimalService p_AnimalService )
        {
            m_AnimalService = p_AnimalService;
        }

        public IActionResult Index( )
        {
            List<Animal> animals =  m_AnimalService.ListAll( );

            List<AnimalModel> animalModels = new List<AnimalModel>( );

            foreach ( Animal animal in animals )
            {
                animalModels.Add( new AnimalModel( )
                {
                    Id = animal.Id,
                    NickName = animal.NickName,
                    Age = animal.Age,
                    Species = animal.Species
                });
            }

            ViewBag.Animals = animalModels;

            return View( );
        }

        public IActionResult Detail( )
        {
            return View( );
        }
    }
}