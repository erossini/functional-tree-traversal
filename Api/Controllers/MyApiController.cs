using DataLayer.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class MyApiController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> Get(int Age, string Name)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/api
        public void Post(int Age, string Name)
        {
            BinaryTree _tree = new BinaryTree();
            TreeDatabase td = new TreeDatabase();

            _tree = td.Load();
            _tree.Add(new Node(new NodeData { Age = Age, Name = Name }));
            td.Save(_tree);

            td = null;
            _tree = null;
        }
    }
}