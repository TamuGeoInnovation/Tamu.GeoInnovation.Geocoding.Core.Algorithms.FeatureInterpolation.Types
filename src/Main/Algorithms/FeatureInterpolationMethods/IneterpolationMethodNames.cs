using System;
using System.Data;
using USC.GISResearchLab.Common.Utils.Strings;

namespace USC.GISResearchLab.Geocoding.Core.Algorithms.FeatureInterpolationMethods
{

    public enum InterpolationMethods
    {
        Unknown,
        LinearInterpolation,
        ArealInterpolation,
        ArealInterpolationWeighted,
    }

    public enum InterpolationType
    {
        Unknown,
        LinearInterpolation,
        ArealInterpolation,
        None,
        NotAttempted,
    }

    public enum InterpolationSubType
    {
        Unknown,
        LinearInterpolationAddressRange,
        LinearInterpolationUniformLot,
        LinearInterpolationActualLot,
        LinearInterpolationMidPoint,
        ArealInterpolationBoundingBoxCentroid,
        ArealInterpolationConvexHullCentroid,
        ArealInterpolationGeometricCentroid,
        None,
        NotAttempted,
    }


	/// <summary>
	/// Summary description for IneterpolationMethodNames.
	/// </summary>
    public class IneterpolationMethodNames
	{

		public const int METHOD_ADDRESS_RANGE = 0;
		public const int METHOD_UNIFORM_LOT_SIZE = 1;
		public const int METHOD_ACTUAL_LOT_SIZE = 2;
		public const int METHOD_ACTUAL_GEOMETRY = 3;
		
		public const int METHOD_ZIP_CODE_TABULATION_AREA_CENTROID = 4;
		public const int METHOD_CITY_CENTROID = 5;
		public const int METHOD_COUNTY_SUBREGION_CENTROID = 6;
		public const int METHOD_COUNTY_CENTROID = 7;
		public const int METHOD_STATE_CENTROID = 8;
        public const int METHOD_PARCEL_CENTROID = 9;
        public const int METHOD_POINT = 10;
        public const int METHOD_PARCEL_CENTROID_POINT = 11;

        public const int METHOD_USPS_ZIP_CODE_AREA_CENTROID = 12;
        public const int METHOD_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID = 13;
        public const int METHOD_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID = 14;
        public const int METHOD_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID = 15;
        public const int METHOD_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID = 16;
        public const int METHOD_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID = 17;

        public const int METHOD_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID = 18;
        public const int METHOD_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID = 19;

        public const int METHOD_DYNAMIC_FEATURE_COMPOSITION_CENTROID = 20;

        public const int METHOD_POLYGON_CENTROID = 21;


		public const string METHOD_NAME_ADDRESS_RANGE = "METHOD_ADDRESS_RANGE";
		public const string METHOD_NAME_UNIFORM_LOT_SIZE = "METHOD_UNIFORM_LOT_SIZE";
		public const string METHOD_NAME_ACTUAL_LOT_SIZE = "METHOD_ACTUAL_LOT_SIZE";
		public const string METHOD_NAME_ACTUAL_GEOMETRY = "METHOD_ACTUAL_GEOMETRY";

		public const string METHOD_NAME_ZIP_CODE_TABULATION_AREA_CENTROID = "METHOD_ZIP_CODE_TABULATION_AREA_CENTROID";
		public const string METHOD_NAME_CITY_CENTROID = "METHOD_CITY_CENTROID";
		public const string METHOD_NAME_COUNTY_SUBREGION_CENTROID = "METHOD_COUNTY_SUBREGION_CENTROID";
		public const string METHOD_NAME_COUNTY_CENTROID = "METHOD_COUNTY_CENTROID";
		public const string METHOD_NAME_STATE_CENTROID = "METHOD_STATE_CENTROID";
        public const string METHOD_NAME_PARCEL_CENTROID = "METHOD_PARCEL_CENTROID";
        public const string METHOD_NAME_PARCEL_CENTROID_POINT = "METHOD_PARCEL_CENTROID_POINT";
        public const string METHOD_NAME_POINT = "METHOD_POINT";
        public const string METHOD_NAME_POLYGON_CENTROID = "METHOD_POLYGON_CENTROID";


        public const string METHOD_NAME_USPS_ZIP_CODE_AREA_CENTROID = "METHOD_USPS_ZIP_CODE_AREA_CENTROID";
        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID";
        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID";
        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID";
        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID";
        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID";

        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID";
        public const string METHOD_NAME_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID = "METHOD_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID";

        public const string METHOD_NAME_DYNAMIC_FEATURE_COMPOSITION_CENTROID = "METHOD_DYNAMIC_FEATURE_COMPOSITION_CENTROID";


