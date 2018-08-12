using System.Security;
using Xunit;
using martyhope.com;
namespace UnitTests
{
    public class SecureStringTests
    {
        [Fact]
        public void TestSecureStringHelper()
        {
            string testString = "This is a test string to see if the helper class can reveal the value.";
            var array = testString.ToCharArray();
            using (SecureString ss = new SecureString())
            {
                foreach (var c in array)
                {
                    ss.AppendChar(c);
                }

                var revealedValue = ss.SecureStringToString();

                Assert.Equal(testString, revealedValue);
            }


        }
    }
}
