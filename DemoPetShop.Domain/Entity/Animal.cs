using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DemoPetShop.Domain.Entity
{
    public class Animal
    {
        [BsonRepresentation( BsonType.ObjectId )]
        public string Id { get; set; }
        public string NickName { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
    }
}