        public static DataTable GetAllInterpolationTypes()
        {
            DataTable ret = new DataTable();
            //ret.Columns.Add(new DataColumn("id", typeof(int)));
            //ret.Columns.Add(new DataColumn("name", typeof(string)));
            //ret.Columns.Add(new DataColumn("description", typeof(string)));
            ret.Columns.Add(new DataColumn("value", typeof(string)));

            //DataRow row = null;

            foreach (InterpolationType item in Enum.GetValues(typeof(InterpolationType)))
            {
                DataRow row = ret.NewRow();
                //row["id"] = (int)item;
                //row["name"] = GetInterpolationTypeName(item);
                row["value"] = item.ToString();
                ret.Rows.Add(row);
            }

            return ret;
        }

        public static DataTable GetAllInterpolationSubTypes()
        {
            DataTable ret = new DataTable();
            //ret.Columns.Add(new DataColumn("id", typeof(int)));
            //ret.Columns.Add(new DataColumn("name", typeof(string)));
            //ret.Columns.Add(new DataColumn("description", typeof(string)));
            ret.Columns.Add(new DataColumn("value", typeof(string)));

            //DataRow row = null;

            foreach (InterpolationSubType item in Enum.GetValues(typeof(InterpolationSubType)))
            {
                DataRow row = ret.NewRow();
                //row["id"] = (int)item;
                //row["name"] = GetInterpolationTypeName(item);
                row["value"] = item.ToString();
                ret.Rows.Add(row);
            }

            return ret;
        }
       
