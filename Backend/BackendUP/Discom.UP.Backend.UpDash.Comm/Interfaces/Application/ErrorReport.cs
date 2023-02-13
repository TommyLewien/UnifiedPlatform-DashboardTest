namespace Discom.UP.Backend.UpDash.Comm.Interfaces.Application
{
    public class ErrorReport
    {

        public string Application { get; set; }
        public string User { get; set; }
        public string Request { get; set; }
        public string ErrorText { get; set; }

        public ErrorReport(string errorText)
        {

            Application = "";
            User = "";
            Request = "";
            ErrorText = errorText;

        }

    }
}
