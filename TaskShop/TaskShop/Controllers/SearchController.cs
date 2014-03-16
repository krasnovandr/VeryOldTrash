﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared;
using TaskShop.Models;
using TaskShop.Repositories;
using TaskShop.Services;

namespace TaskShop.Controllers
{
    public class SearchController : Controller
    {

        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            this._service = service;
        }

        [HttpPost]
        public JsonResult GetAll(SearchModel searchModel)
        {
            return Json(_service.GetAll(searchModel));
        }
    }
}
