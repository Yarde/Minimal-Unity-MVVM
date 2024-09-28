using NUnit.Framework;
using Yarde.MVVM.Disposables;
using Yarde.MVVM.Observables;

namespace Yarde.MVVM.Tests
{
    public class ObservableModelTests
    {
        public class MockModel : MVVM.Model.Model
        {
        }

        [Test]
        public void ObservableModelSubscribeTest()
        {
            var model = new MockModel();
            var observable = new ObservableValue<int>(model);
            
            var count = 0;
            
            var disposable = model.Subscribe(() => count++); // Should not trigger an event
            
            Assert.AreEqual(0, count);
            
            observable.Value = 1;
            
            Assert.AreEqual(1, count);
            
            disposable.Dispose();
        }

        [Test]
        public void ObservableModelInvokeAndSubscribeTest()
        {
            var model = new MockModel();
            var observable = new ObservableValue<int>(model);
            
            var count = 0;
            
            var disposable = model.InvokeAndSubscribe(() => count++); // Should trigger the event
            
            Assert.AreEqual(1, count);
            
            observable.Value = 1;
            
            Assert.AreEqual(2, count);
            
            disposable.Dispose();
        }

        [Test]
        public void ObservableModelReassignValueTest()
        {
            var model = new MockModel();
            var observable = new ObservableValue<int>(model);
            
            var count = 0;
            var disposable = model.Subscribe(() => count++);
            
            observable.Value = 1;
            observable.Value = 1; // Should NOT trigger another event
            observable.Value = 2;
            observable.Value = 1;
            observable.Value = 1; // Should NOT trigger another event
            
            Assert.AreEqual(3, count);
            
            disposable.Dispose();
        }

        [Test]
        public void ObservableModelNestingTest()
        {
            var modelL1 = new MockModel();
            var modelL2 = new MockModel();
            var modelL3 = new MockModel();
            
            var disposables = new DisposableList();
            
            modelL1.Add(modelL2);
            modelL2.Add(modelL3);
            var observable = new ObservableValue<int>(modelL3);
            
            var count = 0;
            modelL1.Subscribe(() => count++).AddTo(disposables);
            modelL2.Subscribe(() => count++).AddTo(disposables);
            modelL3.Subscribe(() => count++).AddTo(disposables);
            observable.Subscribe(() => count++).AddTo(disposables);
            
            observable.Value = 1;
            
            Assert.AreEqual(4, count);
            
            observable.Value = 2;
            
            Assert.AreEqual(8, count);
            
            disposables.Dispose();
        }
    }
}