using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.XPath;

namespace Acme.Portal.Core.Utils
{
    public static class Extensions
    {
        public static void AssertNotNull(this object o, string error = "A not null assertion failed")
        {
            if (o == null)
                throw new Exception(error);
        }

        public static T SingleOrError<T>(this DbSet<T> input, Expression<Func<T, bool>> func, string error) where T : class
        {
            
            T result = input.SingleOrDefault(func);
            if (result == null)
                throw new Exception(error);
            return result;
        }

        public static T SingleOrError<T>(this DbSet<T> input, string error) where T : class
        {
            T result = input.SingleOrDefault();
            if (result == null)
                throw new Exception(error);
            return result;
        }

        public static T SingleOrError<T>(this IQueryable<T> input, string error) where T : class
        {
            T result = input.SingleOrDefault();
            if (result == null)
                throw new Exception(error);
            return result;
        }

        public static T SingleOrError<T>(this IEnumerable<T> input, string error) where T : class
        {
            T result = input.SingleOrDefault();
            if (result == null)
                throw new Exception(error);
            return result;
        }
        public static T SingleOrError<T>(this IEnumerable<T> input, Func<T, bool> func, string error) where T : class
        {
            T result = input.SingleOrDefault(func);
            if (result == null)
                throw new Exception(error);
            return result;
        }
        public static T FirstOrError<T>(this DbSet<T> input, Expression<Func<T, bool>> func, string error) where T : class
        {
            T result = input.FirstOrDefault(func);
            if (result == null)
                throw new Exception(error);
            return result;
        }
        
        public static T FirstOrError<T>(this IEnumerable<T> input, Func<T, bool> func, string error) where T : class
        {
            T result = input.FirstOrDefault(func);
            if (result == null)
                throw new Exception(error);
            return result;
        }

        public static T FirstOrError<T>(this DbSet<T> input, string error) where T : class
        {
            T result = input.FirstOrDefault();
            if (result == null)
                throw new Exception(error);
            return result;
        }

