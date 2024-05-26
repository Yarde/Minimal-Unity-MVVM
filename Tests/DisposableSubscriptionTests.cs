using System;
using NUnit.Framework;
using Yarde.UnityObservable.Disposables;

namespace Yarde.UnityObservable.Tests
{
    public class DisposableSubscriptionTests
    {
        [Test]
        public void DisposeTest()
        {
            var disposableSubscription = new DisposableSubscription<int>();

            disposableSubscription.Subscribe(Action);

            disposableSubscription.Dispose();
            
            disposableSubscription.Invoke(1);

            return;

            void Action(int i)
            {
                throw new Exception();
            }
        }
        
        [Test]
        public void SingleSubscribeTest()
        {
            var value = 0;
            var disposableSubscription = new DisposableSubscription<int>();

            disposableSubscription.Subscribe(Action);

            disposableSubscription.Invoke(1);
            
            disposableSubscription.Dispose();
            
            disposableSubscription.Invoke(1);

            Assert.AreEqual(1, value);
            return;

            void Action(int i)
            {
                value += i;
            }
        }
        
        [Test]
        public void MultipleSubscribeTest()
        {
            var value = 0;
            var disposableSubscription = new DisposableSubscription<int>();

            disposableSubscription.Subscribe(Action1);
            disposableSubscription.Subscribe(Action2);
            disposableSubscription.Subscribe(Action3);

            disposableSubscription.Invoke(1);
            
            disposableSubscription.Dispose();
            
            disposableSubscription.Invoke(1);

            Assert.AreEqual(3, value);
            return;

            void Action1(int i)
            {
                value += i;
            }
            
            void Action2(int i)
            {
                value += i;
            }
            
            void Action3(int i)
            {
                value += i;
            }
        }
    }
}