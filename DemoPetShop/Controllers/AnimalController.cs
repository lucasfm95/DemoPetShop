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

        public IActionResult Detail( string id )
        {
            Animal animal = m_AnimalService.GetById( id );

            AnimalModel animalModel = new AnimalModel( )
            {
                Id = animal.Id,
                NickName = animal.NickName,
                Age = animal.Age,
                Species = animal.Species
            };

            ViewBag.Animal = animalModel;
            return View( );
        }

        public IActionResult Insert(  )
        {
            return View( );
        }

        public IActionResult Create( AnimalModel animalModel )
        {
            Animal animal = new Animal( )
            {
                NickName = animalModel.NickName,
                Age = animalModel.Age,
                Species = animalModel.Species
            };

            m_AnimalService.Insert( animal );

            return RedirectToAction( "Index" );
        }

        public IActionResult Delete( string id )
        {
            m_AnimalService.Delete( id );
            return RedirectToAction( "Index" );
        }
    }
}