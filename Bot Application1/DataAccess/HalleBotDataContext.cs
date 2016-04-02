using System;
using System.Collections.Generic;
using System.Linq;
namespace Bot_Application1.DataAccess
{
    partial class HalleBotDataContext
    {
        public List<interaction> addInteraction (string patientID, interaction myInteraction)
        {
            List<object> values = new List<object>();
            if (myInteraction.conversationID == null)
            {
                myInteraction.conversationID = Guid.NewGuid();
                //create conversation
                ExecuteCommand("insert into conversation (conversationID, patientID) values ({0}, {1})", myInteraction.conversationID, patientID);
            }
            values.Add(myInteraction.conversationID);
            values.Add(myInteraction.text);
            if (myInteraction.sentiment == null)
            {
                values.Add(DBNull.Value);
            }
            else
            {
                values.Add(myInteraction.sentiment);
            }
            if (myInteraction.flag == null)
            {
                values.Add(DBNull.Value);
            }
            else
            {
                values.Add(myInteraction.flag);
            }

            //createDate has Default Constraint
            ExecuteCommand("insert into interaction (conversationID, text, sentiment, flag) values({0}, {1}, {2}, {3})", values.ToArray());


            return ExecuteQuery<interaction>("select top 4 * from interaction where conversationID = {0} order by createDate desc", myInteraction.conversationID).ToList();
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