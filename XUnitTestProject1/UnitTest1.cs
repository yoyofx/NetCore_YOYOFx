using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

           var t1= typeof(UserService).GetHashCode();
           var t2=  typeof(MyService1).GetHashCode();
           var t3=  typeof(MyService).GetHashCode();


            var t4 = typeof(UserService).GetHashCode();

            
        }
    }
}
