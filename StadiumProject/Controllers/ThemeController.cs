using System;
using System.Collections.Generic;
using StadiumProject.Data;
using StadiumProject.Models;

namespace StadiumProject.Controllers
{
    public class ThemeController
    {
        private readonly ThemeRepository themeRepository;

        public ThemeController()
        {
            themeRepository = new ThemeRepository();
        }

        public List<Theme> GetAllThemes()
        {
            return themeRepository.GetAllThemes();
        }
    }
}
