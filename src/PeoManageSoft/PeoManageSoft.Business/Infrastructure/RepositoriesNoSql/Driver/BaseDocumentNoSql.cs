using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PeoManageSoft.Business.Infrastructure.RepositoriesNoSql.Driver
{
    /// <summary>
    /// NoSql document base class.
    /// </summary>
    internal abstract class BaseDocumentNoSql 
    {
        #region Properties

        /// <summary>
        /// Document identifier
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("ID")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Entity identifier
        /// </summary>
        [BsonElement("GuidId")]
        public Guid Id { get; private set; }

        #endregion
    }
}
