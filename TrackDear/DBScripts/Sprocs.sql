USE [TrackDear]
GO
/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetAppUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetGroupDetails]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetGroupDetails]
GO
/****** Object:  StoredProcedure [dbo].[GetGroupMembers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetGroupMembers]
GO
/****** Object:  StoredProcedure [dbo].[GetGroupMembersByGroupName]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetGroupMembersByGroupName]
GO
/****** Object:  StoredProcedure [dbo].[GetGroups]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetGroups]
GO
/****** Object:  StoredProcedure [dbo].[GetGroupusers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetGroupusers]
GO
/****** Object:  StoredProcedure [dbo].[GetMemberLocation]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetMemberLocation]
GO
/****** Object:  StoredProcedure [dbo].[GetMembers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetMembers]
GO
/****** Object:  StoredProcedure [dbo].[GetTypeGroups]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetTypeGroups]
GO
/****** Object:  StoredProcedure [dbo].[GetTypes]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GetTypes]
GO
/****** Object:  StoredProcedure [dbo].[GroupMemberDetails]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[GroupMemberDetails]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelAppUsers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[InsUpdDelAppUsers]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelGroupMembers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[InsUpdDelGroupMembers]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelGroups]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[InsUpdDelGroups]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelMemberLocation]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[InsUpdDelMemberLocation]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelMembers]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[InsUpdDelMembers]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelTypeGroups]    Script Date: 12/18/2017 10:25:33 ******/
DROP PROCEDURE [dbo].[InsUpdDelTypeGroups]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelTypes]    Script Date: 12/18/2017 10:25:33 ******/
DROP PROCEDURE [dbo].[InsUpdDelTypes]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdEVerification]    Script Date: 12/18/2017 10:25:33 ******/
DROP PROCEDURE [dbo].[InsUpdEVerification]
GO
/****** Object:  StoredProcedure [dbo].[InsUpdMVerification]    Script Date: 12/18/2017 10:25:33 ******/
DROP PROCEDURE [dbo].[InsUpdMVerification]
GO
/****** Object:  StoredProcedure [dbo].[AcceptRejectRequest]    Script Date: 12/18/2017 10:25:32 ******/
DROP PROCEDURE [dbo].[AcceptRejectRequest]
GO
/****** Object:  StoredProcedure [dbo].[AcceptRejectRequest]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AcceptRejectRequest]
@AcceptRejectRequest int,
@RequestNo VarChar(50),
@MobileNo VarChar(10),
@flag VarChar
as
begin
declare @cnt int
if @flag='A'
begin
select @cnt=COUNT(*) from Members where MobileNo=@MobileNo

Raiserror('INVALID MOBILE NO',16,1);
return;
end
else
begin 
update GroupMembers
set AcceptRejectRequest=@AcceptRejectRequest,
    RequestNo=@RequestNo 
end

if @flag='R'
begin
select @cnt=COUNT(*) from Members where MobileNo=@MobileNo
Raiserror('INVALID MOBILE NO',16,1);
return;
end
else
begin 
update GroupMembers
set AcceptRejectRequest=@AcceptRejectRequest,
    RequestNo=@RequestNo
end
end
GO
/****** Object:  StoredProcedure [dbo].[InsUpdMVerification]    Script Date: 12/18/2017 10:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdMVerification]
@MobileNo varchar(10),@MobileOtp varchar(10)
as
begin
declare @cnt int

select @cnt = COUNT(*) from AppUsers where MobileNo = @MobileNo

if @cnt = 0
   begin
  
				RAISERROR ('Invalid Mobile Number',16,1);
				return;
   end

else

begin

  select @cnt = COUNT(*) from AppUsers where MobileNo = @MobileNo and [MobileOtp] = @MobileOtp 
  if @cnt = 0
	begin
	  
					RAISERROR ('Invalid Mobile OTP',18,1);
					return;
	end
 
  else
 
   begin
     update AppUsers set [MobileOtp]  = null where MobileNo  = @MobileNo  and [MobileOtp]  = @MobileOtp
   
     select [FirstName],[LastName],[Email],[MobileNo],[EmailOtp],[Address],[Photo],[Id] ,[MobileOtp] from AppUsers where MobileNo  = @MobileNo
   end
 
end




	
END
GO
/****** Object:  StoredProcedure [dbo].[InsUpdEVerification]    Script Date: 12/18/2017 10:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdEVerification]
@Email varchar(50),@Emailotp varchar(10)
as
begin

declare @cnt int

select @cnt = COUNT(*) from Appusers where Email = @Email

if @cnt = 0
   begin
  
				RAISERROR ('Invalid Email address',16,1);
				return;
   end

else

begin

  select @cnt = COUNT(*) from Appusers where Email = @Email and [Emailotp] = @Emailotp 
  if @cnt = 0
	begin
	  
					RAISERROR ('Invalid Email OTP',16,1);
					return;
	end
 
  else
 
   begin
     update Appusers set Emailotp  = null where Email  = @Email  and [Emailotp]  = @Emailotp
   
     select [FirstName] ,[Email] ,[MobileNo] ,[Mobileotp] ,[Emailotp]  from Appusers where Email  = @Email
   end
 
end

end
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelTypes]    Script Date: 12/18/2017 10:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsUpdDelTypes]
(@Id int, @Name varchar(50), @Description varchar(500), @Active int, @TypeGroupId varchar(20), @ListKey varchar(20), @ListValue varchar(20), @flag varchar)
as 
begin
if @flag = 'I'
begin
	  insert into Types(Name, [Description], Active, TypeGroupId, ListKey, ListValue)
	  values (@Name, @Description, @Active,@TypeGroupId,@ListKey,@ListValue)
	end
	else
	if @flag = 'U'	
	begin
	  update Types
	  set  Name= @Name,
	      [Description]=@Description,
	       Active =  @Active,
	       TypeGroupId = @TypeGroupId,
	       ListKey = @ListKey,
	       ListValue = @ListValue
	       where Id = @Id
	       
	end
	if @flag = 'D'
	begin
	 delete from  Types where Id = @Id
	end
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelTypeGroups]    Script Date: 12/18/2017 10:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelTypeGroups] 
(@Id int=-1, @Name varchar(50), @Description varchar (500), @Active int, @flag varchar)
as 
begin
if @flag = 'I'
begin
	  insert into TypeGroups(Name, [Description], Active) 
	  values (@Name, @Description, @Active)
	end
	else
	if @flag = 'U'	
	begin
	  update TypeGroups
	  set  Name= @Name,
	      [Description]=@Description,
	       Active =  @Active
	       where Id = @Id
	       
	end
	if @flag = 'D'
	begin
	 delete from  TypeGroups where Id = @Id
	end
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelMembers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsUpdDelMembers]
(@FirstName varchar(50)
           ,@LastName varchar(50)
           ,@Email varchar(150)
           ,@MobileNo varchar(10)
           ,@Mobileotp varchar(10)=null
           ,@Address varchar(500)=null
           ,@Photo varchar(MAX)=null
           ,@Ownerid int
           ,@FCMID varchar(50)
           ,@Id int
           ,@Active int=null
           ,@statusId int
           ,@Accepted int =null
           ,@Acceptedotp varchar(10)=null,@flag varchar)
           As
           begin
           
           declare @m varchar(10)
           
           select @m = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))+5
           If @flag ='I'
           begin
           Insert into Members
            (FirstName
           ,LastName
           ,Email
           ,MobileNo
           ,Mobileotp
           ,[Address]
           ,Photo
           ,Ownerid
           ,FCMID           
           ,Active
           ,StatusId
           ,Accepted
           ,Acceptedotp)
           Values (@FirstName 
           ,@LastName 
           ,@Email 
           ,@MobileNo 
           ,@m 
           ,@Address 
           ,@Photo 
           ,@Ownerid 
           ,@FCMID            
           ,@Active 
           ,@statusId 
           ,@Accepted 
           ,@Acceptedotp )
           end
           If @flag ='U'
           begin
           Update Members
            SET FirstName = @FirstName
      ,LastName = @LastName
      ,Email = @Email
      ,MobileNo = @MobileNo     
      ,[Address] = @Address
      ,Photo = @Photo
      ,Ownerid = @Ownerid
      ,FCMID = @FCMID
      ,Active = @Active
      ,StatusId = @statusId
      ,Accepted = @Accepted
      ,Acceptedotp = @Acceptedotp
      where Id = @Id
           end
           If @flag ='D'
           begin
           DELETE FROM Members
           where Id = @Id
           end
           end
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelMemberLocation]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelMemberLocation] 
(@Id int, @Latitude varchar(50), @Longitude varchar(50), @FCMID varchar(50), 
@PlaceId varchar(50), @LocationDesc varchar(150), @City varchar(50), @State varchar(50), 
@Place varchar(50), @Date Date=null, @Time time(7)=null, @flag varchar)
as 
begin
declare @dt date,@t time(7)
set @dt =GETDATE()
set @t =GETDATE()
if @flag = 'I'
begin
	  insert into MemberLocation(Latitude,Longitude,FCMID,PlaceId,LocationDesc,City,[State],Place,[Date],[Time]) 
	  values (@Latitude,@Longitude,@FCMID,@PlaceId,@LocationDesc,@City,@State,@Place,@dt,@t)
	end
	else
	if @flag = 'U'	
	begin
	  update MemberLocation
	  set Latitude= @Latitude,
	      Longitude= @Longitude,
	      FCMID=@FCMID,
	      PlaceId = @PlaceId,
	      LocationDesc = @LocationDesc,
	      City=@City,
	      [State]= @State,
	      Place = @Place,
	      [Date] = @Date,
	      [Time] = @Time
	  where Id = @Id
	end
	if @flag = 'D'
	begin
	 delete from MemberLocation where Id = @Id
	end
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelGroups]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsUpdDelGroups]
(@Id int,
@Name Varchar(50),
@Description Varchar(500),
@Title Varchar(50),
@photo Varchar(max),
@Active int,
@flag Varchar)
As begin
if @flag='I'
begin insert into Groups
(Name,
Description,
Title,
Photo,
Active)values 
(@Name,
@Description,
@Title,
@photo,
@Active)
end
if @flag='U'
begin
update Groups set 
Name=@Name,
Description=@Description,
Title=@Title,
Photo=@Photo,
Active=@Active
where Id=@Id
end
if @flag='D'
begin
delete from Groups where Id=@Id
end
end
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelGroupMembers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelGroupMembers]
(@GroupId int,
@OwnerId int,
@memberId int,
@FCMID VarChar(50),
@Id int,
@AcceptRejectRequest int=null,
@RequestNo varchar(50)=null,
@StartTracking int=null,
@flag VarChar)
as begin 
if @flag='I'
begin
insert into GroupMembers 
(GroupId,
OwnerId,
MemberId,
FCMID,
AcceptRejectRequest,
RequestNo,
StartTracking
)
values(@GroupId,
@OwnerId,
@memberId,
@FCMID,
@AcceptRejectRequest ,
@RequestNo ,
@StartTracking )
end
if @flag='U'
begin
update GroupMembers set 
GroupId=@GroupId,
OwnerId=@OwnerId,
memberId=@memberId,
FCMID=@FCMID, 
AcceptRejectRequest=@AcceptRejectRequest ,
RequestNo=@RequestNo ,
StartTracking=@StartTracking 
where Id=@Id
end
if @flag='D'
begin
delete from GroupMembers where Id=@Id
end  
end
GO
/****** Object:  StoredProcedure [dbo].[InsUpdDelAppUsers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsUpdDelAppUsers]
(@FirstName Varchar(50),
@lastName Varchar(50),
@Email Varchar(100),
@MobileNo Varchar(10),
@Address Varchar(500),
@Photo Varchar(MAX)=null,
@MobileOtp varchar(5)=null,
@EmailOtp varchar(5)=null,
@Id int,@flag varchar)
as
begin

declare @e varchar(5),@m varchar(5) 

select @e = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))
select @m = replace(CONVERT(VARCHAR(1), GETDATE(), 114),':','')+ CONVERT(VARCHAR(3),DATEPART(millisecond,GETDATE()))+5

if @flag = 'I'
begin
insert into AppUsers
(FirstName ,
lastName ,
Email ,
MobileNo ,
MobileOtp ,
EmailOtp,
[Address],
Photo 
 ) 
values 
(@FirstName,
@lastName ,
@Email, 
@MobileNo, 
@m,
@e,
@Address, 
@Photo )
end
if @flag='U'
begin
Update AppUsers set 
FirstName=@FirstName,
lastName=@lastName ,
Email=@Email, 
MobileNo=@MobileNo, 
Mobileotp = @Mobileotp,
Emailotp = @Emailotp,
[Address]=@Address, 
Photo=@Photo
where 
Id=@Id
end
if @flag='D'
begin
delete from AppUsers where Id=@Id
end

select [MobileOtp],[Emailotp],[FirstName] ,[LastName] ,[Email],[MobileNo],[Address] from AppUsers where MobileNo = @MobileNo
 
end
GO
/****** Object:  StoredProcedure [dbo].[GroupMemberDetails]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GroupMemberDetails]
@MemberId int
as 
begin 
SELECT [FirstName]
      ,[LastName]
      ,[Email]
      ,[MobileNo]
      ,[Address]
      ,[Photo]      
  FROM [dbo].[Members]
  where Id=@MemberId
  end
GO
/****** Object:  StoredProcedure [dbo].[GetTypes]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTypes]
  as
  begin
  select tt.[Id],
  tt.[Name],
  tt.[Description],
  tt.[Active],
  t.Name as Typegroup,
  [TypeGroupId],
  [ListKey],
  [ListValue]
  from [Types] tt 
  
  inner  join TypeGroups t on t.Id =  tt.TypeGroupId
  
  end
GO
/****** Object:  StoredProcedure [dbo].[GetTypeGroups]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTypeGroups]
  as
  begin 
  select [Id],
  [Name],
  [Description],
  [Active]
  from [TypeGroups]
  end
GO
/****** Object:  StoredProcedure [dbo].[GetMembers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetMembers]
@ownerid int
as
begin 
select [FirstName],
       [LastName],
       [Email],
       [MobileNo],
       [MobileOtp],
       [Address],
       [Photo],
       [Ownerid],
       [FCMID],
       [Id],
       [Active],
       [statusId],
       [Accepted],
       [Acceptedotp]
from Members where Ownerid = @ownerid
end
GO
/****** Object:  StoredProcedure [dbo].[GetMemberLocation]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetMemberLocation]
@Id int 
as 
begin
select [Id]
      ,[Latitude]
      ,[Longitude]
      ,[FCMID]
      ,[PlaceId]
      ,[LocationDesc]
      ,[City]
      ,[State]
      ,[Place]
      ,[Date]
      ,[Time]
  FROM [MemberLocation] where Id = @Id
  end
GO
/****** Object:  StoredProcedure [dbo].[GetGroupusers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[GetGroupusers]
@MobileNo Varchar(10)
as
begin
SELECT A.[FirstName]
      ,A.[LastName]
      ,A.[Email]
      ,[MobileNo]
      ,[Address]
      ,A.[Photo]
      ,A.[Id],
      g.Name as Groupname,
      g.Title as title
  FROM [dbo].[AppUsers] A
inner join GroupMembers gm on gm.OwnerId= A.Id
inner join Groups g on g.Id=gm.GroupId
where MobileNo=@MobileNo

End
GO
/****** Object:  StoredProcedure [dbo].[GetGroups]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetGroups]
@Id int
as
begin 
select [Id],
       [Name],
       [Description],
       [Title],
       [Photo],
       [Active]
from Groups where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[GetGroupMembersByGroupName]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetGroupMembersByGroupName]
@GroupId int
as 
begin 
SELECT g.Name as Name
      ,A.FirstName as [Owner]
      ,M.FirstName as[Member]
      ,gm.[FCMID]
      ,gm.[Id]
      ,[AcceptRejectRequest]
      ,[RequestNo]
      ,[StartTracking]
  FROM [dbo].[GroupMembers] gm
inner join Groups g on g.Id=gm.GroupId
inner join AppUsers A on A.Id=gm.OwnerId
inner join Members M on M.Id=gm.MemberId
where GroupId=@GroupId
end
GO
/****** Object:  StoredProcedure [dbo].[GetGroupMembers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetGroupMembers]
@gname varchar(50)
as
begin 
select g.Name as GroupName,
       [GroupId],
       gm.[Ownerid],
       [MemberId],
       gm.[FCMID],
       gm.[Id],       
       m.FirstName,
       m.LastName,
       m.MobileNo,
       m.Photo,       
       a.FirstName as OwnerFirstName,
       a.LastName as OwnerLastName , 
       gm.AcceptRejectRequest,
       gm.RequestNo,
       gm.StartTracking  
from GroupMembers gm 
inner join Groups g on g.Id = gm.GroupId
 left outer join Members m on m.Id = gm.MemberId
 left outer join AppUsers a on a.Id = gm.OwnerId
where name = @gname
end
GO
/****** Object:  StoredProcedure [dbo].[GetGroupDetails]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetGroupDetails]
 @GroupId int 
 as
begin
 SELECT [Id]
      ,[Name]
      ,[Description]
      ,[Title]
      ,[Photo]
      ,[Active]
  FROM [dbo].[Groups]  
  
where Id =@GroupId

end
GO
/****** Object:  StoredProcedure [dbo].[GetAppUsers]    Script Date: 12/18/2017 10:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAppUsers]
@MobileNo varchar(10)
as
begin 
select [FirstName],[LastName],[Email],[MobileNo],[Address],[Photo],[Id]
from AppUsers where MobileNo = @MobileNo
end
GO
