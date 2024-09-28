# Minimal Unity MVVM
Simple implementation of the MVVM architecture for Unity. 
The package is designed to be lightweight and easy to use and adapt to the project needs.

# Installation
There are two ways to install the package:
## Unity Package Manager
Add the following line to your `manifest.json` file located in the `Packages` folder of your project:
```json
"com.yarde-games.minimal-mvvm": "https://github.com/Yarde/Minimal-Unity-MVVM.git"
```
or open the Unity Package Manager and select `Add package from git URL...` and paste the URL:
```
https://github.com/Yarde/Minimal-Unity-MVVM.git
```
## Manual
1. Download the repository.
2. Extract and copy the content into your Unity project.
## Importing
After installing the package, to use the namespace in your scripts you have to 
add a reference to the `Yarde.MVVM` assembly inside *.asmdef file or change 
the assembly to be auto-referenced.

# Usage
To use the MVVM architecture, you need to create three classes: **Model**, **View**, and **ViewModel**.
## Model
Create a new class that inherits from `Model`.
```csharp
public class MyModel : Model
{
    // Add observable properties. Example:
    public ObservableValue<int> Score { get; }
    
    public MyModel(int score)
    {
        // Initialize the observable properties. Example:
        Score = new ObservableValue<int>(this, score);
    }
}
```

## View
Create a new class that inherits from `View` and implement the abstract method `SetupBindings()`. This method is called when the View is created.
```csharp
public class MyView : View
{
    // Add serialized fields for UI elements. Example:
    [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }

    public override void Dispose()
    {
        // Clean up the view. Example:
        Destroy(gameObject);
    }
}
```

## ViewModel
Create a new class that inherits from `ViewModel` and implement the abstract method `SetupBindings()`. This method is called when the ViewModel is created.
```csharp
public class MyViewModel : ViewModel<MyView, MyModel>
{
    protected override void SetupBindings(MyModel data)
    {
        // Bind the model to the view. Example:
        View.ScoreText.Bind(data.Score).AddTo(Disposables);
    }
}
```

# Binding

## Using Bindings
To use a binding, use the `Bind` extension method from the view field type. Next, use the `AddTo` method to add the binding to the `CompositeDisposable` of the ViewModel.
Here is an example of binding the `ObservableValue<int> Score` to the `TMP_Pro ScoreText` property of the View.
```csharp
View.ScoreText.Bind(data.Score).AddTo(Disposables);
```
## Creating new Bindings
If you want to create a new binding, you need to create a new type extension method. 

```csharp
public static class MyTypeBindings
    {
        public static IDisposable Bind(this MyType type, IObservableValue<bool> observable)
        {
            return observable.InvokeAndSubscribe(type.Activate);
        }
    }
```

# Feedback
If you have any feedback or suggestions, feel free to create an issue or contact me at 
[yardegames@gmail.com](mailto:yardegames@gmail.com).