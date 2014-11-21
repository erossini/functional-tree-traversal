DECLARE @root   HIERARCHYID,
        @left   HIERARCHYID,
        @right  HIERARCHYID;
        
SELECT  @root = hid FROM dbo.Tree WHERE node_id = 1;

SELECT  @left = (SELECT MIN(hid) FROM dbo.Tree WHERE hid.GetAncestor(1) = @root),
        @right = (SELECT MAX(hid) FROM dbo.Tree WHERE hid.GetAncestor(1) = @root);

SELECT  left_count =
            ( 
            SELECT  COUNT_BIG(*)
            FROM    dbo.Tree T 
            WHERE   T.hid.IsDescendantOf(@left) = 1
            ),
        right_count =
            ( 
            SELECT  COUNT_BIG(*)
            FROM    dbo.Tree T 
            WHERE   T.hid.IsDescendantOf(@right) = 1
            );
GO