        public static T FirstOrError<T>(this IEnumerable<T> input, string error) where T : class
        {
            T result = input.FirstOrDefault();
            if (result == null)
                throw new Exception(error);
            return result;
        }
        public static void RemoveNilAttribute(this XPathNavigator node)
        {
            if (node.MoveToAttribute("nil", "http://www.w3.org/2001/XMLSchema-instance"))
                node.DeleteSelf();
        }
        public static void SetNilAttribute(this XPathNavigator node)
        {
            if (!node.MoveToAttribute("nil", "http://www.w3.org/2001/XMLSchema-instance"))
            {
                node.CreateAttribute("xsi", "nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
            }
        }
        
        public static void AssertNotNullOrEmpty(this string o, string name="A not null/empty assertion failed")
        {
            if (string.IsNullOrEmpty(o))
                throw new ArgumentNullException(name);
        }

        public static bool IsInteger(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            try
            {
                var x = int.Parse(input.Trim());
                return true;
            }
            catch   //REFACTOR: Use TryParse to avoid the try/catch
            {
                return false;
            }
        }
        public static string StripDomainPrecursor(this string input)
        {
            input.AssertNotNull("input");
            if (input.IndexOf("\\") > 0)
            {
                input = input.Substring(input.IndexOf("\\") + 1);
            }
            return input;
        }

//        public static void Throw(this HttpResponseMessage response)
//        {
//            throw new HttpResponseException(response);
//        }

        public static long ToLong(this string s, long defaultValue = 0)
        {
            try
            {
                return long.Parse(s);
            }
            catch   //REFACTOR: Use TryParse to avoid the try/catch
            {
                return defaultValue;
            }
        }

        public static short ToShort(this string s, short defaultValue = 0)
        {
            try
            {
                return short.Parse(s);
            }
            catch   //REFACTOR: Use TryParse to avoid the try/catch
            {
                return defaultValue;
            }
        }

        public static int ToInt(this string s, int defaultValue = 0)
        {
            try
            {
                return int.Parse(s);
            }
            catch   //REFACTOR: Use TryParse to avoid the try/catch
            {
                return defaultValue;
            }
        }


        /// <summary>
        /// Convert from old style Microsoft.IdentityModel.Claims.IClaimsIdentity to System.Security.Claims.ClaimsPrincipal
        /// </summary>
//        public static System.Security.Claims.ClaimsIdentity GetClaimsIdentityFrom45Identity()
//        {
//            //Microsoft.IdentityModel.ClaimsIdentity contains all the claims we want to pass in the token
//            var oldVersionClaimsIdentity = Thread.CurrentPrincipal.Identity as Microsoft.IdentityModel.Claims.IClaimsIdentity;
//            oldVersionClaimsIdentity.AssertNotNull("Unable to cast Thread.CurrentPrincipal.Identity as Microsoft.IdentityModel.Claims.IClaimsIdentity. The cast failed. Is this running in an SP 2013 environment?");
//
//            //System.IdentityModel.Claims.ClaimsIdentity is the identity we use to build the token
//            var result = ClaimsPrincipal.Current.Identities.First();
//
//            //move claims from the old version identity in to the new version identity
//            foreach (var claim in oldVersionClaimsIdentity.Claims)
//            {
//                if (!result.Claims.Any(x => x.Type == claim.ClaimType))
//                {
//                    var newClaim = new System.Security.Claims.Claim(claim.ClaimType, claim.Value, claim.ValueType);
//                    result.AddClaim(newClaim);
//                }
//            }
//            return result;
//        }

        /// <summary>
        /// Convert all the validation errors from model state dictionary in to a single string
        /// </summary>
        /// <param name="modelStateDictionary"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
//        public static string ErrorMessages(this ModelStateDictionary modelStateDictionary, string separator = ", ")
//        {
//            var sb = new StringBuilder();
//            foreach (var v in modelStateDictionary.Values)
//            {
//                foreach (var error in v.Errors)
//                {
//                    sb.Append(error.ErrorMessage + separator);
//                }
//            }
//            return sb.ToString();
//        }

        /// <summary>
        /// Returns a string that is a list of validation errors for the ModelStateDictionary 
        /// used in Web API.
        /// </summary>
        /// <param name="state">The ModelStateDictionary (Web API version)</param>
        /// <param name="separator">String to use in separating the errors</param>
        /// <returns>String of errors with delimited by separator</returns>
//        public static string ErrorMessages(this System.Web.Http.ModelBinding.ModelStateDictionary state, string separator = "; ")
//        {
//            var errors = "";
//            if (!state.IsValid)
//            {
//                errors = string.Join(
//                    separator, 
//                    state.Values
//                        .SelectMany(s => s.Errors)
//                        .Select(e => e.ErrorMessage)
//                );
//            }
//            return errors;
//        }

        public static string GetStringFromEmbeddedResource(string resourceName) { return GetStringFromEmbeddedResource(resourceName, typeof(Extensions).Assembly); }

        public static string GetStringFromEmbeddedResource(string resourceName, Assembly assembly)
        {
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                stream.AssertNotNull("The resource path [" + resourceName + "] returned nothing");
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string FormatString(this string input, params object[] vals)
        {
            return string.Format(input, vals);
        }

        public static string GetValueAsString(this Hashtable hashtable, string key)
        {
            if(!hashtable.ContainsKey(key))
                throw new Exception(string.Format("Unable to get the value: [{0}]", key));
            return ((string) hashtable[key] ?? string.Empty);
        }

        public static int GetValueAsInt(this Hashtable hashtable, string key)
        {
            if(!hashtable.ContainsKey(key))
                throw new Exception(string.Format("Unable to get the value: [{0}]", key));
            return (int)hashtable[key];
        }

        public static string ToHtmlList(this NameValueCollection input)
        {
            var sb = new StringBuilder("<ul>");
            foreach (var key in input.AllKeys)
            {
                sb.AppendFormat("<li>{0}: <b>{1}</b></li>", key, input[key]);
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public static string ToKeyValuePairString(this NameValueCollection input)
        {
            return string.Join("|", input.AllKeys.Select(x => string.Format("[{0}:{1}]", x, input[x])).ToArray());
        }
        
        /// <summary>
        /// Truncate a string to ensure a max length is not violated. OPTIONALLY add some trailing characters to make the truncation a little more graceful
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="length">The length.</param>
        /// <param name="trailingChars">The trailing chars. For example, an ellipsis ...</param>
        /// <returns></returns>
        public static string Truncate(this string input, int length, string trailingChars = null)
        {
            if (input == null)
            {
                return string.Empty;
            }
            if (input.Length > length)
            {
                var result = input.Substring(0, length - 1);
                if (trailingChars != null)
                {
                    result += trailingChars;
                }
                return result;
            }
            return input;
        }

        /// <summary>
        /// returns datetime converted from UTC to Central
        /// </summary>
        /// <param name="dateUtc"></param>
        /// <returns></returns>
        public static DateTime ToCentralTime(this DateTime dateUtc)
        {
            string toTimeZoneDesc = "Central Standard Time";
            var toUtcOffset = TimeZoneInfo.FindSystemTimeZoneById(toTimeZoneDesc).GetUtcOffset(dateUtc);
            return DateTime.SpecifyKind(dateUtc.Add(toUtcOffset), DateTimeKind.Unspecified);
        }
        /// <summary>
        /// Returns a day suffix such as "st", "nd", or "th"
        /// </summary>
        public static string GetDaySuffix(this DateTime date)
        {
            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }


        /// <summary>
        /// returns value of an enum [Description("")] attribute
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof (DescriptionAttribute)) as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }
            return string.Empty;
        }

        /// <summary>
        /// returns value of an enum [Percentage(#)] attribute
        /// </summary>
//        public static short GetPercentage(this Enum value)
//        {
//            var fieldInfo = value.GetType().GetField(value.ToString());
//            if (fieldInfo != null)
//            {
//                var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(PercentageAttribute)) as PercentageAttribute;
//                return attribute == null ? short.MinValue : attribute.Percentage;
//            }
//            return short.MinValue;
//        }

        /// <summary>
        /// returns value of an enum [ToolTip("")] attribute
        /// </summary>
//        public static string GetToolTipDescription(this Enum value)
//        {
//            var fieldInfo = value.GetType().GetField(value.ToString());
//            if (fieldInfo != null)
//            {
//                var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof (ToolTipAttribute)) as ToolTipAttribute;
//                return attribute == null ? value.ToString() : attribute.Description;
//            }
//            return string.Empty;
//        }

        /*
         * Commented out by pete - because of time zones this needs to be executed on the client side
        /// <summary>
        /// returns tooltip for a batch run Frequency value
        /// </summary>
        public static string GetFrequencyToolTip(this EligibilityBatchFrequency frequency, DateTime? nextRunDate = null)
        {
            if (frequency == EligibilityBatchFrequency.NonRecurring)
                return "Non-recurring batch";
            if (!nextRunDate.HasValue)
                return "No run scheduled";

            var recurrence = string.Empty;
            var timeOfDay = nextRunDate.Value.ToString("s");
            var dayOfWeek = nextRunDate.Value.DayOfWeek.ToString();
            var dayOfMonth = nextRunDate.Value.Day;
            var daySuffix = nextRunDate.Value.GetDaySuffix();

            switch (frequency)
            {
                case EligibilityBatchFrequency.Weekdays:
                    recurrence = string.Format("Weekdays at []", timeOfDay);
                    break;
                case EligibilityBatchFrequency.Weekly:
                    recurrence = string.Format("Weekly on {0} at []", dayOfWeek, timeOfDay);
                    break;
                case EligibilityBatchFrequency.BiWeekly:
                    recurrence = string.Format("Bi-Weekly" + " on {0} at []", dayOfWeek, timeOfDay);
                    break;
                case EligibilityBatchFrequency.Monthly:
                    recurrence = string.Format("Monthly on the {0} at []", String.Concat(dayOfMonth,daySuffix), timeOfDay);
                    break;
                case EligibilityBatchFrequency.Quarterly:
                    recurrence = string.Format("Quarterly @ []. Next run is on {1}", timeOfDay, nextRunDate.Value.ToShortDateString());
                    break;
                case EligibilityBatchFrequency.Annual:
                    recurrence = string.Format("Yearly on {0} at []", nextRunDate.Value.Date.ToShortDateString(), timeOfDay);
                    break;
            }
            return recurrence;
        }
         */

        /// <summary>
        /// returns value of an enum [ImageURL("")] attribute
        /// </summary>
//        public static string GetImageURL(this Enum value)
//        {
//            var fieldInfo = value.GetType().GetField(value.ToString());
//            if (fieldInfo != null)
//            {
//                var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(ImageURLAttribute)) as ImageURLAttribute;
//                return attribute == null ? value.ToString() : attribute.ImageURL;
//            }
//            return string.Empty;
//        }

        /// <summary>
        /// returns value of an enum [SmallImageURL("")] attribute
        /// </summary>
//        public static string GetSmallImageURL(this Enum value)
//        {
//            var fieldInfo = value.GetType().GetField(value.ToString());
//            if (fieldInfo != null)
//            {
//                var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(SmallImageURLAttribute)) as SmallImageURLAttribute;
//                return attribute == null ? value.ToString() : attribute.SmallImageURL;
//            }
//            return string.Empty;
//        }

        /// <summary>
        /// returns value of an enum [GreyImageURL("")] attribute
        /// </summary>
//        public static string GetGreyImageURL(this Enum value)
//        {
//            var fieldInfo = value.GetType().GetField(value.ToString());
//            if (fieldInfo != null)
//            {
//                var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(GreyImageURLAttribute)) as GreyImageURLAttribute;
//                return attribute == null ? value.ToString() : attribute.GreyImageURL;
//            }
//            return string.Empty;
//        }


        /// <summary>
        /// Delete an object from the database without loading it
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <typeparam name="IdT">id type</typeparam>
        /// <param name="dbContext">the repository</param>
        /// <param name="idFunc">the function for retrieving id property</param>
        /// <param name="target">the target Ids</param>
        public static void DeletePersistedObjects<T, IdT>(this DbSet<T> dbContext, Expression<Func<T, IdT>> idFunc, IEnumerable<IdT> targets) where T : class, new()
        {
            foreach (var target in targets)
            {
                dbContext.DeletePersistedObject(idFunc,target);
            }
        }

        /// <summary>
        /// Delete an object from the database without loading it
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <typeparam name="IdT">id type</typeparam>
        /// <param name="dbContext">the repository</param>
        /// <param name="idFunc">the function for retrieving id property</param>
        /// <param name="target">the target Id</param>
        public static void DeletePersistedObject<T, IdT>(this DbSet<T> dbContext, Expression<Func<T, IdT>> idFunc, IdT target) where T : class, new()
        {
            var x = new T();
            var propInfo = ((MemberExpression) idFunc.Body).Member as PropertyInfo;
            propInfo.AssertNotNull("The id function doesnt yield a property");
            propInfo.SetValue(x,target);
            dbContext.Attach(x);
            dbContext.Remove(x);
        }

        /// <summary>
        /// Parse a CSV-based string into a datatable
        /// </summary>
        /// <param name="csvFile"></param>
        /// <returns></returns>
//        public static DataTable ConvertCsvToDataTable(this Stream csvFile)
//        {
//            var result = new DataTable();
//            using (var csvReader = new CsvReader(new StreamReader(csvFile), true))
//            {
//                try
//                {
//                    result.Load(csvReader);
//                }
//                catch (ArgumentException exp)   //REFACTOR: the caught exception should be made the inner exception
//                {
//                    if(exp.Message=="An item with the same key has already been added.")
//                        throw new CsvParserException("Duplicate column headers are not allowed.");
//                }
//                catch (Exception exp)   //REFACTOR: the caught exception should be made the inner exception
//                {
//                    throw new CsvParserException(string.Format("Csv parsing failed: [{0}]", exp.ToString()));
//                }
//            }
//            return result;
//        }

        /// <summary>
        /// Convert an enumeration into a collection of select list items
        /// </summary>
        /// <typeparam name="EnumType"></typeparam>
        /// <returns></returns>
//        public static List<SelectListItem> GetSelectListItemsForEnumeration<EnumType>() 
//        {
//            var result = new List<SelectListItem>();
//            foreach (EnumType item in Enum.GetValues(typeof(EnumType)))
//            {
//                var i = item as Enum;
//                var selectItem = new SelectListItem() { Text = i.GetDescription(), Value = item.ToString() };
//                result.Add(selectItem);
//            }
//            return result;
//        } 

        /// <summary>
        /// Advanced coalese operator
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="input"></param>
        /// <param name="eval"></param>
        /// <returns></returns>
        public static TResult With<TResult, TInput>(this TInput input, Func<TInput, TResult> eval, TResult defaultVal = default(TResult))  where TInput : class 
        {
            if (input == null) 
                return defaultVal;
            return eval(input);
        }

        /// <summary>
        /// When building a CSV, make sure that the contents are properly formatted.
        /// This method accepts a string and adds all the necessary escape characters for the escape format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToCsvFormat(this string input)
        {
            input = input ?? "";
            var sb = new StringBuilder();
            var needQuotes = false;
            foreach (char c in input.ToArray())
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); needQuotes = true; break;
                    case ' ': sb.Append(" "); needQuotes = true; break;
                    case ',': sb.Append(","); needQuotes = true; break;
                    case '\t': sb.Append("\\t"); needQuotes = true; break;
                    case '\n': sb.Append("\\n"); needQuotes = true; break;
                    default: sb.Append(c); break;
                }
            }
            if (needQuotes)
                return "\"" + sb.ToString() + "\"";
            else
                return sb.ToString();
        }


        /// <summary>
        /// Given a connection string, execute a DB action
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="connectionAction"></param>
        public static void ExecuteDbAction(this string connectionString, Action<SqlConnection> connectionAction)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                connectionAction(sqlConnection);
            }
        }

        /// <summary>
        /// returns value of an enum [EligibilitySummaryColor("")] attribute
        /// </summary>
