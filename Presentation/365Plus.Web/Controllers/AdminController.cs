﻿using _365Plus.Service.Assistant;
using _365Plus.Service.Clients;
using _365Plus.Service.Codes;
using _365Plus.Service.Country;
using _365Plus.Service.Ebooks;
using _365Plus.Service.EmailTemplate;
using _365Plus.Service.HtmlPages;
using _365Plus.Service.Languages;
using _365Plus.Service.Model;
using _365Plus.Service.User;
using _365Plus.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _365Plus.Web.Controllers
{
	public class AdminController : Controller
	{

		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;
		private ClientService userSubscriptionStatusRepository;

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}


		private readonly UserService _userService;
		private readonly AssistantService _assistantService;
		private readonly LanguageService _languageService;
		private readonly CountryService _countryService;
		private readonly EmailTemplateService _emailTemplateService;
		private readonly ClientService _clientService;
		private readonly HtmlPageService _htmlPageService;
		private readonly EbookService _ebookService;
		private readonly CodeService _codesService;
		public AdminController(UserService userService, LanguageService languageService, CountryService countryService, EmailTemplateService emailTemplateService,
			AssistantService assistantService, ClientService clientService, HtmlPageService htmlPageService, EbookService ebookService, CodeService codeService)
		{
			this._userService = userService;
			this._assistantService = assistantService;
			this._languageService = languageService;
			this._countryService = countryService;
			this._emailTemplateService = emailTemplateService;
			this._clientService = clientService;
			this._htmlPageService = htmlPageService;
			this._ebookService = ebookService;
			this._codesService = codeService;
		}



		[Authorize]
		public ActionResult Index()
		{
			return View();
		}
		[Authorize]
		public ActionResult Language()
		{
			return View();
		}

		public JsonResult GetAllLanguages()
		{
			var data = _languageService.GetAll();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetLanguageById(double id)
		{
			var data = _languageService.GetLanguageById(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult AddLanguage(Data.Models.Language language)
		{
			var result = new { Success = "true", Message = "Success" };

			language = _languageService.AddLanguage(language);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult UpdateLanguage(Data.Models.Language language)
		{
			var result = new { Success = "true", Message = "Success" };

			_languageService.UpdateLanguage(language);
			return Json(result, JsonRequestBehavior.DenyGet);
		}
		[Authorize]
		public ActionResult Country()
		{
			return View();
		}

		public JsonResult GetAllCountries()
		{
			var data = _countryService.GetAll();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetCountryByID(double id)
		{
			var data = _countryService.GetCountryByID(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult AddCountry(Data.Models.Country country)
		{
			var result = new { Success = "true", Message = "Success" };

			country = _countryService.AddCountry(country);
			return Json(result, JsonRequestBehavior.DenyGet);
		}
		[Authorize]
		public ActionResult Assistant()
		{
			return View();

		}

		//public ActionResult Advisor()
		//{
		//    return View();
		//}


		// create all Assistant from here , it will be entered into user table
		public JsonResult AddAssistant(AssistantModel assistant)
		{
			var result = new { Success = "true", Message = "Success" };
			var roleManager = new RoleManager<Role, int>(new RoleStore<Role, int, UserRole>(new ApplicationDbContext()));


			if (UserManager.FindByName(assistant.UserName) == null)
			{
				var user = new User
				{
					UserName = assistant.UserName,
					Email = assistant.PersonalEmail,
					EmailConfirmed = true,
					UserProfile = new UserProfile { FirstName = assistant.FirstName, LastName = assistant.LastName, IsActive = true, IsBlocked = false, IsVersionUpdated = true }
				};
				var res = UserManager.Create(user, assistant.Password);
				if (res.Succeeded)
				{
					UserManager.AddToRole(user.Id, "Assistant");
					assistant.ModifiedBy = Convert.ToInt32(User.Identity.GetUserId());

					assistant.Id = user.UserProfile.Id;

					this._assistantService.UpdateAssistant(assistant);

				}

			}

			return Json(result, JsonRequestBehavior.DenyGet);

		}

		public JsonResult GetAllAssistant()
		{
			var data = _assistantService.GetAll();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetAssistantByID(double id)
		{
			var data = _assistantService.GetAssistantByID(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		[Authorize]
		public ActionResult EmailTemplate()
		{
			return View();
		}

		public JsonResult GetAllEmailTemplates(long languageId)
		{
			var data = this._emailTemplateService.GetAllEmailTemplatesByLanguage(languageId);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetEmailTemplateByID(double id)
		{
			var data = this._emailTemplateService.GeEmailTemplateByID(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetAllEmailTemplateType()
		{
			var data = _emailTemplateService.GetAllEmailTemplateType();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		[ValidateInput(false)]
		public JsonResult AddEmailTemplate(Data.Models.EmailTemplate emailTemplate)
		{
			var result = new { Success = "true", Message = "Success" };
			emailTemplate.CreatedBy = Convert.ToInt32(User.Identity.GetUserId());
			emailTemplate.CreatedDate = DateTime.UtcNow;

			emailTemplate = _emailTemplateService.AddEmailTemplate(emailTemplate);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult UpdateEmailTemplate(EmailTemplateModel emailTemplate)
		{
			var result = new { Success = "true", Message = "Success" };
			emailTemplate.ModifiedBy = Convert.ToInt32(User.Identity.GetUserId());
			emailTemplate.ModifiedDate = DateTime.UtcNow;

			_emailTemplateService.UpdateEmailTemplate(emailTemplate);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[Authorize]
		public ActionResult HtmlPages()
		{
			return View();
		}

		public JsonResult GetAllHtmlPages(long languageId)
		{
			var data = this._htmlPageService.GetAll(languageId);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetHtmlPageById(long id)
		{
			var data = this._htmlPageService.GetHtmlPageById(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		//[ValidateInput(false)]
		public JsonResult UpdateHtmlPages(HtmlPageContentModel hTMLPage)
		{
			var result = new { Success = "true", Message = "Success" };

			hTMLPage.ModifiedBy = Convert.ToInt32(User.Identity.GetUserId());
			hTMLPage.ModifiedDate = DateTime.UtcNow;

			_htmlPageService.UpdateHtmlPage(hTMLPage);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[Authorize]
		public ActionResult Clients()
		{
			return View();
		}

		public JsonResult GetAllClients()
		{
			var data = _clientService.GetAll();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetSubscriptionStatus(int userId)
		{
			var data = _clientService.GetSubscriptionStatus(userId);
			var user = _userService.GetById(userId);
			return Json(new { User = new { UserName = user.UserName, PersonalEmail = user.Email }, Data = data }, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult UpdateClientSubscriptionStatus(List<Data.Models.UserSubscriptionStatu> subscriptions)
		{
			var result = new { Success = "true", Message = "Success" };

			_clientService.UpdateClientSubscriptionStatus(subscriptions);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[Authorize]
		public ActionResult Ebooks()
		{
			return View();
		}

		public JsonResult GetAllEbooks(int userID)
		{
			var data = _ebookService.GetAllEbooks();
			return Json(data, JsonRequestBehavior.AllowGet);
        }

		[HttpPost]
		[ValidateInput(false)]
		public JsonResult AddEbook(Data.Models.Ebook ebook)
		{
			var result = new { Success = "true", Message = "Success" };

			_ebookService.AddEbook(ebook);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		public JsonResult GetEbooksByID(double id)
		{
			var data = this._ebookService.GetEbooksByID(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult UpdateEbook(EbookModel ebook)
		{
			var result = new { Success = "true", Message = "Success" };

			_ebookService.UpdateEbook(ebook);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[Authorize]
		public ActionResult Codes()
		{
			return View();
		}

		[HttpGet]
		public JsonResult GetAllCodes()
		{
			var data = _codesService.GetAll();
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetCodesByID(int id)
		{
			var data = _codesService.GetCodeByID(id);
			return Json(data, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult AddCodes(Data.Models.Code code)
		{
			var result = new { Success = "true", Message = "Success" };
			code.CreatedBy = Convert.ToInt32(User.Identity.GetUserId());
			code.CreatedDate = DateTime.UtcNow;
			code = _codesService.AddCode(code);
			return Json(result, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult UpdateCodes(Data.Models.Code code)
		{
			var result = new { Success = "true", Message = "Success" };

			code.ModifiedBy = Convert.ToInt32(User.Identity.GetUserId());
			code.ModifiedDate = DateTime.UtcNow;

			_codesService.UpdateCode(code);
			return Json(result, JsonRequestBehavior.DenyGet);
		}
		
	}
}