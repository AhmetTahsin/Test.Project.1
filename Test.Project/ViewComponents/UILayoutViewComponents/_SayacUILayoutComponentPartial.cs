﻿using Microsoft.AspNetCore.Mvc;

namespace Test.Project.ViewComponents.UILayoutViewComponents
{
    public class _SayacUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
