using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 525
    /// mini uber
    /// http://www.lintcode.com/en/problem/mini-uber/
    /// 
    /// Support two basic uber features:
    /// 
    /// Drivers report their locations.
    /// Rider request a uber, return a matched driver.
    /// When rider request a uber, match a closest available driver with him, then mark the driver not available.
    /// 
    /// 
    /// When next time this matched driver report his location, return with the rider's information.
    /// 
    /// 
    /// You can implement it with the following instructions:
    /// 
    /// 
    /// report(driver_id, lat, lng)
    /// 1) return null if no matched rider.
    /// 2) return matched trip information.
    /// 
    /// request(rider_id, lat, lng)
    /// 1) create a trip with rider's information.
    /// 2) find a closest driver, mark this driver not available.
    /// 3) fill driver_id into this trip.
    /// 4) return trip
    /// 
    /// Example
    /// report(1, 36.1344, 77.5672) // return null
    /// report(2, 45.1344, 76.5672) // return null
    /// request(2, 39.1344, 76.5672) // return a trip, LOG(INFO): Trip(rider_id: 2, driver_id: 1, lat: 39.1344, lng: 76.5672)
    /// report(1, 38.1344, 75.5672) // return a trip, LOG(INFO): Trip(rider_id: 2, driver_id: 1, lat: 39.1344, lng: 76.5672)
    /// report(2, 45.1344, 76.5672) // return null
    /// </summary>
    class MiniUber
    {
        private Dictionary<int, Trip> tripTable;
        private Dictionary<int, Driver> driverTable;
        private Random tripIdGenerator;

        public MiniUber()
        {
            tripTable = new Dictionary<int, Trip>();
            driverTable = new Dictionary<int, Driver>();
            tripIdGenerator = new Random();
        }

        // @param driver_id an integer
        // @param lat, lng driver's location
        // return matched trip information if there have matched rider or null
        public Trip Report(int driver_id, double lat, double lng)
        {
            if (!driverTable.ContainsKey(driver_id))
            {
                Driver driver = new Driver(driver_id, lat, lng);
                driverTable.Add(driver_id, driver);
            }
            else
            {
                var driver = driverTable[driver_id];
                driver.lat = lat;
                driver.lng = lng;
                var status = driver.status;

                if (status == DriverStatus.occupied)
                {
                    // in this code, driver is forced to accepet request
                    var trip = tripTable[driver.currTripId];
                    return trip;
                }
            }

            return null;
        }

        public void TripDone(int driver_id)
        {
            if (driverTable.ContainsKey(driver_id))
            {
                var driver = driverTable[driver_id];
                driver.currTripId = -1;
                driver.status = DriverStatus.free;
            }
            

        }

        // @param rider_id an integer
        // @param lat, lng rider's location
        // return a trip
        public Trip Request(int rider_id, double lat, double lng)
        {
            var tripId = tripIdGenerator.Next(100);
            var trip = new Trip(rider_id, lat, lng);

            tripTable.Add(tripId, trip);

            // find the nearest driver
            int driverid = -1;
            double distance = Int32.MaxValue;

            // not good, should use geohash distance Table
            foreach(var driver in driverTable.Values)
            {
                var temp = DistanceHelper.get_distance(lat, lng, driver.lat, driver.lng);
                if (distance > temp)
                {
                    distance = temp;
                    driverid = driver.id;
                }
            }

            if (driverid == -1)
            {
                return null;   // cannot find driver. 
            }

            var nearestDriver = driverTable[driverid];
            nearestDriver.status = DriverStatus.occupied;
            nearestDriver.currTripId = tripId;   // force assign to driver
            trip.driver_id = driverid;  // complete trip info


            return trip;
        }
    }

    public class Trip
    {
        public int id; // trip's id, primary key
        public int driver_id, rider_id; // foreign key
        public double lat, lng; // pick up location
        public Trip(int rider, double lat, double lng)
        {
            rider_id = rider;
            this.lat = lat;
            this.lng = lng;
        }
    }
    
    public enum DriverStatus
    {
        free,
        occupied
    }
    public class Driver
    {
        public int id; // driver's id, primary key
        public double lat, lng; // current location

        public DriverStatus status;

        public int currTripId;

        public Driver(int driver, double lat, double lng)
        {
            id = driver;
            this.lat = lat;
            this.lng = lng;
            status = DriverStatus.free;
        }

    }
    class DistanceHelper
    {
        public static double get_distance(double lat1, double lng1,
                                         double lat2, double lng2)
        {
            return Math.Sqrt((lat2 - lat1) * (lat2 - lat1) + (lng2 - lng1) * (lng2 - lng1));
        }
    };
}
