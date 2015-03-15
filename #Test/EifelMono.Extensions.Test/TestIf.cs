using NUnit.Framework;
using System;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestIf
    {
        [Test()]
        public  void TestIf1()
        {
            int i = 1;
            int Ok = -1;

            i.If().Is(1).Is(2).AndPush().IsIn(1,2,3,4).Then((p) =>
                {
                    Ok = 0;
                }).Else((p) =>
                {
                    Ok = -1;
                });
            Assert.IsTrue(Ok == 0);
        }
    }
}

