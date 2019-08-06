using DemoPetShop.Domain.Entity;
using DemoPetShop.Repository.AnimalRepository;
using DemoPetShop.Repository.Repository.Interface;
using DemoPetShop.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPetShop.Services.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository m_AnimalRepository;
        public AnimalService( IAnimalRepository p_AnimalRepository )
        {
            m_AnimalRepository = p_AnimalRepository;

        }

        public void Delete( string id )
        {
            m_AnimalRepository.Delete( id );
        }

        public Animal GetById( string p_Id )
        {
            return m_AnimalRepository.GetById( p_Id );
        }

        public void Insert( Animal animal )
        {
            m_AnimalRepository.Insert( animal );
        }

        public List<Animal> ListAll( )
        {
            return m_AnimalRepository.FindAll( );
        }
    }
}
