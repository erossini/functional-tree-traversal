functional-tree-traversal
=========================

This soluton implements a method with WebAPI 2.2 to receive a POST request with the following properties:
- Age (int)
- Name (string)

Save these in a database as a binary tree, keyed by age, and expose an HTTP endpoint to query the tree by a persons name and age. The query should run a tree traversal algorithm to find the correct node in the tree. The code to query the tree should be written in a functional manner.

The solution has:
- Api: this is the implementation of the methods POST and GET
- Api.Test: it is the test for POST method
- DataLayer.BinaryTree: it is implemented functions and logical to manage the binary tree and save on database it (for SQL Server there are the scripts)
- TestForm: it is the form to show the tree graph in WinForms
- functional-tree-traversal: it is the WPF form that shows the binary tree with my draw functions (you can view in the Wiki an examples) and check every second if in the database there are new changes.
