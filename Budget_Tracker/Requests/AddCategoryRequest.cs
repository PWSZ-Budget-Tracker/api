using Budget_Tracker.Enums;
namespace Budget_Tracker.Requests
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
