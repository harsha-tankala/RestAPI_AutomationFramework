using NUnit.Framework;
using RestAPI_Automation_BusinessLogic.Utils;
using System;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace API_AutomationTest
{
    [Binding]
    public class PostsStepDefinitions
    {


        [Given(@"I create a new post using id '([^']*)' name '([^']*)' role '([^']*)' and email '([^']*)'")]
        public void GivenICreateANewPostUsingIdNameRoleAndEmail(string id, string name, string role, string email)
        {
            var response = PostUtil.CreatePost(id, name, role, email);
            Console.WriteLine("ID : " + response.id + "\nName: " + response.name + "\nRole: " + response.role +"\nEmail: " + response.email);
            Assert.AreEqual(id, response.id);
            Assert.AreEqual(name, response.name);
            Assert.AreEqual(role, response.role);
            Assert.AreEqual(email, response.email);
        }

        [Given(@"I should be able get the record using id '([^']*)'")]
        public void GivenIShouldBeAbleGetTheRecordUsingId(string id)
        {
            var response = PostUtil.GetPost(id);
            Console.WriteLine("ID : " + response.id + "\nName: " + response.name + "\nRole: " + response.role + "\nEmail: " + response.email);
        }


        [Given(@"I should be able delete the record with id '([^']*)'")]
        public void GivenIShouldBeAbleDeleteTheRecordWithId(string id)
        {
            Assert.IsTrue(PostUtil.DeletePost(id));
        }

        [Given(@"I update an existing emailID '([^']*)' for a post using id '([^']*)' name '([^']*)' role '([^']*)'")]
        public void GivenIUpdateAnExistingEmailIDForAPostUsingIdNameRole(string email, string id, string name, string role)
        {
            var response = PostUtil.UpdatePost(id, name, role, email);
            Assert.AreEqual(email, response.email);
            Assert.AreEqual(name, response.name);
        }

    }
}
