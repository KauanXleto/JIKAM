using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChallengeBosch.Backbone;
using ChallengeBosch.Backbone.BusinessRules;
using ChallengeBosch.Backbone.BusinessEntities;
using Microsoft.VisualBasic.CompilerServices;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using System.Text;

namespace ChallengeBosch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        CoreBusinessRules CoreBusinessRules { get; set; }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RobotController> _logger;


        public RobotController(ILogger<RobotController> logger, CoreBusinessRules _CoreBusinessRules)
        {
            _logger = logger;
            this.CoreBusinessRules = _CoreBusinessRules;
        }

        [HttpGet("GetWayPoints")]
        public List<WayPoint> GetWayPoints()
        {
            return this.CoreBusinessRules.GetWayPoints();
        }

        [HttpGet("GetTaskStatus")]
        public List<Backbone.BusinessEntities.TaskStatus> GetTaskStatus()
        {
            return this.CoreBusinessRules.GetTaskStatus();
        }

        [HttpGet("GetRobotStatus")]
        public List<RobotStatus> GetRobotStatus()
        {
            return this.CoreBusinessRules.GetRobotStatus();
        }

        [HttpGet("GetRobotInfos")]
        public List<RobotInfo> GetRobotInfos()
        {
            return this.CoreBusinessRules.GetRobotInfos();
        }

        [HttpPost("SendInfoFromMqtt")]
        public void SendInfoFromMqtt(SendInfoMqtt entity)
        {
            this.CoreBusinessRules.SendInfoFromMqtt(entity.topic, entity.message);
        }
    }
}
