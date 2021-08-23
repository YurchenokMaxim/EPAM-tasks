using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Framework_
{
    public class UserCreator
    {

        private static readonly string firstUserName = UserCreator.GetTestData("testdata.firstUser.name");

        private static readonly string firstUserPassword = UserCreator.GetTestData("testdata.firstUser.password");

        private static readonly string secondUserName = UserCreator.GetTestData("testdata.secondUser.name");

        private static readonly string secondUserPassword = UserCreator.GetTestData("testdata.secondUser.password");

        private static readonly string filePath = "Task9/Files/";

        private static readonly string enviroment = TestContext.Parameters["environment"];

        /// <summary>
        /// Method for getting the value by key from .json file
        /// </summary>
        /// <param name of the value="key"></param>
        /// <returns></returns>
        public static string GetTestData(string key)
        {
            var root = JObject.Parse(File.ReadAllText(filePath + enviroment + ".json"));
            return root.Descendants().
                    OfType<JProperty>().
                    Where(x => x.Name == key).
                    First().Value.ToString();
        }

        public static User GetFirstUser()
        {
            return new User(firstUserName, firstUserPassword);
        }

        public static User GetSecondUser()
        {
            return new User(secondUserName, secondUserPassword);
        }
    }
}