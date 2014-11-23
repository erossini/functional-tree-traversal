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
        public IHttpActionResult Get(int Age, string Name)
        {
            int rtn = 0;
            BinaryTree _tree = new BinaryTree();
            TreeDatabase td = new TreeDatabase();

            _tree = td.Load();
            rtn = _tree.Contains(new NodeData { Age = Age, Name = Name });

            td = null;
            _tree = null;

            if (rtn == -1)
            {
                return NotFound();
            }

            return Ok(rtn);
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