var viewModel = new ViewModel();       
// Initially, no changes
Console.WriteLine("Has changes: " + viewModel.ChangeTracker.HasChanges); // Should be false

// Change a property
viewModel.ChangeTracker.Current.Title = "New Title";
Console.WriteLine("Has changes after Title change: " + viewModel.ChangeTracker.HasChanges); // Should be true

viewModel.ChangeTracker.Reset();
Console.WriteLine(viewModel.ChangeTracker.Current.Title); // Should be "Master Title"

// Change a nested property
if (viewModel.ChangeTracker.Current.Nested != null)
{
    viewModel.ChangeTracker.Current.Nested.Name = "New Name";
}
Console.WriteLine("Has changes after Nested Name change: " + viewModel.ChangeTracker.HasChanges); // Should be true

// Change a property in NestedModel2
if (viewModel.ChangeTracker.Current.Nested2 != null)
{
    viewModel.ChangeTracker.Current.Nested2.Description = "Updated Description";
}
Console.WriteLine("Has changes after NestedModel2 Description change: " + viewModel.ChangeTracker.HasChanges); // Should be true

// Reset changes
viewModel.ChangeTracker.Reset();
Console.WriteLine("Has changes after Reset: " + viewModel.ChangeTracker.HasChanges); // Should be false