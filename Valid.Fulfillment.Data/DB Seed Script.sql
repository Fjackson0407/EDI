USE [EdiDev]
GO

INSERT INTO [dbo].[DCInformations]
           ([Id]
           ,[Addreess]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[BillAndShipToCodes]
           ,[StoreID])
     VALUES
('5247E965-78EE-4110-9B84-00307702DA0C','7101 West Van Buren ','Phoenix','AZ','85043','ST','588')
,('3839A57E-1C4E-4CFD-ACC5-032105DAA1F1','166 Corporate Drive','Lugoff','SC','29078','ST','594')
,('643F43D7-28D5-469D-9755-0BBB050F49F5','1115 Macom Drive','De Kalb','IL','60115','ST','3809')
,('E017E8A0-A19F-40B4-A024-23E1F85FA815','300 Manning Bridge Road','Suffolk','VA','23435','ST','3841')
,('446DC8FF-CC79-46D0-8F41-38FB18647D1C','3325 Archer Drive','Chambersburg','PA','17202','ST','589')
,('2D4FE99E-E619-480C-9B34-3D567FCF7ADF','14750 Miller Ave','Fontana','CA','92336','ST','553')
,('55CE2C38-C57C-4365-9813-3FA21EC42A98','3 Walker Way West','Jefferson','OH','43162','ST','3804')
,('A06CEDAA-FB8B-4CDB-BF33-416EABE1FB0D','131 North Road','Wilton','NY','12831','ST','579')
,('16AB09C8-B764-42AF-B8D6-432B8D9F5949','4055 Railport Pkwy','Midlothian','TX','76065','ST','3801')
,('75E0CC4A-FD23-49C0-9357-592BAAD77520','6601 Hudson Road','Cedar Falls','IA','50613','ST','590')
,('2EA5681C-0755-465B-9904-592EB6E5F451','1100 Valley Road','Oconomowoc','WI','53066','ST','557')
,('B109EECB-E55B-4D3B-83B8-5D9B1EFD4754','2702 Summit Avenue','Rialto','CA','92377','ST','3806')
,('DFF83BB5-FABD-408F-9D89-65CE39B6EA00','2704 Summit Ave','Rialto','CA','92376','ST','3840')
,('24E62DBA-1DAC-460C-A1EF-681B0828F0FF','3700 Zachary Ave','Shafter','CA','93263','ST','593')
,('F72E6FFD-3D3F-4DFE-A214-7BBE4C5471E6','1340 South Girls School Road','Indianapolis','IN','46231','ST','559')
,('F5D6C023-F48C-4283-BB28-7FD3C32AECBF','423 Mt. Vernon Road','Stuarts Draft','VA','24477','ST','560')
,('1688B161-BA2C-4B5B-A3B3-809F0078DF32','34800 United Ave','Pueblo','CO','81001','ST','554')
,('90812CC9-F417-4C12-8A3C-84AA4C318D0F','7120 HWY 65 N. E.','Fridley','MN','55432','ST','551')
,('4652BE6F-9C73-4DD7-B050-93F705CF9D74','5400 Wenger Street','Topeka','KS','66609','ST','3803')
,('AB62E045-D705-46A4-B2F9-A2A4605ED983','875 Beta Drive Sw','Albany','OR','97321','ST','558')
,('AD1666F4-DEEB-40FD-B2B8-B3FACD5B0C48','3500 Marin Rd NE','Lacey','WA','98516','ST','600')
,('88DD6A90-FBC1-436D-9D7F-B4D02D97751D','895 Sunbury Road','Midway','GA','31320','ST','3808')
,('001535F3-1C64-4640-BBE3-CA52E99DCBC2','1800 State Hwy 5 S','Amsterdam','NY','12010','ST','3802')
,('EAEB7136-1973-48AC-A3B6-DE2A499F7EB2','12905 East L Avenue','Galesburg','MI','49053','ST','587')
,('DE948418-0B35-4668-9849-E2C476969D83','1900 Stover Ct. ','Newton','NC','28658','ST','3811')
,('21398099-A0E0-4512-B33C-EEBD86B3AC28','6305 Greenbrier Road','Madison ','AL','35756','ST','580')
,('A2298C96-16CA-4955-B353-EF790A42AD8E','110 West Jordan Road','Tifton','GA','31793','ST','556')
,('F2F05A12-E3CA-4266-89C4-F3A566AC2CED','13786 Harvey Road','Tyler','TX','75706','ST','578')
,('BF281A32-856D-4CB0-BD3D-FD471D86826D','2050 East Beamer St','Woodland','CA','95776','ST','555')
GO

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[SkuItems]
           ([Id]
           ,[DPCI]
           ,[Brand]
           ,[Product]
           ,[SubProduct]
           ,[DENOM]
           ,[BIN]
           ,[GCCardType]
           ,[GCProdId]
           ,[DCMSID]
           ,[EmbossedLine]
           ,[DEPT]
           ,[Class]
           ,[Item]
           ,[ProductUPC]
           ,[PackageUPC])
     VALUES
           ('C6C14F95-219F-4D69-A92C-5C88EED692B6'
           ,'5247E965-78EE-4110-9B84-00307702DA0C'
           ,'Brand'
           ,'Product'
           ,'Subproduct'
           ,'Denom'
           ,'Bin'
           ,'CardType'
           ,'GCProductID'
           ,'DCMSID'
           ,'EmbossedLine'
           ,'DEPT'
           ,'Class'
           ,'Item'
           ,'ProductUPC'
           ,'PackageUPC')
