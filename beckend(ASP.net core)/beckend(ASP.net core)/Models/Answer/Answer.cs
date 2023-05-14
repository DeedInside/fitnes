﻿namespace beckend_ASP.net_core_.Models.Answer
{
    public class Answer<T>
    {
        private int statusCode = 0;
        private string message = "";
        private T? data;

        public int StatusCode
        {
            get
            {
                if(statusCode == 0)
                {
                    return 404;
                }
                else
                {
                    return statusCode;
                }
            }
            set
            {
                statusCode = value;
            }
        }
        public string Message {
            get
            {
                if(message == null || message == "")
                {
                    return "not description";
                }
                else
                {
                    return message;
                }
            }
            set
            {
                message = value;
            }
        }
        public T Data {
            get
            { 
                if (data == null)
                {
                    throw new ArgumentNullException("data = null");
                }
                else
                {
                    return data;
                }
            }
            set
            {
                data = value;
            }
        }
    }
}
