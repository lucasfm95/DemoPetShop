using DemoPetShop.Domain.Entity;
using DemoPetShop.Repository.Repository.Interface;
using MongoDBRepository.Repository.Base;
using MongoDBRepository.Repository.Context;
using System;

namespace DemoPetShop.Repository.AnimalRepository
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository( IConnectionFactory connectionFactory ) : base( connectionFactory, "DemoPetShop", "Animal" )
        {
            
        }
    }
}