GO

Select * from [dbo].[SkuItems]

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[ShipFromInformations]
           ([Id]
           ,[Address]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[DUNSOrLocationNumber]
           ,[BillAndShipToCodes])
     VALUES
           ('0D0FC664-0B90-4387-8F2C-23DB058EA886'
           ,'1863 183rd. Ave NE'
           ,'East Bethel'
           ,'MN'
           ,'55011'
           ,'1'
           ,'2')
GO

select * from [dbo].[ShipFromInformations]

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[OperatorObjs]
           ([Id]
           ,[UserName]
           ,[Password]
           ,[DTS]
           ,[Role])
     VALUES
           ('30D8E85A-53EE-4B9E-AE9E-0029379A6451'
           ,'joelanc'
           ,'testpw'
           ,GETDATE()
           ,0)
GO

select * from [dbo].[OperatorObjs]

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[ContactTypes]
           ([Id]
           ,[LastName]
           ,[FirstName]
           ,[EmailAddress]
           ,[PhoneNumber])
     VALUES
           ('C0059757-F36E-4655-B079-D8EDD7907E45',
			'Lancrain',
			'Joseph',
			'jlancrain@gmail.com',
			'7632263190')
GO

select * from [dbo].[ContactTypes]

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[Cartons]
           ([Id]
           ,[UCC128]
           ,[Weight])
     VALUES
           ('5D62D153-6E4C-43C4-81ED-54D8D6976B22'
           ,'1234566'
           ,1)
GO

Select * from [dbo].[Cartons]


USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[SSCCs]
           ([Id]
           ,[SequenceNumber]
           ,[Used]
           ,[DTS])
     VALUES
           ('0C743BBE-4825-43A6-BEFF-2FD131C88A7B'
           ,1
           ,2
           ,getdate())
GO