		public static int getMethodFromString(string s)
		{
			int ret = -1;
			s = s.ToLower();
			if ((s.Equals(METHOD_NAME_ADDRESS_RANGE.ToLower())) || (s.Equals("address range")) || (s.Equals("address-range")) || (s.Equals("range")) || (s.Equals("r")))
			{
				ret = METHOD_ADDRESS_RANGE;
			}
			else if ((s.Equals(METHOD_NAME_UNIFORM_LOT_SIZE.ToLower())) || (s.Equals("uniform lot size")) || (s.Equals("uniform lot")) || (s.Equals("uniform-lot")) || (s.Equals("uniform")) || (s.Equals("u")))
			{
				ret = METHOD_UNIFORM_LOT_SIZE;
			}
			else if ((s.Equals(METHOD_NAME_ACTUAL_LOT_SIZE.ToLower())) || (s.Equals("actual lot size"))  || (s.Equals("actual lot")) || (s.Equals("actual-lot")) || (s.Equals("actual")) || (s.Equals("a")))
			{
				ret = METHOD_ACTUAL_LOT_SIZE;
			}
			else if ((s.Equals(METHOD_NAME_ACTUAL_GEOMETRY.ToLower())) || (s.Equals("actual geometry"))  ||(s.Equals("actual-geometry")) || (s.Equals("geom")) || (s.Equals("g")))
			{
				ret = METHOD_ACTUAL_GEOMETRY;
			}

			else if ((s.Equals(METHOD_NAME_ZIP_CODE_TABULATION_AREA_CENTROID.ToLower())) || (s.Equals("zip code centroid"))  ||(s.Equals("zip")) || (s.Equals("z")))
			{
				ret = METHOD_ZIP_CODE_TABULATION_AREA_CENTROID;
			}
			else if ((s.Equals(METHOD_NAME_CITY_CENTROID.ToLower())) || (s.Equals("city centroid"))  ||(s.Equals("city")) || (s.Equals("cty")))
			{
				ret = METHOD_CITY_CENTROID;
			}
			else if ((s.Equals(METHOD_NAME_COUNTY_SUBREGION_CENTROID.ToLower())) || (s.Equals("county subregion centroid"))  ||(s.Equals("countysub")) || (s.Equals("cousbr")))
			{
				ret = METHOD_COUNTY_SUBREGION_CENTROID;
			}
			else if ((s.Equals(METHOD_NAME_COUNTY_CENTROID.ToLower())) || (s.Equals("county centroid"))  ||(s.Equals("county")))
			{
				ret = METHOD_COUNTY_CENTROID;
			}
			else if ((s.Equals(METHOD_NAME_STATE_CENTROID.ToLower())) || (s.Equals("state centroid"))  ||(s.Equals("state")) || (s.Equals("s")))
			{
				ret = METHOD_STATE_CENTROID;
			}
            else if ((s.Equals(METHOD_NAME_PARCEL_CENTROID.ToLower())) || (s.Equals("parcel centroid")))
            {
                ret = METHOD_PARCEL_CENTROID;
            }
            else if ((s.Equals(METHOD_NAME_PARCEL_CENTROID_POINT.ToLower())) || (s.Equals("parcel centroid point")))
            {
                ret = METHOD_PARCEL_CENTROID_POINT;
            }



            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_AREA_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_AREA_CENTROID;
            }
            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID;
            }
            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID;
            }
            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID;
            }
            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID;
            }
            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID;
            }

            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID;
            }
            else if (String.Compare(s, METHOD_NAME_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID, true) == 0)
            {
                ret = METHOD_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID;
            }

            else if (String.Compare(s, METHOD_NAME_DYNAMIC_FEATURE_COMPOSITION_CENTROID, true) == 0)
            {
                ret = METHOD_DYNAMIC_FEATURE_COMPOSITION_CENTROID;
            }

			return ret;
		}

		public static bool validateMethod(string method)
		{
			// return true if method is blank or a valid one
			bool ret = true;
			if (!StringUtils.IsEmpty(method))
			{
				int methodInt = getMethodFromString(method);
				if (methodInt < 0)
				{
					ret = false;
				}
			}
			return ret;
		}

		public static int getMethod(string method)
		{
			// method will default to address range unless otherwise specified
			int ret;
			if (StringUtils.IsEmpty(method))
			{
				ret = METHOD_ADDRESS_RANGE;
			}
			else
			{
				ret = getMethodFromString(method);
			}
			return ret;
		}

		public static string getMethodstringFromInt(int i)
		{
			string ret = "";
			switch (i)
			{
				case METHOD_ADDRESS_RANGE:
					ret = METHOD_NAME_ADDRESS_RANGE;
					break;
				case METHOD_UNIFORM_LOT_SIZE:
					ret = METHOD_NAME_UNIFORM_LOT_SIZE;
					break;
				case METHOD_ACTUAL_LOT_SIZE:
					ret = METHOD_NAME_ACTUAL_LOT_SIZE;
					break;
				case METHOD_ACTUAL_GEOMETRY:
					ret = METHOD_NAME_ACTUAL_GEOMETRY;
					break;
				case METHOD_ZIP_CODE_TABULATION_AREA_CENTROID:
					ret = METHOD_NAME_ZIP_CODE_TABULATION_AREA_CENTROID;
					break;
				case METHOD_CITY_CENTROID:
					ret = METHOD_NAME_CITY_CENTROID;
					break;
				case METHOD_COUNTY_SUBREGION_CENTROID:
					ret = METHOD_NAME_COUNTY_SUBREGION_CENTROID;
					break;
				case METHOD_COUNTY_CENTROID:
					ret = METHOD_NAME_COUNTY_CENTROID;
					break;
				case METHOD_STATE_CENTROID:
					ret = METHOD_NAME_STATE_CENTROID;
					break;
                case METHOD_PARCEL_CENTROID:
                    ret = METHOD_NAME_PARCEL_CENTROID;
                    break;
                case METHOD_PARCEL_CENTROID_POINT:
                    ret = METHOD_NAME_PARCEL_CENTROID_POINT;
                    break;
                case METHOD_POLYGON_CENTROID:
                    ret = METHOD_NAME_POLYGON_CENTROID;
                    break;

                case METHOD_USPS_ZIP_CODE_AREA_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_AREA_CENTROID;
                    break;

                case METHOD_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_1_AREA_CENTROID;
                    break;
                case METHOD_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_2_AREA_CENTROID;
                    break;
                case METHOD_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_3_AREA_CENTROID;
                    break;
                case METHOD_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_4_AREA_CENTROID;
                    break;
                case METHOD_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_5_AREA_CENTROID;
                    break;

                case METHOD_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_4_LINE_CENTROID;
                    break;
                case METHOD_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID:
                    ret = METHOD_NAME_USPS_ZIP_CODE_PLUS_5_LINE_CENTROID;
                    break;

                case METHOD_DYNAMIC_FEATURE_COMPOSITION_CENTROID:
                    ret = METHOD_NAME_DYNAMIC_FEATURE_COMPOSITION_CENTROID;
                    break;

				default:
					break;
			}
			return ret;
		}


		public static string getMethodListFromIntArray(int[] methods)
		{
			string ret = "";
			for (int i=0; i<methods.Length; i++)
			{
				ret += getMethodstringFromInt(methods[i]) + ", ";
			}
			ret = StringUtils.TrimCSVList(ret);
			return ret;
		}

		public static bool methodIsSupported(int method, int[] methodList)
		{
			bool ret = false;
			for (int i=0; i< methodList.Length; i++)
			{
				if (method == methodList[i])
				{
					ret = true;
				}
			}
			return ret;
		}
	}
}
