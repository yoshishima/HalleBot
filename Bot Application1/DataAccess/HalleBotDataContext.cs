using System;
using System.Collections.Generic;
using System.Linq;
namespace Bot_Application1.DataAccess
{
    partial class HalleBotDataContext
    {
        public List<interaction> addInteraction (string patientID, interaction myInteraction)
        {
            //get last conversation's last interaction (time)
            //is interaction past arbitrary time (10 minutes)
            string sqlIsConversationStale = "select conversationID " +
                    "from interaction with (nolock) " +
                    "where conversationID in ( " +
                    "    select top 1 conversationID " +
                    "    from conversation with (nolock) " +
                    "    where patientID = {0} order by createDate desc) " +
                    "  and createDate >= dateadd(m, -10, {1})";
            myInteraction.conversationID = ExecuteQuery<Guid>(sqlIsConversationStale, patientID, DateTime.Now).FirstOrDefault();

            //Add interation
            string sqlInteraction = "insert into interaction (conversationID, createDate, text, sentiment, flag) values({0}, {1}, {2}, {3}, {4})";
            List<object> values = new List<object>();
            if (myInteraction.conversationID == null || myInteraction.conversationID == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                myInteraction.conversationID = Guid.NewGuid();
                //create conversation
                ExecuteCommand("insert into conversation (conversationID, patientID, createDate) values ({0}, {1}, {2})", myInteraction.conversationID, string.IsNullOrEmpty(patientID) ? "" : patientID, DateTime.Now);
            }
            values.Add(myInteraction.conversationID);
            myInteraction.createDate = DateTime.Now;
            values.Add(myInteraction.createDate);
            values.Add(myInteraction.text);
            if (myInteraction.sentiment == null)
            {
                sqlInteraction = sqlInteraction.Replace("{3}", "NULL");
                values.Add(0);
            }
            else
            {
                values.Add(myInteraction.sentiment);
            }
            if (myInteraction.flag == null)
            {
                sqlInteraction = sqlInteraction.Replace("{4}", "NULL");
                values.Add(0);
            }
            else
            {
                values.Add(myInteraction.flag);
            }

            //createDate has Default Constraint
            ExecuteCommand(sqlInteraction, values.ToArray());
            int seq = 1;
            foreach (interactionIntent interintent in myInteraction.interactionIntents)
            {
                List<object> intentValues = new List<object>();
                string sqlInteractionIntent = "insert into interactionIntent (conversationID, createDate, seq, name, confidence) values({0}, {1}, {2}, {3}, {4})";
                intentValues.Add(myInteraction.conversationID);
                intentValues.Add(myInteraction.createDate);
                intentValues.Add(seq);
                if (interintent.name == null)
                {
                    sqlInteractionIntent = sqlInteractionIntent.Replace("{3}", "NULL");
                    intentValues.Add(0);
                } else
                {
                    intentValues.Add(interintent.name);
                }
                if (interintent.confidence == null)
                {
                    sqlInteractionIntent = sqlInteractionIntent.Replace("{4}", "NULL");
                    intentValues.Add(0);
                }
                else
                {
                    intentValues.Add(interintent.confidence);
                }

                ExecuteCommand(sqlInteractionIntent, intentValues.ToArray());
                seq += 1;
            }

            List< interaction> returnInteractions = ExecuteQuery<interaction>("select top 4 * from interaction where conversationID = {0} order by createDate desc", myInteraction.conversationID).ToList();

            foreach (interaction inter in returnInteractions)
            {
                inter.interactionIntents.AddRange(ExecuteQuery<interactionIntent>("select * from interactionintent where conversationID = {0} and createDate = {1}", myInteraction.conversationID, myInteraction.createDate));
            }

            return returnInteractions;
        }
        public void updateConversationLocation(Guid conversationID, string currentLocation)
        {
            ExecuteCommand("update conversation set currentLocation = {1} where conversationID = {0}", conversationID, currentLocation);
        }
        public patient getPatient(string patientID)
        {
            return ExecuteQuery<patient>("select * from patient where patientID = {0}", patientID).FirstOrDefault();
        }
        public void addPatient(patient myPatient)
        {
            List<object> values = new List<object>();
            values.Add(myPatient.patientID);           
            values.Add(myPatient.name);
            values.Add(myPatient.mobileNumber);
            values.Add(myPatient.homeNumber);
            values.Add(myPatient.workNumber);
            if (myPatient.dateOfBirth == null) {
                values.Add(DBNull.Value);
            }
            else {
                values.Add(myPatient.dateOfBirth);
            }
            values.Add(myPatient.gender);
                
            ExecuteCommand("insert into patient (patientID, name, mobileNumber, homeNumber, workNumber, dateOfBirth, gender) values({0}, {1}, {2}, {3}, {4}, {5}, {6})", values.ToArray());

        }
    }
}