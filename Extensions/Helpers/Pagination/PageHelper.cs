using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace story.Extensions.Helpers.Pagination
{
    public static class PageHelper
    {
        public static int ReturnDefaultValuePageCurrent(int pageCurrent)
        {
            int resutl = pageCurrent;

            if(pageCurrent == 0 || string.IsNullOrEmpty(pageCurrent.ToString()))
            {
                resutl = 1;
            }

            return resutl;
        }

        public static int ReturnDefaultValuePageSize(int pageSize)
        {
            int resutl = pageSize;

            if (pageSize == 0 || string.IsNullOrEmpty(pageSize.ToString()))
            {
                resutl = 10;
            }

            return resutl;
        }

        public static string ReturnPageCurrentPagination(string pagePath, string queryString)
        {
            string result = "";

            // index?page=1&pageSize=10&search=13
            if (!string.IsNullOrEmpty(queryString) && queryString.IndexOf("&page=") == -1)
            {
                result = queryString + "&page=";
            }
            else if(queryString.IndexOf("&page=") != -1)
            {
                string[] arrQueryString = queryString.Split("&");

                int countQueryString = arrQueryString.Count();

                for(int i = 0; i < countQueryString; i++)
                {
                    if (arrQueryString[i].IndexOf("page=") != -1)
                    {
                        arrQueryString[i] = "";
                    }
                }

                result = string.Join("&", arrQueryString) + "page=";
            }
            else if(queryString.IndexOf("?page=") != -1)
            {
                Regex regex = new Regex("page=\\d+");

                result = regex.Replace(queryString, "?page=");
            }
            else 
            {
                result = "?page=";
            }
            return result;
        }
    }
}
