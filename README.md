# mvvm-netstandard

```
Library that support using MVVM pattern in .net framework
```

## Built With
* [.NET Standard 2.0](https://docs.microsoft.com/ko-kr/dotnet/standard/net-standard)

## How to use
download package from [nuget](https://www.nuget.org/packages/mvvm-netstandard)

## Code sample
Inherit **NotifyPropertyChangedViewModel** And use **SetValueWithNotify**.
```csharp
public class SearchViewModel : NotifyPropertyChangedViewModel
{
    private ObservableCollection<Stock> stocks = new ObservableCollection<Stock>();
    public ObservableCollection<Stock> Stocks
    {
        get { return stocks; }
        set
        {
            SetValueWithNotify(ref stocks, value);
        }
    }
}
```

Allocate **RelayCommand** to ICommand type property and
binding it.
```csharp
public ICommand SearchCommand { get; set; }

public SearchViewModel()
{
    SearchCommand = new RelayCommand(CanExecuteSearch, ExecuteSearch);
}
```
```xml
<ui:AppBarButton Label="Search" Command="{Binding SearchCommand}"/>
```

## Authors
DaehyeonKang
