CREATE  TABLE dbo.Tree
        (
        node_id     INTEGER NOT NULL,
        name        VARCHAR(20) NOT NULL,
        hid         HIERARCHYID NOT NULL,
        parent      AS hid.GetAncestor(1) PERSISTED,
        level       AS hid.GetLevel(),
        path        AS hid.ToString(),
        );

-- Indexes and constraints
CREATE  UNIQUE CLUSTERED INDEX [CUQ dbo.Tree depth_first] ON dbo.Tree (hid);
CREATE  UNIQUE INDEX [UQ dbo.Tree node_id] ON dbo.Tree (node_id);
CREATE  INDEX [IX dbo.Tree parent] ON dbo.Tree (parent);
ALTER   TABLE dbo.Tree ADD FOREIGN KEY (parent) REFERENCES dbo.Tree (hid);

-- Nodes
INSERT  dbo.Tree(node_id, name, hid) VALUES (1, 'Node 1', hierarchyid::GetRoot());
INSERT  dbo.Tree(node_id, name, hid) VALUES (2, 'Node 2', hierarchyid::Parse(N'/1/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (3, 'Node 3', hierarchyid::Parse(N'/2/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (4, 'Node 4', hierarchyid::Parse(N'/1/1/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (5, 'Node 5', hierarchyid::Parse(N'/1/2/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (6, 'Node 6', hierarchyid::Parse(N'/2/1/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (7, 'Node 7', hierarchyid::Parse(N'/2/2/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (8, 'Node 8', hierarchyid::Parse(N'/1/1/1/'));
INSERT  dbo.Tree(node_id, name, hid) VALUES (9, 'Node 9', hierarchyid::Parse(N'/1/1/2/'));