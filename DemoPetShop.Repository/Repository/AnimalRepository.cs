using DemoPetShop.Domain.Entity;
using DemoPetShop.Repository.Repository.Interface;
using MongoDBRepository.Repository.Base;
using MongoDBRepository.Repository.Context;
using System;
using MongoDB.Driver;

namespace DemoPetShop.Repository.AnimalRepository
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository( IConnectionFactory connectionFactory ) : base( connectionFactory, "DemoPetShop", "Animal" )
        {

        }

        public Animal GetById( string p_Id )
        {
            return GetCollection( ).Find( ( a ) => a.Id == p_Id ).First( );
        }
    }
}
