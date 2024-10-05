public class NestedChangeTracker<TModel> : ChangeTracker<TModel> where TModel : class, new()
{
    public NestedChangeTracker(TModel model) : base(model)
    {
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);
        foreach (var tracker in _nestedTrackers.Values.OfType<ChangeTracker<TModel>>())
        {
            ((NestedChangeTracker<TModel>)tracker).OnPropertyChanged(propertyName);
        }
    }

    public override void Reset()
    {
        foreach (var tracker in _nestedTrackers.Values.OfType<ChangeTracker<TModel>>())
        {
            tracker.Reset();
        }
        base.Reset();
    }
}