public class ViewModel
{
    public NestedChangeTracker<MasterModel> ChangeTracker { get; }

    public ViewModel()
    {
        var originalModel = new MasterModel
        {
            Title = "Master Title",
            Nested = new NestedModel
            {
                Name = "Max",
                Age = 26
            },
            Nested2 = new NestedModel2
            {
                Description = "Initial Description",
                Details = "Initial Details"
            }
        };
        ChangeTracker = new NestedChangeTracker<MasterModel>(originalModel);
    }
}