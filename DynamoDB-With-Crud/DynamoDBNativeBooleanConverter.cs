using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDB_With_Crud
{
    public class DynamoDBNativeBooleanConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value) => (bool)value ? "true" : "false";

        public object FromEntry(DynamoDBEntry entry)
        {
            if (entry != null && entry.AsPrimitive()!=null)
            {
                if(!entry.Equals(true) && !entry.Equals(false))
                {
                    if (entry.AsPrimitive().Value.ToString() == "1")
                    {
                        entry.AsPrimitive().Value = "true";
                    }
                    else
                    {
                        entry.AsPrimitive().Value = "false";
                    }
                    var val = bool.Parse(entry.AsPrimitive().Value.ToString());
                    return val;
                }
                else
                {
                    return entry.AsBoolean();
                }

               
            }
            else
            {
                return entry.AsBoolean();
            }
        }
    }
}
