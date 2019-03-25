using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingWebMvc.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingWebMvc.Controllers
{
    public class WorkhorseController : Controller
    {
private readonly ILogger _logger;

public WorkhorseController(ILogger<WorkhorseController> logger)
{
    _logger = logger;
}

        // GET: Workhorse
        public ActionResult Index()
        {
            PerformStep(1);
            PerformStep(2);
            PerformStep(3);

            return View();
        }

        private void PerformStep(int stepId)
        {
            // Step 1: kick off something here
            _logger.LogInformation(LoggingEvents.Step1KickedOff, "Step {stepId} Kicked Off.", stepId);

            // Step 1: continue processing here
            _logger.LogInformation(LoggingEvents.Step1InProcess, "Step {stepId} in process...", stepId);

            // Step 1: wrap it up
            _logger.LogInformation(LoggingEvents.Step1Completed, "Step {stepId} completed!", stepId);
        }
    }
}