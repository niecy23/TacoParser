using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // DONE:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // DONE - use File.ReadAllLines(path) to grab all the lines from your csv file
            // DONE - Log an error if you get 0 lines and a warning if you get 1 line

            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("No Lines Found");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("Only One Line Was Found");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            // DONE - Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // DONE - Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();



            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // DONE - Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // DONE - Create a `double` variable to store the distance

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;

            // DONE - Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------

            // DONE - Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            
            for (int i = 0; i < locations.Length; i++)
            {
                // DONE - Create a new corA Coordinate with your locA's lat and long
                var locA = locations[i];
                var coordA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                // DONE - Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
               
                for (int x = 0; x < locations.Length; x++)
                {
                    // DONE - Create a new Coordinate with your locB's lat and long
                    var locB = locations[x];
                    var coordB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    // DONE - Now, compare the two using `.GetDistanceTo()`, which returns a double
                    // DONE - If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

                    if (coordA.GetDistanceTo(coordB) > distance)
                    {
                        distance = coordA.GetDistanceTo(coordB);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }
            }

            // DONE - Once you've looped through everything, you've found the two Taco Bells farthest away from each other
            //
            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are the farthest away from each other.");

        }
    }
}
