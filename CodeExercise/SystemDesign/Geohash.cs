using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    class Geohash
    {
        /// <summary>
        /// lint 529
        /// http://www.lintcode.com/en/problem/geohash/
        /// 
        /// Geohash is a hash function that convert a location coordinate pair into a base32 string.
        /// 
        /// Check how to generate geohash on wiki: Geohash or just google it for more details.
        /// 
        /// Try http://geohash.co/.
        /// 
        /// You task is converting a (latitude, longitude) pair into a geohash string.
        /// 
        /// Example
        /// Given lat = 39.92816697, lng = 116.38954991 and precision = 12 which indicate how long the hash string should be.
        /// You should return wx4g0s8q3jf9.
        /// 
        /// The precision is between 1 ~ 12.
        /// 
        /// 
        /// sol:
        /// 
        /// precision = 12 means 12 chars   and each char is base32   meaning 5bits.  so  total needs 5*12 = 60  and interleave by lat and lng
        /// so the recursive divide need 30 times for lat and lng
        /// 
        /// lat start from -90 ~ 90
        /// lng start from -180 ~ 180
        /// 
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public String Encode(double latitude, double longitude, int precision)
        {
            int rounds = (precision) * 5 / 2;  // 30
            string encodeStr = "";
            double lngLower = -180.0;
            double lngUpper = 180.0;
            double latLower = -90.0;
            double latUpper = 90.0;
            

            for (int i = 0; i < rounds; i++)
            {
                // lng first 
                if (findBits(longitude, lngLower, lngUpper))
                {
                    encodeStr += "1";
                    lngLower = (lngLower + lngUpper)/ 2;
                }
                else
                {
                    encodeStr += "0";
                    lngUpper = (lngLower + lngUpper) / 2;
                }

                // then lat
                if (findBits(latitude, latLower, latUpper))
                {
                    encodeStr += "1";
                    latLower = (latLower + latUpper)/ 2;
                }
                else
                {
                    encodeStr += "0";
                    latUpper = (latLower + latUpper) / 2;
                }
            }


            String base32Lookup = "0123456789bcdefghjkmnpqrstuvwxyz";//0-9a-z without ailo
            string convertStr = "";
            for (int i = 0; i <2*rounds; i+=5)
            {
                int num = 0;
                for(int j=i; j<i+5;j++)
                {
                    if (encodeStr[j] == '1')
                    {
                        num = num * 2 + 1;
                    }
                    else
                    {
                        num *= 2;
                    }
                }

                var c = base32Lookup[num];
                convertStr += c;
            }

            return convertStr;
        }

        private bool findBits(double num, double lower, double upper)
        {
            double mid = lower + (upper - lower) / 2;
            if (num >= mid)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Given "wx4g0s", return lat = 39.92706299 and lng = 116.39465332.
        /// Return double[2], first double is latitude and second double is longitude.
        /// </summary>
        /// <param name="geohash"></param>
        /// <returns></returns>
        public double[] Decode(String geohash)
        {
            String base32Lookup = "0123456789bcdefghjkmnpqrstuvwxyz";//0-9a-z without ailo
            

            string rawBinary = "";
            foreach (char c in geohash)
            {
                int num =base32Lookup.IndexOf(c);
                string bin = itoa(num);
                rawBinary += bin;
            }

            double lngLower = -180.0;
            double lngUpper = 180.0;
            double latLower = -90.0;
            double latUpper = 90.0;

            bool isLng = true;
            for (int i = 0; i <rawBinary.Length ; i++)
            {
                if (isLng)
                {
                    if (rawBinary[i] == '1')
                    {
                        lngLower = (lngLower + lngUpper) / 2;
                    }
                    else
                    {
                        lngUpper = (lngLower + lngUpper) / 2;
                    }
                }
                else
                {
                    if (rawBinary[i] == '1')
                    {
                        latLower = (latLower + latUpper) / 2;
                    }
                    else
                    {
                        latUpper = (latLower + latUpper) / 2;
                    }
                }
                isLng = !isLng;
            }

            //List<double> ans = new List<double>() { (latLower + latUpper) / 2, (lngLower + lngUpper) / 2 };
            double[] ans = { (latLower + latUpper) / 2, (lngLower + lngUpper) / 2 };

            return ans;

        }

        private string itoa(int num)
        {
            string res = "";
            for(int i = 0; i < 5; i++)
            {
                res = (num % 2 == 0 ? "0" : "1") + res;    // yic note put to front
                num /= 2;
            }
            return res;
        }
    }
}
