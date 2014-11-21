using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer.BinaryTree
{
    public class TreeDatabase
    {
        SqlConnection oConn;

        public void OpenConnection()
        {
            if ((oConn == null) || (oConn.State != ConnectionState.Open))
            {
                SqlConnectionStringBuilder osb = new SqlConnectionStringBuilder();
                osb.DataSource = "localhost";
                osb.InitialCatalog = "Tree";
                osb.IntegratedSecurity = false;
                osb.UserID = "sa";
                osb.Password = "enrico!1975";

                oConn = new SqlConnection(osb.ConnectionString);
                oConn.Open();
            }
        }

        public void CloseConnection()
        {
            oConn.Close();
        }

        public void DeleteNode(int node)
        {
            string CommandText2 = "DELETE FROM Tree WHERE node_id = " + node;
            SqlCommand oCmd2 = new SqlCommand(CommandText2);
            oCmd2.Connection = oConn;
            oCmd2.ExecuteNonQuery();
        }

        public void DeleteAll()
        {
            OpenConnection();
            string CommandText = "SELECT node_id FROM Tree ORDER BY node_id desc";
            SqlCommand oCmd = new SqlCommand(CommandText);
            oCmd.Connection = oConn;

            // Execute the query
            SqlDataReader rdr = oCmd.ExecuteReader();

            // Fill the list box with the values retrieved
            while (rdr.Read())
            {
                DeleteNode(Convert.ToInt16(rdr["node_id"]));
            }

            CloseConnection();
        }

        public bool ExistsId(Node node)
        {
            bool rtn = false;

            if (node.Value.NodeId != 0)
            {
                string CommandText = string.Format("SELECT Count(*) FROM Tree WHERE node_id = {0}",
                                                   node.Value.NodeId);
                SqlCommand oCmd = new SqlCommand(CommandText);
                oCmd.Connection = oConn;

                // Execute the query
                int rdr = (Int32)oCmd.ExecuteScalar();
                if (rdr > 0)
                    rtn = true;
            }

            return rtn;
        }

        public BinaryTree Load()
        {
            BinaryTree _tree = new BinaryTree();

            OpenConnection();

            string CommandText = "SELECT node_id, age, name, hid, parent, [level], path FROM Tree";
            SqlCommand oCmd = new SqlCommand(CommandText);
            oCmd.Connection = oConn;

            // Execute the query
            SqlDataReader rdr = oCmd.ExecuteReader();

            // Fill the list box with the values retrieved
            while (rdr.Read())
            {
                _tree.Add(new Node(new NodeData
                {
                    Age = Convert.ToInt16(rdr["Age"]),
                    Name = rdr["Name"].ToString(),
                    NodeId = Convert.ToInt16(rdr["node_id"])
                }));                
            }

            CloseConnection();

            return _tree;
        }

        public bool Save(BinaryTree tree)
        {
            bool rtn = false;

            OpenConnection();

            Postorder(tree.RootNode, "/");
            CloseConnection();

            return rtn;
        }

        public void SaveNode(Node node, string pth)
        {
            if (!ExistsId(node))
            {
                SqlCommand oCmd = new SqlCommand("AddNode", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;

                node.NodePath = pth;
                oCmd.Parameters.Add("@Age", SqlDbType.Int).Value = node.Value.Age;
                oCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = node.Value.Name;
                oCmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = pth;
                oCmd.Parameters.Add("@node_id", SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader dr = oCmd.ExecuteReader();
                node.Value.NodeId = Convert.ToInt32(oCmd.Parameters["@node_id"].Value);
                dr.Close();
            }
        }

        public void Postorder(Node node, string pth)
        {
            if (node != null)
            {
                SaveNode(node, pth);

                if (node.Left != null)
                    Postorder(node.Left, pth + "1/");
                if (node.Right != null)
                    Postorder(node.Right, pth + "2/");
            }
        }
    }
}
