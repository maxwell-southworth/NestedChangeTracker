using Newtonsoft.Json;
using System.ComponentModel;

public class ChangeTracker<TModel> : INotifyPropertyChanged where TModel : new()
{
    protected readonly Dictionary<string, object> _nestedTrackers = new Dictionary<string, object>();
    public event PropertyChangedEventHandler PropertyChanged;

    public TModel Original { get; }
    public TModel Current { get; private set; }

    public ChangeTracker(TModel model)
    {
        Original = CloneModel(model);
        Current = CloneModel(model);
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected TModel CloneModel(TModel model)
    {
        return JsonConvert.DeserializeObject<TModel>(JsonConvert.SerializeObject(model)) ?? new TModel();
    }

    private bool DeepEquals(TModel obj1, TModel obj2)
    {
        var obj1Json = JsonConvert.SerializeObject(obj1);
        var obj2Json = JsonConvert.SerializeObject(obj2);
        return obj1Json == obj2Json;
    }

    public bool HasChanges => !DeepEquals(Original, Current);

    public virtual void Reset()
    {
        foreach (var tracker in _nestedTrackers.Values.OfType<ChangeTracker<TModel>>())
        {
            tracker.Reset();
        }
        Current = CloneModel(Original);
        OnPropertyChanged(string.Empty);
    }
}