//        public static string GetEligibilitySummaryColor(this Enum value)
//        {
//            var fieldInfo = value.GetType().GetField(value.ToString());
//            var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(EligibilitySummaryColorAttribute)) as EligibilitySummaryColorAttribute;
//
//            return attribute == null ? value.ToString() : attribute.ColorClass;
//        }

        /// <summary>
        /// Extracts a meaningful message from an exception, using inner exceptions where appropriate.
        /// </summary>
        /// <param name="ex">The Exception to get the message from</param>
        /// <returns>
        /// The deepest nested inner exception message
        /// </returns>
        public static string GetMessage(this Exception ex)
        {
            var currentException = ex;
            while (currentException.InnerException != null)
            {
                currentException = currentException.InnerException;
            }
            return currentException.Message;
        }

        public static double DegreesToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double RadiansToDegrees(this double radians)
        {
            return radians * (180 / Math.PI);
        }

        public static double MilesToKilometers(this double miles)
        {
            return miles * 1.609;
        }

        public static double KilometersToMiles(this double kilometers)
        {
            return kilometers * .6214;
        }

        public static string ToDateString(this DateTime date)
        {
            return string.Format("{0:s}",date);
        }


        /// <summary>
        /// Get string from XML attribute - throw exception if something goes wrong
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        /// <exception cref="System.Configuration.ConfigurationFileMap">Expected attribute [+attributeName+] which was not supplied</exception>
        public static string GetStringFromAttribute(this XmlAttributeCollection input, string attributeName)
        {
            try
            {
                return input[attributeName].Value;
            }
            catch (Exception exp)
            {
                throw new ConfigurationErrorsException("Expected attribute [" + attributeName + "] which was not supplied");
            }
        }

        /// <summary>
        /// Get string from XML attribute - return default if something goes wrong
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        /// <exception cref="System.Configuration.ConfigurationFileMap">Expected attribute [+attributeName+] which was not supplied</exception>
        public static string TryGetStringFromAttribute(this XmlAttributeCollection input, string attributeName, string defaultVal)
        {
            try
            {
                return input[attributeName].Value;
            }
            catch
            {
                return defaultVal;
            }
        }

        /// <summary>
        /// Get integer from XML attribute - throw exception if something goes wrong
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns></returns>
        /// <exception cref="System.Configuration.ConfigurationFileMap">Expected attribute [+attributeName+] which was not supplied</exception>
        public static int GetIntFromAttribute(this XmlAttributeCollection input, string attributeName)
        {
            try
            {
                return int.Parse(input[attributeName].Value);
            }
            catch
            {
                throw new ConfigurationErrorsException("Expected integer attribute [" + attributeName + "] which was not supplied");
            }
        }

        /// <summary>
        /// Gets a random element from a generic list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="random">The random.</param>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static T GetRandomElementFromList<T>(this Random random, List<T> list)
        {
            return list[random.Next(list.Count)];
        }

        /// <summary>
        /// Get a value from a dictionary. If not found return a default value instead.
        /// </summary>
        /// <typeparam name="K">Key Type</typeparam>
        /// <typeparam name="V">Value Type</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="keyVal">The key.</param>
        /// <param name="defaultIfNotFound">The default val if not found.</param>
        /// <returns></returns>
        public static V GetValueOrDefault<K, V>(this Dictionary<K, V> input, K keyVal, V defaultIfNotFound)
        {
            try
            {
                return input[keyVal];
            }
            catch (KeyNotFoundException exception)
            {
                return defaultIfNotFound;
            }
        }

        public static string ToStringYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        public static string ToReferralTime(this DateTime? date)
        {
            var retVal = "";
            if (date.HasValue)
            {
                var diff = date.Value - DateTime.UtcNow;
                var diffTotal = (diff.Days*360) + (diff.Hours*60) + diff.Minutes;
                var diffDays = Math.Abs(diff.Days) + (Math.Abs(diff.Hours) >= 12 ? 1 : 0);
                var diffHours = (Math.Abs(diff.Days) * 24) + Math.Abs(diff.Hours) + (Math.Abs(diff.Minutes) >= 30 ? 1 : 0);
                var diffMinutes = (Math.Abs(diff.Days) * 1440) + (Math.Abs(diff.Hours) * 60) + Math.Abs(diff.Minutes);
                
                var minuteVal = -1;
                if (diffMinutes < 60)
                {
                    if (diffMinutes >= 1 && diffMinutes <= 15)
                        minuteVal = 15;

                    if (diffMinutes >= 16 && diffMinutes <= 30)
                        minuteVal = 30;

                    if (diffMinutes >= 31 && diffMinutes <= 45)
                        minuteVal = 45;
                }

                if (minuteVal == -1 && diffHours == 0)
                {
                    retVal = "OVERDUE";
                }
                else
                {
                    if (diffTotal <= 0)
                    {
                        if (diffMinutes > 0 && diffMinutes < 46)
                            retVal = string.Format("{0} min OVERDUE", minuteVal);

                        if (diffHours < 48 && diffMinutes > 45)
                            retVal = string.Format("{0} hr{1} OVERDUE", diffHours, diffHours > 1 ? "s" : "");

                        if (diffHours >= 48)
                            retVal = string.Format("{0} days OVERDUE", diffDays);
                    }
                    else
                    {
                        if (diffMinutes > 0 && diffMinutes < 46)
                            retVal = string.Format("{0} min", minuteVal);

                        if (diffHours < 48 && diffMinutes > 45)
                            retVal = string.Format("{0} hr{1}", diffHours, diffHours > 1 ? "s" : "");

                        if (diffHours >= 48)
                            retVal = string.Format("{0} days", diffDays);
                    }
                }

                if (diffTotal <= 120)
                    retVal = "<span class='maWarning'>" + retVal + "</span>";
                else
                    retVal = "<strong>" + retVal + "</strong>";
            }
            return retVal;
        }

//        public static void Validate(this object obj, bool notNull = false)
//        {
//            var results = obj.ValidateAndReturnResults(notNull);
//            if (results != null && results.Any())
//                throw new ValidationFailureException(results);
//        }

//        public static IEnumerable<ValidationResult> ValidateAndReturnResults(this object obj, bool notNull = false)
//        {
//            if (obj == null && !notNull)
//                return null;
//
//            var results = new List<ValidationResult>();
//            if (obj == null)
//            {
//                results.Add(new ValidationResult("Non-null value expected.", new string[] { }));
//                return results;
//            }
//
//            var context = new ValidationContext(obj);
//            Validator.TryValidateObject(obj, context, results);
//            return results;
//        }
    }
}
