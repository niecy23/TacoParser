namespace LoggingKata
{
    /// <summary>
    /// sParses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // DONE - Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // DONE - Log that and return null
                // DONE - Do not fail if one record parsing fails, return null

                logger.LogWarning("Incomplete Data: Less than three items");
                return null; // DONE Implement
            }

            // DONE - grab the latitude from your array at index 0

            var latitude = double.Parse(cells[0]);

            // DONE - grab the longitude from your array at index 1

            var longitude = double.Parse(cells[1]);

            // DONE - grab the name from your array at index 2

            var name = cells[2];

            // DONE - Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // DONE - You'll need to create a TacoBell class
            // that conforms to ITrackable

            // DONE - Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            var newTacoBell = new TacoBell()
            {
                Name = name,
                Location = point
            };


            // DONE - Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return newTacoBell;
        }
    }
}