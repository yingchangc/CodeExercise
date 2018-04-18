using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    /// <summary>
    /// 509
    /// http://www.lintcode.com/en/problem/mini-yelp/
    /// Design a simple yelp system. Support the following features:

    ///Add a restaurant with name and location.
    ///Remove a restaurant with id.
    ///Search the nearby restaurants by given location.
    ///A location is represented by latitude and longitude, both in double. A Location class is given in code.
    ///
    ///Nearby is defined by distance smaller than k Km.
    ///
    ///Restaurant class is already provided and you can directly call Restaurant.create() to create a new object. Also, a Helper class is provided to calculate the distance between two location, use Helper.get_distance(location1, location2).
    ///
    ///A GeoHash class is provided to convert a location to a string. Try GeoHash.encode(location) to convert location to a geohash string and GeoHash.decode(string) to convert a string to location.
    ///
    ///Example
    ///addRestauraunt("Lint Cafe", 10.4999999, 11.599999) // return 1
    ///addRestauraunt("Code Cafe", 10.4999999, 11.512109) // return 2
    ///neighbors(10.5, 11.6, 6.7) // return ["Lint Cafe"]
    ///removeRestauraunt(1)
    ///neighbors(10.5, 9.6, 6.7) // return []
    /// The distance between location(10.5, 11.6) and "Lint Code" is 0.0001099 km
    /// The distance between location(10.5, 11.6) and "Code Code" is 9.6120978 km    

    /// </summary>
    public class MiniYelp
    {
        Dictionary<int, Restaurant> restaurantTable;
        Dictionary<string, HashSet<int>> geoHashTable;    // geohash, restaurantID
        public MiniYelp()
        {
            restaurantTable = new Dictionary<int, Restaurant>();
            geoHashTable = new Dictionary<string, HashSet<int>>();
        }

        // @param name a string
        // @param location a Location
        // @return an integer, restaurant's id
        public int addRestaurant(string name, double lat, double lng)
        {
            LocationY location = new LocationY(lat, lng);
            Restaurant res = new Restaurant(name, location);  // restaurant auto generate id
            restaurantTable.Add(res.id, res);   // add to restaurant table

            // add different precision to geohash table
            string[] hashes = { res.hash6bit, res.hash5bit, res.hash4bit };

            foreach(var hash in hashes)
            {
                if (!geoHashTable.ContainsKey(hash))
                {
                    geoHashTable.Add(hash, new HashSet<int>());
                }
                geoHashTable[hash].Add(res.id);
            }
            

            return res.id;
        }

        // @param restaurant_id an integer
        public void removeRestaurant(int restaurant_id)
        {
            if (restaurantTable.ContainsKey(restaurant_id))
            {
                var res = restaurantTable[restaurant_id];
                // remove restaurant from geohash table
                string[] hashes = { res.hash6bit, res.hash5bit, res.hash4bit };

                foreach (var hash in hashes)
                {
                    if (geoHashTable.ContainsKey(hash))
                    {
                        geoHashTable[hash].Remove(res.id);      // remove from the hashset<id>

                        if (geoHashTable[hash].Count == 0)   //yic need to remove from the geotable if no such hash
                        {
                            geoHashTable.Remove(hash);
                        }
                    }
                }

                restaurantTable.Remove(restaurant_id);
            }
        }

        // @param location a Location
        // @param k an integer, distance smaller than k miles
        // @return a list of restaurant's name and sort by 
        // distance from near to far.
        public List<String> neighbors(double lat, double lng, double k)
        {
            LocationY location = new LocationY(lat, lng);
            SystemDesign.Geohash geohash = new SystemDesign.Geohash();
            var hash6bit = geohash.Encode(location.latitude, location.latitude, 6);
            string[] hashes = { hash6bit, hash6bit.Substring(0,5), hash6bit.Substring(0, 4) };

            int precisionLen = get_precisionlength(k);

            HashSet<int> restaurantsId = null;
            foreach(var hash in hashes)
            {
                if (geoHashTable.ContainsKey(hash) && precisionLen <= hash.Length)
                {
                    restaurantsId = geoHashTable[hash];
                    break;
                }
            }

            List<string> ans = new List<string> { };
            if (restaurantsId != null)
            {
                foreach(var id in restaurantsId)
                {
                    ans.Add(restaurantTable[id].name);
                }
            }

            return ans;
        }

        static int get_precisionlength(double k)
        {
            double[] ERROR = { 2500, 630, 78, 20, 2.4, 0.61, 0.076, 0.01911, 0.00478, 0.0005971, 0.0001492, 0.0000186 };
            for (int i = 0; i < 12; ++i)
                if (k > ERROR[i])
                    return i;
            return 12;
        }
    };

    public class LocationY
    {
        public double latitude, longitude;
        public LocationY(double lati, double longi)
         {
            this.latitude = lati;
            this.longitude = longi;
         }
    };
    
    public class Restaurant
     {
        public int id;
        public string name;
        public LocationY location;
        public string hash6bit;
        public string hash5bit;
        public string hash4bit;
        private static Random rdm = new Random();
        public Restaurant (string name, LocationY location)
        {
            id = rdm.Next(100);
            // and auto fill id

            this.name = name;
            this.location = location;

            SystemDesign.Geohash geohash = new SystemDesign.Geohash();
            hash6bit = geohash.Encode(location.latitude, location.latitude, 6);
            hash5bit = hash6bit.Substring(0, 5);
            hash4bit = hash6bit.Substring(0, 4);

        }
    };

    public class yelpHelper
     {
        public static double get_distance(LocationY location1, LocationY location2)
        {
            var tempLatDiff = location1.latitude - location2.latitude;
            var tempLngDiff = location1.longitude - location2.longitude;
            return Math.Sqrt(tempLatDiff * tempLatDiff + tempLngDiff * tempLngDiff);
        }
    };
    
}
