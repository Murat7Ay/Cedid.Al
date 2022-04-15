using Cedid.AkilliLojistik.Lookups;
using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.Vehicles;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Cedid.AkilliLojistik.Web
{
    public static class Utils
    {
        public static List<SelectListItem> GetSelectListItems(List<ParameterDto> parameterDtos, bool addEmptyRecord = true)
        {
            if(parameterDtos == null || parameterDtos.Count == 0)
            {
                return new List<SelectListItem>();
            }

            List<SelectListItem> list = parameterDtos.Select(s => new SelectListItem(s.Text, s.Id.ToString())).ToList();

            if (addEmptyRecord)
            {
                list.Insert(0, new SelectListItem("",""));
            }

            return list;
        }

        public static List<SelectListItem> GetVehicleSelectListItem(List<VehicleLookup> vehicleLookups, bool addEmptyRecord = true)
        {
            if (vehicleLookups == null || vehicleLookups.Count == 0)
            {
                return new List<SelectListItem>();
            }

            List<SelectListItem> list = vehicleLookups.Select(s => new SelectListItem(s.PlateNo, s.Id.ToString())).ToList();

            if (addEmptyRecord)
            {
                list.Insert(0, new SelectListItem("", ""));
            }

            return list;
        }

        public static List<SelectListItem> GetUserSelectListItem(List<UserLookup> userLookups, bool addEmptyRecord = true)
        {
            if (userLookups == null || userLookups.Count == 0)
            {
                return new List<SelectListItem>();
            }

            List<SelectListItem> list = userLookups.Select(s => new SelectListItem($"{s.Name} {s.Surname}", s.Id.ToString())).ToList();

            if (addEmptyRecord)
            {
                list.Insert(0, new SelectListItem("", ""));
            }

            return list;
        }
    }
}
