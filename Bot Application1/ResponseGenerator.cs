using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bot_Application1.DataAccess;

namespace Bot_Application1
{
    public static class ResponseGenerator
    {

        public static string GetConversationMessage(string patientId)
        {
            using (HalleBotDataContext db = new HalleBotDataContext())
            {
                return ""; //db.GetMessage(patientId, MessageTypes.Conversation);
            }
        }

        public static string GetEscalationMessage(string patientId)
        {
            using (HalleBotDataContext db = new HalleBotDataContext())
            {
                patient p = db.getPatient(patientId);

                return GetPatientMessage(p);

            }
        }

        public static string GetPatientMessage(patient p)
        {

            if(p.homeNumber == null)
            {
                return string.Format("We'd like to get you in direct contact with a care giver but don't have a phone number on record this person can reach you by. Do you have a phone number we can reach you by?");
            }
            else
            {
                return string.Format("We'd like to have someone call you at {0}. That's the phone number we have on file for you. Is that a good number?");
            }

        }

    }
}