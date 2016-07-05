﻿using DefaultOrganization.Core.Interfaces;
using DefaultOrganization.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace DefaultOrganization.Controllers
{
    public class NinjasController : Controller
    {
        private readonly IRepository<Ninja> _ninjaRepository;

        public NinjasController(IRepository<Ninja> ninjaRepository)
        {
            _ninjaRepository = ninjaRepository;
        }

        public IActionResult Index()
        {
            var entities = _ninjaRepository.List();
            return View(entities);
        }

        public IActionResult Details(int id)
        {
            var entity = _ninjaRepository.GetById(id);
            return View(entity);
        }

        public IActionResult Add()
        {
            var entity = new Ninja()
            {
                Name = "Random Ninja"
            };
            _ninjaRepository.Add(entity);

            return RedirectToAction("Index");
        }
    }
}