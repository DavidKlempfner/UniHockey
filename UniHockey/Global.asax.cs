using AutoMapper;
using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UniHockey
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            CreateMappings();
        }

        private void CreateMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Team, TeamDto>();
                cfg.CreateMap<TeamDto, Team>();
                cfg.CreateMap<Player, PlayerDto>();
                cfg.CreateMap<PlayerDto, Player>();
            });
        }
    }
}
