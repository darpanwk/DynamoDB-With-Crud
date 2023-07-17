using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB_With_Crud.Models
{
    [DynamoDBTable("users")]
    public class Users
    {
        [DynamoDBHashKey("email")]
        public string? Email { get; set; }

        [DynamoDBProperty("city")]
        public string? City { get; set; }

        [DynamoDBProperty("name")]
        public string? Name { get; set; }

        [DynamoDBProperty("address")]
        public string? Address { get; set; }

        [DynamoDBProperty("percentage")]
        public double? Percentage { get; set; }

        [DynamoDBProperty("isconsultant", typeof(DynamoDBNativeBooleanConverter))]
        
        public Boolean IsConsultant { get; set; }
    }
}

