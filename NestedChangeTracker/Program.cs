var viewModel = new ViewModel();       
Console.WriteLine("Has changes: " + viewModel.ChangeTracker.HasChanges); // Should be false

viewModel.ChangeTracker.Current.Title = "New Title";
Console.WriteLine("Has changes after Title change: " + viewModel.ChangeTracker.HasChanges); // Should be true

viewModel.ChangeTracker.Reset();
Console.WriteLine("ChangeTracker has been reset back to 'Master Model'. True? " + viewModel.ChangeTracker.Current.Title); // Should be "Master Title"

if (viewModel.ChangeTracker.Current.Nested != null)
{
    viewModel.ChangeTracker.Current.Nested.Name = "New Name";
}
Console.WriteLine("Has changes after Nested Name change: " + viewModel.ChangeTracker.HasChanges); // Should be true

if (viewModel.ChangeTracker.Current.Nested2 != null)
{
    viewModel.ChangeTracker.Current.Nested2.Description = "Updated Description";
}
Console.WriteLine("Has changes after NestedModel2 Description change: " + viewModel.ChangeTracker.HasChanges); // Should be true

viewModel.ChangeTracker.Reset();
Console.WriteLine("Has changes after Reset: " + viewModel.ChangeTracker.HasChanges); // Should be false