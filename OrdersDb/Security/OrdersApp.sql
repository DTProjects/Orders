CREATE ROLE [OrdersApp] AUTHORIZATION [dbo];
GO;

GRANT SELECT ON SCHEMA :: [dbo] TO OrdersApp;
GO;

GRANT INSERT ON SCHEMA :: [dbo] TO OrdersApp;
GO;

GRANT UPDATE ON SCHEMA :: [dbo] TO OrdersApp;
GO;

GRANT DELETE ON SCHEMA :: [dbo] TO OrdersApp;
GO;

GRANT EXECUTE ON SCHEMA :: [dbo] TO OrdersApp;
GO;



