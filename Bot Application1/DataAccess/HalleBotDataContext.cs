using System;
using System.Collections.Generic;
using System.Linq;
namespace Bot_Application1.DataAccess
{
    partial class HalleBotDataContext
    {
        public List<interaction> addInteraction(string patientID, interaction myInteraction)
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
                }
                else
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

            List<interaction> returnInteractions = ExecuteQuery<interaction>("select top 4 * from interaction where conversationID = {0} order by createDate desc", myInteraction.conversationID).ToList();

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
            string sqlPatient = "insert into patient (patientID, name, mobileNumber, homeNumber, workNumber, dateOfBirth, gender) values({0}, {1}, {2}, {3}, {4}, {5}, {6})";
            List<object> values = new List<object>();
            values.Add(myPatient.patientID);
            values.Add(myPatient.name);
            if (myPatient.mobileNumber == null)
            {
                values.Add("");
                sqlPatient = sqlPatient.Replace("{2}", "NULL");
            }
            else
            {
                values.Add(myPatient.mobileNumber);
            }
            if (myPatient.homeNumber == null)
            {
                values.Add("");
                sqlPatient = sqlPatient.Replace("{3}", "NULL");
            }
            else
            {
                values.Add(myPatient.homeNumber);
            }
            if (myPatient.workNumber == null)
            {
                values.Add("");
                sqlPatient = sqlPatient.Replace("{4}", "NULL");
            }
            else
            {
                values.Add(myPatient.workNumber);
            }
            if (myPatient.dateOfBirth == null)
            {
                values.Add(0);
                sqlPatient = sqlPatient.Replace("{5}", "NULL");
            }
            else
            {
                values.Add(myPatient.dateOfBirth);
            }
            if (myPatient.gender == null)
            {
                values.Add("N");
                sqlPatient = sqlPatient.Replace("{6}", "NULL");
            }
            else
            {
                values.Add(myPatient.gender);
            }

            ExecuteCommand(sqlPatient, values.ToArray());

        }

        public void updatePatient(patient myPatient)
        {
            string sqlPatient = "update patient ";
            string sqlPatientWhere = " where patientID = {0}";
            List<object> values = new List<object>();
            values.Add(myPatient.patientID);
            int i = 1;
            bool IsFirstValue = true;
            if (!string.IsNullOrEmpty(myPatient.name))
            {
                sqlPatient += " name = {" + i + "}";
                values.Add(myPatient.name);
                IsFirstValue = false;
                i += 1;
            }
            if (!string.IsNullOrEmpty(myPatient.mobileNumber))
            {
                sqlPatient += IsFirstValue ? "" : "," + " mobileNumber = {" + i + "}";
                values.Add(myPatient.mobileNumber);
                IsFirstValue = false;
                i += 1;
            }
            if (!string.IsNullOrEmpty(myPatient.homeNumber))
            {
                sqlPatient += IsFirstValue ? "" : "," + " homeNumber = {" + i + "}";
                values.Add(myPatient.homeNumber);
                IsFirstValue = false;
                i += 1;
            }
            if (!string.IsNullOrEmpty(myPatient.workNumber))
            {
                sqlPatient += IsFirstValue ? "" : "," + " workNumber = {" + i + "}";
                values.Add(myPatient.workNumber);
                IsFirstValue = false;
                i += 1;
            }
            if (myPatient.gender.HasValue && !string.IsNullOrEmpty(myPatient.gender.ToString()))
            {
                sqlPatient += IsFirstValue ? "" : "," + " gender = {" + i + "}";
                values.Add(myPatient.gender);
                IsFirstValue = false;
                i += 1;
            }

            ExecuteCommand(sqlPatient + sqlPatientWhere, values.ToArray());
        }


        public responseMessage getMessage(string patientID, int messageType, int? responseID = null)
        {

            string sqlIsConversationStale = "select conversationID " +
                    "from interaction with (nolock) " +
                    "where conversationID in ( " +
                    "    select top 1 conversationID " +
                    "    from conversation with (nolock) " +
                    "    where patientID = {0} order by createDate desc) " +
                    "  and createDate >= dateadd(m, -10, {1})";
            Guid conversationID;

            conversationID = ExecuteQuery<Guid>(sqlIsConversationStale, patientID, DateTime.Now).FirstOrDefault();

            responseMessage ConsumedMessage;
            if (responseID == null)
            {
                ConsumedMessage = ExecuteQuery<responseMessage>("select TOP 1 * from responseMessage Where messageType = {0} and responseID not in (select responseID from conversation_response where conversationID in {1})  Order By NewID()", messageType, conversationID).FirstOrDefault();
            }   else
            {
                ConsumedMessage = ExecuteQuery<responseMessage>("select TOP 1 * from responseMessage Where responseID = {0} Order By NewID()", responseID).FirstOrDefault();
            }

            ExecuteCommand("insert into conversation_response(conversationID, responseID) values ({0}, {1})", conversationID, ConsumedMessage.responseID);

            return ConsumedMessage;
        }
    }
}