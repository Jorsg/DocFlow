using MongoDB.Bson;
namespace DocFlow.AuthService.Helpers
{
	public class MongoObjectIdToStringConverter
	{
		public static ObjectId ConvertStringToObjectId(string id)
		{
			try
			{
				ObjectId objectId = ObjectId.Parse(id);
				return objectId;
			}
			catch (FormatException)
			{

				throw new FormatException("The provided id is not a valid 24-digit hex string");
			}
		}

	}
}
