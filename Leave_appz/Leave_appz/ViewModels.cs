using System;
namespace Leave_appz
{
    public class ViewModels
    {
        public bool casualLeaveDateLabelValidater(string str){

            if(str.Trim().Equals("Tap to Select Date")){

                return true;
            }
            else if (str.Trim().Equals("")){
                return true;
            }
            else{
                return false;
            }
        }

        public bool casualLeaveMyEditorLabelValidater(string str)
        {

            if (str.Trim().Equals("Please provide the reason for your leave here !!"))
            {

                return true;
            }
            else if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool earnedLeaveDateLabelValidater(string str)
        {

            if (str.Trim().Equals("From Date"))
            {

                return true;
            }
            else if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool earnedLeaveDateNLabelValidater(string str)
        {

            if (str.Trim().Equals("To Date"))
            {

                return true;
            }
            else if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool earnedLeaveMyEditorLabelValidater(string str)
        {

            if (str.Trim().Equals("Please provide the reason for your leave here !!"))
            {

                return true;
            }
            else if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkForEmptyString(string str)
        {

             if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool sickLeaveDateLabelValidater(string str)
        {

            if (str.Trim().Equals("Tap to Select Date"))
            {

                return true;
            }
            else if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool sickLeaveEntryLabelValidater(string str)
        {

            if (str.Trim().Equals("Please provide the reason for your leave here !!"))
            {

                return true;
            }
            else if (str.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
