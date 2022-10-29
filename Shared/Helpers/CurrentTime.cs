namespace Shared.Helpers
{
    public class CurrentTime
    {

        public string getCurrentTime()
        {
          return  DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            //DateTime.Now.ToString("hh:mm:ss.fff tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }
    }
}
