using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackDear.Models
{
    public class Execute
    {
        public int Id { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FCMID { get; set; }
        public string PlaceId { get; set; }
        public string LocationDesc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Place { get; set; }
        public string flag { get; set; }
    }

    public class Group
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public string flag { get; set; }
    }

    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public int TypeGroupId { get; set; }
        public string ListKey { get; set; }
        public string ListValue { get; set; }
        public string flag { get; set; }
    }

    public class Email
    {
        public string EmailId{ get; set;}

        public string MobileNo { get; set; }

        public string MobileOtp{ get; set;}


        public string EmailOtp { get; set; }              
            
        
    }
    public class Members
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string MobileOtp { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public int Ownerid { get; set; }
        public string FCMID { get; set; }
        public int Id { get; set; }
        public int Active { get; set; }
        public int statusId { get; set; }
        public int Accepted { get; set; }
        public int Acceptedotp { get; set; }
        public string flag { get; set; }
    }
    public class AppUsers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string MobileOtp { get; set; }
        public string EmailOtp { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public int Id { get; set; }
        public string flag { get; set; }
    }
    public class GroupMembers
    {
        public int GroupId { get; set; }
        public int OwnerId { get; set; }
        public int memberId { get; set; }
        public string FCMID { get; set; }
        public int Id { get; set; }
        public string flag { get; set; }
    }
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string photo { get; set; }
        public int Active { get; set; }
        public string flag { get; set; }
    }
    public class AcceptRequest
    {
        public int AcceptRejectRequest { get; set; }

        public string RequestNo { get; set; }

        public string MobileNo { get; set; }

        public string flag { get; set; }

    }
    
}

    