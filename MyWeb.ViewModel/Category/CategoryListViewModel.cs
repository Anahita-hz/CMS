﻿using System.Collections.Generic;
using System.Web.Mvc;
using MyWeb.ViewModel.Common;
using MyWeb.ViewModel.Post;

namespace MyWeb.ViewModel.Category
{
    public class CategoryListViewModel
    {
        public CategoryListViewModel()
        {
            #region SortOrderList

            SortOrderList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = SortDirectionMode.Desc,
                    Text = "نزولی"

                },
                new SelectListItem
                {
                    Value = SortDirectionMode.Asc,
                    Text = "صعودی"
                }
            };

            #endregion

            #region SortableList

            SortableList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = SortByMode.CreatedOn,
                    Text = "تاریخ درج"
                },
                new SelectListItem
                {
                    Value = SortByMode.ModifiedOn,
                    Text = "تاریخ آخرین تغییر"
                },

            };

            #endregion

            #region PageSizeList

            PageSizeList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "10",
                    Text = "۱۰"
                },
                new SelectListItem
                {
                    Value = "20",
                    Text = "۲۰"
                },
                new SelectListItem
                {
                    Value = "30",
                    Text = "۳۰"
                },
                new SelectListItem
                {
                    Value = "50",
                    Text = "۵۰"
                },
                new SelectListItem
                {
                    Value = "100",
                    Text = "۱۰۰"
                }
            };

            #endregion
        }

        /// <summary>
        /// اطلاعات جستجو و مرتب سازی
        /// </summary>
        public CategorySearchRequest SearchRequest { get; set; }

        /// <summary>
        /// لیست ویو مدل نمایش متقاضی
        /// </summary>
        public IEnumerable<CategoryDetailViewModel> Categories { get; set; }

        /// <summary>
        /// لیست فیلد هایی که برای مرتب سازی استفاده  خواهند شد
        /// </summary>
        public IEnumerable<SelectListItem> SortableList { get; set; }

        /// <summary>
        /// لیست 
        /// </summary>
        public IEnumerable<SelectListItem> SortOrderList { get; set; }

        /// <summary>
        /// لیست اعداد برای نمایش در هر صفحه
        /// </summary>
        public IEnumerable<SelectListItem> PageSizeList { get; set; }
    }
}