select * FROM [dbo].[SSCCs]

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[StoreOrderDetails]
           ([Id]
           ,[QtyOrdered]
           ,[DPCI]
           ,[ItemDescription]
           ,[UPC]
           ,[SKUFK]
           ,[CartonFK]
           ,[QtyPacked]
           ,[StorFK])
     VALUES
           ('34FACFB9-5E3B-43A2-AB3B-83C3B9BE67E1'
           ,1
           ,'5247E965-78EE-4110-9B84-00307702DA0C'
           ,'ItemDescription'
           ,'123456789'
           ,'C6C14F95-219F-4D69-A92C-5C88EED692B6'
           ,'5D62D153-6E4C-43C4-81ED-54D8D6976B22'
           ,0
           ,'3E580E78-B8C7-4A72-9C2E-18D84B5B8F04'),

		   ('f9f3d5f5-dbe9-467a-9eca-4a9126452f57'
           ,1
           ,'5247E965-78EE-4110-9B84-00307702DA0C'
           ,'ItemDescription'
           ,'123456789'
           ,'C6C14F95-219F-4D69-A92C-5C88EED692B6'
           ,'5D62D153-6E4C-43C4-81ED-54D8D6976B22'
           ,0
           ,'819fc569-b295-42b9-85e1-4f1078368d36'),

		   ('14d7c0f1-05dd-4e6e-b376-e55d15625109'
           ,1
           ,'5247E965-78EE-4110-9B84-00307702DA0C'
           ,'ItemDescription'
           ,'123456789'
           ,'C6C14F95-219F-4D69-A92C-5C88EED692B6'
           ,'5D62D153-6E4C-43C4-81ED-54D8D6976B22'
           ,0
           ,'b7b14c9e-257f-473d-94ea-4d44d6a1b277')
GO

select * from [dbo].[StoreOrderDetails]

USE [Repository.DataSource.EDIContext]
GO

INSERT INTO [dbo].[Stores]
           ([Id]
           ,[DTS]
           ,[CompanyCode]
           ,[UPCode]
           ,[CustomerNumber]
           ,[PONumber]
           ,[ShippingLocationNumber]
           ,[VendorNumber]
           ,[PODate]
           ,[ShipDate]
           ,[CancelDate]
           ,[DCNumber]
           ,[ASNStatus]
           ,[PickStatus]
           ,[OrderStoreNumber]
           ,[BillToAddress]
           ,[QtyOrdered]
           ,[DocumentId]
           ,[OriginalLine]
           ,[SkuItemFK])
     VALUES
           ('3E580E78-B8C7-4A72-9C2E-18D84B5B8F04'
           ,GETDATE()
           ,'STO08'
           ,'UPcode'
           ,'CustomerNumber'
           ,'456789'
           ,'999999'
           ,'888888'
           ,GETDATE()
           ,'05-05-16'
           ,'06-16-16'
           ,'588'
           ,1
           ,0
           ,'1'
           ,'Bill To Address'
           ,2
           ,'DocumentID'
           ,'OriginalLine'
           ,'C6C14F95-219F-4D69-A92C-5C88EED692B6'),

		   ('819fc569-b295-42b9-85e1-4f1078368d36'
           ,GETDATE()
           ,'STO08'
           ,'UPcode'
           ,'CustomerNumber'
           ,'456789'
           ,'999999'
           ,'888888'
           ,GETDATE()
           ,'05-05-16'
           ,'06-16-16'
           ,'588'
           ,1
           ,0
           ,'1'
           ,'Bill To Address'
           ,2
           ,'DocumentID'
           ,'OriginalLine'
           ,'C6C14F95-219F-4D69-A92C-5C88EED692B6'),

		   ('b7b14c9e-257f-473d-94ea-4d44d6a1b277'
           ,GETDATE()
           ,'CER05'
           ,'UPcode'
           ,'CustomerNumber'
           ,'456789'
           ,'999999'
           ,'888888'
           ,GETDATE()
           ,'05-05-16'
           ,'06-16-16'
           ,'588'
           ,1
           ,0
           ,'1'
           ,'Bill To Address'
           ,2
           ,'DocumentID'
           ,'OriginalLine'
           ,'C6C14F95-219F-4D69-A92C-5C88EED692B6')
GO

select * from [dbo].[Stores]

INSERT INTO [dbo].[UserTables]
           ([Id]
           ,[UserName]
           ,[Password]
           ,[DTS]
           ,[OrdersFK])
     VALUES
           (NEWID()
           ,'Francis Jackson'
           ,'Password'
           ,GetDate()
           ,NULL),
		   (NEWID()
           ,'Joe Lancrain'
           ,'Password'
           ,GetDate()
           ,NULL)
GO

Select * From [dbo].[UserTables]
