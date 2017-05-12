using SparkServer.Core.Repositories;
using SparkServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.Application
{
    public static class FilterData
    {
        public static List<SelectListItem> Authors(IAuthorRepository<Author> authorRepo, int? selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            IEnumerable<Author> sourceList = authorRepo.GetAll().OrderBy(u => u.FirstName).ThenBy(u => u.LastName);

            list.Add(new SelectListItem() { Value = string.Empty, Text = string.Empty });

            foreach (Author item in sourceList)
            {
                SelectListItem listItem = new SelectListItem()
                {
                    Value = item.ID.ToString(),
                    Text = string.Format($"{item.FirstName} {item.LastName}")
                };

                if (item.ID == selected)
                {
                    listItem.Selected = true;
                }

                list.Add(listItem);
            }

            return list;
        }
    }
}