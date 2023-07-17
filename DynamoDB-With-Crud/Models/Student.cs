using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB_With_Crud.Models
{

    namespace DynamoStudentManager.Models
    {
        [DynamoDBTable("students")]
        public class Student
        {
            [DynamoDBHashKey("id")]
            public int? Id { get; set; }

            [DynamoDBProperty("firstname")]
            public string? FirstName { get; set; }

            [DynamoDBProperty("lastname")]
            public string? LastName { get; set; }

            [DynamoDBProperty("Degree")]
            public string? Degree { get; set; }

            [DynamoDBProperty("country")]
            public string? Country { get; set; }
            [DynamoDBProperty("city")]
            public string? City { get; set; }

            [DynamoDBProperty("IsMarried")]
            public bool IsMarried { get; set; }
        }
    }
}
