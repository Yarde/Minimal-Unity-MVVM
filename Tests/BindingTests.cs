using NUnit.Framework;
using UnityEngine;
using Yarde.MVVM.Bindings;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Tests
{
    public class BindingTests
    {
        [Test]
        public void GameObjectBindTest()
        {
            var value = new ObservableValue<bool>();
            var gameObject = new GameObject();
            
            Assert.AreEqual(true, gameObject.activeSelf);
            
            var disposable = gameObject.Bind(value);
            
            Assert.AreEqual(value.Value, gameObject.activeSelf);
            Assert.AreEqual(false, gameObject.activeSelf);
            
            value.Value = true;
            
            Assert.AreEqual(value.Value, gameObject.activeSelf);
            Assert.AreEqual(true, gameObject.activeSelf);
            
            disposable.Dispose();
        }
        
        [Test]
        public void ImageBindTest()
        {
            var value = new ObservableValue<Color>(Color.blue);
            var gameObject = new GameObject();
            var image = gameObject.AddComponent<UnityEngine.UI.Image>();
            
            Assert.AreEqual(Color.white, image.color);
            
            var disposable = image.Bind(value);
            
            Assert.AreEqual(value.Value, image.color);
            Assert.AreEqual(Color.blue, image.color);
            
            value.Value = Color.red;
            
            Assert.AreEqual(value.Value, image.color);
            Assert.AreEqual(Color.red, image.color);
            
            disposable.Dispose();
        }
    }
}