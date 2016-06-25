using NUnit.Framework;

namespace EifelMono.Extensions.Test
{
    [TestFixture()]
    public class TestIf
    {
        [Test()]
        public  void TestIf1()
        {
            int i = 1;
            int result = -1;

            i.If().Is(1).Is(2).AndPush().IsIn(2, 3, 4).Then((p) =>
                {
                    result = 0;
                }).Else((p) =>
                {
                    result = 1;
                });
            Assert.IsTrue(result == 1);

            i = 2;
            result = -1;
            i.If().Is(1).Is(2).AndPush().IsIn(1, 2, 3, 4).Then((p) =>
                {
                    result = 0;
                }).Else((p) =>
                {
                    result = 1;
                });
            Assert.IsTrue(result == 0);

            i = 3;
            result = -1;
            i.If().Is(1).Is(2).AndPush().IsIn(1, 2, 3, 4).Then((p) =>
                {
                    result = 0;
                }).Else((p) =>
                {
                    result = 1;
                });
            Assert.IsTrue(result == 1);
        }
    }
}

