using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Amino.PersonsRepository.Store;
using Amino.PersonsWeb.Models;
using Castle.Core.Logging;

namespace Amino.PersonsWeb.ApplicationServices
{
    public class ZipCodeService : IZipCodeService
    {
        private readonly ILogger _logger;
        
        public ZipCodeService(ILogger logger)
        {
            _logger = logger;
        }

        public ZipCodeViewModel GetZipCodeViewModel()
        {
            var zipCodeViewModel = new ZipCodeViewModel();

            try
            {
                using (var personsRepository = new PersonsRepositoryModel())
                {
                    var zipCodes = personsRepository.ZipCodes.OrderByDescending(x => x.City).ToList();

                    zipCodeViewModel.ZipCodes = new List<SelectListItem>(zipCodes.Select(zipCode =>
                        new SelectListItem
                        {
                            Text = string.Format("{0} {1}", zipCode.ZipCode1, zipCode.City),
                            Value = zipCode.ZipCode1,
                        }));
                }
            }
            catch (Exception e)
            {
                _logger.Error("ZipCodeService failed.. Unable to create zipcodeviewmodel", e);
            }

            return zipCodeViewModel;
        }
    }
}